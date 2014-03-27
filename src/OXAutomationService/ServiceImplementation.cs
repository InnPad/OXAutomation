using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OXAutomation
{
    partial class Service
    {
        private AutoResetEvent _autoEvent;
        private Timer _timer;

        public void InitializeService()
        {
            _autoEvent = new AutoResetEvent(false);
        }

        public void Start()
        {
            _timer = new Timer(OnTimedEvent, _autoEvent, 0, (long)TimeSpan.FromSeconds(5).TotalMilliseconds);

            
        }

        public void Stop()
        {
            Console.WriteLine("\nDestroying timer.");

            Timer timer;

            lock (this)
            {
                timer = _timer;
                _timer = null;
            }

            if (timer != null)
            {
                _autoEvent.WaitOne(1000, false);

                timer.Dispose();
            }
        }

        // Specify what you want to happen when the Elapsed event is 
        // raised.
        private void OnTimedEvent(object state)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", DateTime.Now);

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var task = (Configuration.TaskSection)config.GetSection("oxAutomation/task");

            var startTime = (TimeOfDay)task.StartTime;
            var startNext = startTime.Next((TimeSpan)(TimeOfDay)task.Period);

            if (startTime.IsNow)
            {
                if (task == null)
                {
                    return;
                }

                var processes = Process.Enum(task.Process);
                var actions = task.Elements.OrderBy(o => o.Step).ThenBy(o => o.ElementInformation.LineNumber);

                if (!string.IsNullOrEmpty(task.Restart))
                {
                    processes.ExecuteAll(actions.Where(o => o.Step < 0));

                    processes.TerminateAll(0);

                    processes = new[] { Process.Start(task.Restart, task.Arguments) };

                    processes.ExecuteAll(actions.Where(o => o.Step >= 0));
                }
                else
                {
                    processes.ExecuteAll(actions);
                }
            }

            var wakePeriod = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
            var wakeTime = (int)Math.Min((startNext - DateTime.Now).TotalMilliseconds, wakePeriod);

            _timer.Change(wakeTime, wakePeriod);
        }
    }
}
