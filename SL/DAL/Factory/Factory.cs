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
			if(ConfigurationManager.AppSettings["LoggerRepository"] == "FILE")
			{
                return new LoggerFileRepository();
            }
            else
			{ 
                return new LoggerSQLRepository();
            }


        }
	}

}
