using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OXAutomation
{
    public class Process
    {
        public static IReadOnlyCollection<Process> Enum(string name)
        {
            /*return Array.AsReadOnly<Process>(System.Diagnostics.Process.GetProcesses()
                .Where(o => string.Equals(name, o.MainModule.FileName, StringComparison.OrdinalIgnoreCase))
                .Select(o => new Process(o)).ToArray());*/

            return Array.AsReadOnly<Process>(System.Diagnostics.Process.GetProcessesByName(name).Select(o => new Process(o)).ToArray());
        }

        public static Process Start(string path, string arguments)
        {
            var process = System.Diagnostics.Process.Start(path, arguments);

            process.WaitForInputIdle(5000);

            return new Process(process);
        }

        System.Diagnostics.Process _process;

        private Process(System.Diagnostics.Process process)
        {
            _process = process;
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
                return long.MinValue;
            }

            if (!wParam.TryParseInt(out wparam))
            {
                return long.MinValue + 1;
            }

            if (!lParam.TryParseInt(out lparam))
            {
                return long.MinValue + 2;
            }

            return Send(msg, wparam, lparam);
        }

        public void Terminate(int timeout = 0)
        {
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
