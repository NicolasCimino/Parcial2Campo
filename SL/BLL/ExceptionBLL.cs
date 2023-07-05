using SL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.BLL
{
    internal static class ExceptionBLL
    {
        private static string dalAssembly = ConfigurationManager.AppSettings["DALAssembly"];
        private static string bllAssembly = ConfigurationManager.AppSettings["BLLAssembly"];

        public static void Handle(Exception ex, object sender)
        {
            string assemblyName = sender.GetType().Module.Name;

            if (assemblyName == dalAssembly)
            {
                DALPolicy(ex);
            }
            else if (assemblyName == bllAssembly)
            {
                BLLPolicy(ex);
            }
        }

        private static void DALPolicy(Exception ex)
        {
            Logger.Current.Store(new Domain.Log(ex.Message,System.Diagnostics.Tracing.EventLevel.Critical,System.DateTime.Now));
            throw new Exception(String.Empty, ex);
        }

        private static void BLLPolicy(Exception ex)
        {
            if (ex.InnerException != null)
            {
                throw new Exception("Error de acceso a datos.", ex);
            }
            else
            {
                Logger.Current.Store(new Domain.Log(ex.Message, System.Diagnostics.Tracing.EventLevel.Error,System.DateTime.Now));
                throw ex;
            }
        }
    }
}
