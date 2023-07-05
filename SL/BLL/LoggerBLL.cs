using SL.Contracts;
using SL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.BLL
{

        public sealed class LoggerBLL : ILogger
        {
            private readonly static LoggerBLL _instance = new LoggerBLL();

            public static LoggerBLL Current
            {
                get
                {
                    return _instance;
                }
            }

            private LoggerBLL()
            {
                
            }
            public List<Log> GetAll()
            {
                  return  DAL.Factory.Factory.Current.GetLoggerRepository().GetAll();
            }

            public void Store(Log log)
            {
                DAL.Factory.Factory.Current.GetLoggerRepository().Store(log);
            }
        }

       
}

