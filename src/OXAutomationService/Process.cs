using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OXAutomation
{
    public partial class Process
    {
        public static IReadOnlyCollection<Process> Enum(string name)
        {
            /*return Array.AsReadOnly<Process>(System.Diagnostics.Process.GetProcesses()
                .Where(o => string.Equals(name, o.MainModule.FileName, StringComparison.OrdinalIgnoreCase))
                .Select(o => new Process(o)).ToArray());*/

            return Array.AsReadOnly<Process>(System.Diagnostics.Process.GetProcessesByName(name).Select(o => new Process(o)).ToArray());
        }

        private System.Diagnostics.Process _process;
        private log4net.ILog _logger;
        
        private Process(System.Diagnostics.Process process)
        {
            _process = process;
            _logger = log4net.LogManager.GetLogger("OXAutomation");
        }

        public string Id
        {
            get { return _process.ProcessName; }
        }

        public string Name
        {
            get { return _process.ProcessName; }
        }

        public string Location
        {
            get { return _process.Modules[0].FileName; }
        }

        public long Send(uint msg, int wparam, int lparam)
        {
            var handles = EnumerateProcessWindowHandles(); //new [] { _process.MainWindowHandle };

            foreach (var handle in handles.Take(3))
            {
                User32.PostMessage(handle, msg, wparam, lparam);
            }

            return 0;
        }

        public long Send(string message, string wParam, string lParam)
        {
            uint msg;
            int wparam;
            int lparam;

            if (!message.TryParseMsg(out msg))
            {
                _logger.ErrorFormat("Could not parse message {0}", message);
                return long.MinValue;
            }

            if (!wParam.TryParseInt(out wparam))
            {
                _logger.ErrorFormat("Could not parse wparam {0}", wParam);
                return long.MinValue + 1;
            }

            if (!lParam.TryParseInt(out lparam))
            {
                _logger.ErrorFormat("Could not parse lparam {0}", lParam);
                return long.MinValue + 2;
            }

            _logger.InfoFormat("Sending {0} 0x{1:X08} 0x{2:X08} to {3} ({4})", message, wparam, lparam, _process.ProcessName, _process.Id);

            return Send(msg, wparam, lparam);
        }

        public void Terminate(int timeout = 0)
        {
            _logger.InfoFormat("Terminating process {0} (id: {1})", _process.ProcessName, _process.Id);

            _process.Kill();

            if (timeout > 0)
            {
                _process.WaitForExit(timeout);
            }
            else
            {
                _process.WaitForExit();
            }
        }

        public IEnumerable<IntPtr> EnumerateProcessWindowHandles()
        {
            var handles = new List<IntPtr>();

            foreach (System.Diagnostics.ProcessThread thread in _process.Threads)
                User32.EnumThreadWindows(thread.Id, (hWnd, lParam) => { handles.Add(hWnd); return true; }, IntPtr.Zero);

            return handles;
        }
    }
}
