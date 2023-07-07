using SL.Contracts;
using SL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SL.Services
{
	public sealed class ServicesMailNotify : IObserver
	{
		private readonly static ServicesMailNotify _instance = new ServicesMailNotify();
		public List<string> mails;

		public static ServicesMailNotify Current
		{
			get
			{
				return _instance;
			}
		}
		private ServicesMailNotify()
		{
			mails = new List<string>();
		}

        public void Update(ISubject s)
        {
			Logger log = (Logger)s;
			if (log.AuxLog.Messege.Contains("CriticalError")) 
			{
				mails.Add( System.DateTime.Now.ToString() + " Se envio mail a soporteNivel1@email.com");

            }
            if (log.AuxLog.Messege.Contains("FatalError"))
            {
                mails.Add(System.DateTime.Now.ToString() + " Se envio mail a soporteNivel2@email.com");

            }
        }
    }

}

