using SL.Contracts;
using SL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Services
{

	public sealed class Logger :ILogger,ISubject
	{
		private readonly static Logger _instance = new Logger();
        private List<IObserver> observers = new List<IObserver>();
        private Log auxLOG;
        internal Log AuxLog { get { return auxLOG; } }
		public static Logger Current
		{
			get
			{
				return _instance;
			}
		}

		private Logger()
		{
            Attach(ServicesMailNotify.Current);
		}

        public List<Log> GetAll()
        {
           return BLL.LoggerBLL.Current.GetAll();
        }

        public List<Log> GetLogsToday()
        {
            return BLL.LoggerBLL.Current.GetLogsToday();
        }

        public void Store(Log log)
        {
            BLL.LoggerBLL.Current.Store(log);
            auxLOG = log;
            Notify();
        }


        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Notify()
        {
            foreach (IObserver obs in observers)
            {
                obs.Update(this);
            }
        }

    }

}
