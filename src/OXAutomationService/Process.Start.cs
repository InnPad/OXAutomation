using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXAutomation
{
    partial class Process
    {
        /// <summary>
        /// Create process with UI.
        /// http://stackoverflow.com/questions/3798612/service-starting-a-process-wont-show-gui-c-sharp
        /// http://www.codeproject.com/Articles/35773/Subverting-Vista-UAC-in-Both-and-bit-Archite
        /// </summary>
        /// <param name="path"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static Process Start(string path, string arguments)
        {
            var logger = log4net.LogManager.GetLogger("OXAutomation");
            logger.InfoFormat("Starting process {0} ({1})", path, arguments);

            // launch the application
            ApplicationLoader.PROCESS_INFORMATION procInfo;
            if (ApplicationLoader.StartProcessAndBypassUAC(path, out procInfo))
            {
                var process = System.Diagnostics.Process.GetProcessById((int)procInfo.dwProcessId);

                logger.InfoFormat("Process created with user interface. Spinning thread a few iterations so UI gets ready...", process.ProcessName, process.Id);

                System.Threading.Thread.SpinWait(10);

                process.WaitForInputIdle(5000);

                return new Process(process);
            }

            return null;
        }
    }
}
