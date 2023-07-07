using DAL.Tools;
using SL.Contracts;
using SL.Domain;
using SL.Services.Extension;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.DAL.Repositories
{
    internal class LoggerSQLRepository : ILogger
    {
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Log] (DateLog,LevelError,Message) VALUES (@Date,@LevelError,@Message)";
        }

        private string SelectAllStatement
        {
            get => "SELECT  DateLog,Message,LevelError FROM [dbo].[Log]";
        }

        private string SelectToday
        {
            get => "SELECT  DateLog,Message,LevelError FROM [dbo].[Log] WHERE  CONVERT(date,DateLog) = CONVERT(date,@Date)";
        }
        #endregion
        public List<Log> GetAll()
        {
            List<Log> logs = new List<Log>();
            try
            {
                using (var dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
                {
                    while (dr.Read())
                    {
                            Log log = new Log();
                            log.Date = (DateTime)dr["DateLog"];                           
                            log.Severity = (EventLevel)EventLevel.Parse(typeof(EventLevel), dr["LevelError"].ToString());
                            log.Messege = dr["Message"].ToString();
                            logs.Add(log);                  
                    }
                }       
            }
            catch (Exception ex)
            {
                ex.ExceptionHandle(this);

            }
            return logs;
        }

        public List<Log> GetLogsToday()
        {
            List<Log> logs = new List<Log>();
            try
            {
                using (var dr = SqlHelper.ExecuteReader(SelectToday, System.Data.CommandType.Text,
                new SqlParameter[] { new SqlParameter("@Date", System.DateTime.Now) }))
                {

                    while (dr.Read())
                    {
                        Log log = new Log();
                        log.Date = (DateTime)dr["DateLog"];
                        log.Severity = (EventLevel)EventLevel.Parse(typeof(EventLevel), dr["LevelError"].ToString());
                        log.Messege = dr["Message"].ToString();
                        logs.Add(log);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ExceptionHandle(this);

            }
            return logs;
        }
    

        public void Store(Log log)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text,
                new SqlParameter[] {
                    
                    new SqlParameter("@Date",log.Date),
                    new SqlParameter("@LevelError",log.Severity.ToString()),
                    new SqlParameter("@Message",log.Messege )
                });
            }
            catch (Exception ex)
            {
                ex.ExceptionHandle(this);

            }
        }
    }
}
