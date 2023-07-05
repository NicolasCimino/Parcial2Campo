using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessException
{
    public class ClienteMenorEdadException : Exception
    {
        public ClienteMenorEdadException() : base("El cliente es menor de edad")
        {
          
        }
    }
}
