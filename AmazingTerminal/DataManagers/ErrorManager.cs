using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.DataManagers
{
    public static class ErrorManager
    {
        public static void WriteErrorToLogs(string errorMessage)
        {
            using (var sw = new StreamWriter(AppConfig.ErrorLogsPath, true, Encoding.UTF8))
            {
                sw.WriteLine(errorMessage);
            }
        }
    }
}
