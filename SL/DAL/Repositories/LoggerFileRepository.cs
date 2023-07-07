using SL.Contracts;
using SL.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SL.DAL.Repositories
{
    internal class LoggerFileRepository : ILogger
    {
        private string logFilePath = ConfigurationManager.AppSettings["LogFilePath"];
        private string logFileName = ConfigurationManager.AppSettings["LogFileName"];
        public List<Log> GetAll()
        {
            List<FileInfo> archivosBitacora = GetAllFiles();

            List<Log> logs = new List<Log>();

            foreach (var item in archivosBitacora)
            {
                using (StreamReader streamReader = new StreamReader(item.FullName))
                {
                    while (!streamReader.EndOfStream)
                    {
                    string line = streamReader.ReadLine();
                    string[] cabecera = line.Split('-');

                    Log log = new Log(); 
                    log.Date = DateTime.Parse(cabecera[0].Trim());
                    log.Severity = (EventLevel) EventLevel.Parse(typeof(EventLevel), cabecera[1].Replace("LEVEL", "").Trim());
                    log.Messege = cabecera[2].Replace("MENSAJE:", "").Trim();
                    logs.Add(log);
                    }
                }
            }

            return logs;
        }

        public void Store(Log log)
        {
            string fileName = logFilePath + DateTime.Now.ToString("yyyyMMdd") + logFileName;
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                string formattedMessage = $"{log.Date.ToString("dd/MM/yyyy HH:mm:ss")} - LEVEL {log.Severity.ToString()} - MENSAJE: {log.Messege}";
                sw.WriteLine(formattedMessage);
            }
        }

        public List<Log> GetLogsToday()
        {
            List<FileInfo> archivosBitacora = GetFilesToday();

            List<Log> logs = new List<Log>();

            foreach (var item in archivosBitacora)
            {
                using (StreamReader streamReader = new StreamReader(item.FullName))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();
                        string[] cabecera = line.Split('-');

                        Log log = new Log();
                        log.Date = DateTime.Parse(cabecera[0].Trim());
                        log.Severity = (EventLevel)EventLevel.Parse(typeof(EventLevel), cabecera[1].Replace("LEVEL", "").Trim());
                        log.Messege = cabecera[2].Replace("MENSAJE:", "").Trim();
                        logs.Add(log);
                    }
                }
            }

            return logs;
        }

        #region Funciones
        private List<FileInfo> GetAllFiles()
        {

            DirectoryInfo directoryInfo = new DirectoryInfo(logFilePath);
            List<FileInfo> entries = new List<FileInfo>();

            foreach (var item in directoryInfo.GetFiles())
            {
                entries.Add(item);
            }

            return entries;
        }

        private List<FileInfo> GetFilesToday()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(logFilePath);
            List<FileInfo> entries = new List<FileInfo>();

            foreach (var item in directoryInfo.GetFiles())
            {
                if (item.Name.Contains(System.DateTime.Now.ToString("yyyyMMdd")))
                {
                    entries.Add(item);
                }
            }

            return entries;
        }
        #endregion


    }
}
