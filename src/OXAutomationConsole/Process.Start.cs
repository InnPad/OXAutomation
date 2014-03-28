using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXAutomation
{
    partial class Process
    {
        public static Process Start(string path, string arguments)
        {
            var logger = log4net.LogManager.GetLogger("OXAutomation");
            logger.InfoFormat("Starting process {0} ({1})", path, arguments);

            var process = System.Diagnostics.Process.Start(path, arguments);

            process.WaitForInputIdle(5000);

            return new Process(process);
        }
    }
}
