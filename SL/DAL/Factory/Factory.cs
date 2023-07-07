using SL.Contracts;
using SL.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.DAL.Factory
{

	public sealed class Factory
	{
		private readonly static Factory _instance = new Factory();

		public static Factory Current
		{
			get
			{
				return _instance;
			}
		}

		private Factory()
		{
			
		}

		public ILogger GetLoggerRepository()
		{
			switch (ConfigurationManager.AppSettings["LoggerRepository"])
			{
				case "SQL": 
					return new LoggerSQLRepository();
                   
                case "FILE":
                    return new LoggerFileRepository();

                default:
					 return new LoggerFileRepository();
                   
			}

        }
	}

}
