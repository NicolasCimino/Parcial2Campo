using SL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Contracts
{
    public interface ILogger
    {
         void Store(Log log);
        List<Log> GetAll();
    }
}
