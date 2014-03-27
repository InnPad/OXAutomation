using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXAutomation
{
    public static class ProcessExtensions
    {
        const int AltDown = 0x20000000;
        //const int CtrlDown = 
        //int iRepeatTimes = (lParam & 0x0000FFFF);
        //int iScanCode = (lParam & 0x00FF0000) >> 16;
        //BOOL bALT_IsDown = (lParam & 0x20000000) ? TRUE : FALSE;
        //BOOL bAlreadyPressed = (lParam & 0x40000000) ? TRUE : FALSE;
        //BOOL bNowReleased = (lParam & 0x80000000) ? TRUE : FALSE;  

        public static void ExecuteAll(this IEnumerable<Process> processes, IEnumerable<Configuration.SendElement> collection)
        {
            if (processes != null)
            {
                foreach (var process in processes)
                {
                    process.ExecuteAll(collection);
                }
            }
        }

        public static void Execute(this Process process, Configuration.SendElement action)
        {
            process.Send(action.Message, action.WParam, action.LParam);

            if (action.Sleep > 0)
            {
                System.Threading.Thread.Sleep(action.Sleep);
            }
        }

        public static void ExecuteAll(this Process process, IEnumerable<Configuration.SendElement> collection)
        {
            if (process != null && collection != null)
            {
                foreach (var action in collection)
                {
                    process.Execute(action);

                    if (action.Sleep > 0)
                    {
                        System.Threading.Thread.Sleep(action.Sleep);
                    }
                }
            }
        }

        public static void TerminateAll(this IEnumerable<Process> collection, int timeout = 0)
        {
            foreach (var process in collection)
            {
                process.Terminate(timeout);
            }
        }
    }
}
