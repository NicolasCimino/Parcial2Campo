using SL.Contracts;
using SL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Services
{

	public sealed class Logger : ILogger
	{
		private readonly static Logger _instance = new Logger();

		public static Logger Current
		{
			get
			{
				return _instance;
			}
		}

		private Logger()
		{
			
		}

        public List<Log> GetAll()
        {
           return BLL.LoggerBLL.Current.GetAll();
        }

        public void Store(Log log)
        {
            BLL.LoggerBLL.Current.Store(log);
        }
    }

}
