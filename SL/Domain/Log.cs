using SL.Contracts;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Domain
{
    public class Log 
    {
        private string messege;
        private EventLevel severity;
        private DateTime date;
        public DateTime Date { get { return date; } set { date = value; } }
        public EventLevel Severity { get { return severity; } set { severity = value; } }
        public string Messege { get { return messege; } set {  messege =  value; } }

        public Log() { }
        public Log(string messege, EventLevel severity,DateTime date)
        {
            this.messege=messege; 
            this.severity = severity;
            this.date = date;

        }

    }
}
