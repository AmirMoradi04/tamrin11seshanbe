using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamrin11.Loger
{
    public interface ILogger
    {
        void LogError(string message);
        void Log(string message);
        void LogWarning(string message);

    }
}
