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
        private log4net.ILog _logger;
        private bool _ready;

        public void InitializeService()
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger = log4net.LogManager.GetLogger("OXAutomation");
            _logger.Info("Service initialized.");
            _autoEvent = new AutoResetEvent(false);
        }

        internal void StartImplementation()
        {
            _ready = true;
            _logger.Info("Service started.");
            _timer = new Timer(OnTick, _autoEvent, 0, (long)TimeSpan.FromSeconds(5).TotalMilliseconds);
        }

        internal void StopImplementation()
        {
            _ready = false;

            _logger.Info("Service stopped.");

            _logger.Info("Destroying timer.");

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

            _logger.Info("Exit.");
        }

        // Specify what you want to happen when the Elapsed event is 
        // raised.
        private void OnTick(object state)
        {
            if (!_ready) return;

            _ready = false;

            _logger.Info("Entering Tick...");

            Configuration.TaskSection task;

            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                task = (Configuration.TaskSection)config.GetSection("oxAutomation/task");
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return;
            }

            var startTime = (TimeOfDay)task.StartTime;
            var period = (TimeSpan)(TimeOfDay)task.Period;
            var startNext = startTime.Next(period);
            var margin = (startNext - DateTime.Now).TotalMilliseconds;

            _logger.InfoFormat("Run margin: {0} milliseconds [{1:HH:mm:ss}]", margin, startNext);

            if (Math.Abs(margin) < 600)
            {
                _logger.Info("Running task...");

                var processes = Process.Enum(task.Process);
                var actions = task.Elements.OrderBy(o => o.Step).ThenBy(o => o.ElementInformation.LineNumber);

                try
                {
                    if (!string.IsNullOrEmpty(task.Restart))
                    {
                        processes.ExecuteAll(actions.Where(o => o.Step < 0));

                        processes.TerminateAll(0);

                        processes = new[] { Process.Start(task.Restart, task.Arguments) }.Where(o => o != null).ToArray();

                        processes.ExecuteAll(actions.Where(o => o.Step >= 0));
                    }
                    else
                    {
                        processes.ExecuteAll(actions);
                    }
                }
                catch (Exception e)
                {
                    processes = new Process[0];
                    _logger.Error(e);
                }

                startNext = startTime.Next((TimeSpan)(TimeOfDay)task.Period);

                if (startNext < DateTime.Now)
                {
                    startNext += period;
                }

                _logger.InfoFormat("Task completed. Next run time: {0:HH:mm:ss}", startNext);
            }
            else
            {
                _logger.InfoFormat("Next run time: {0:HH:mm:ss} [{1}/{2}]", startNext, task.StartTime, task.Period ?? "once");
            }

            startNext = startTime.Next((TimeSpan)(TimeOfDay)task.Period);

            if (startNext < DateTime.Now)
            {
                startNext += period;
            }

            var wakePeriod = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
            var wakeTime = (int)Math.Min((startNext - DateTime.Now).TotalMilliseconds, wakePeriod);

            _timer.Change(wakeTime, wakePeriod);

            _logger.InfoFormat("Leaving Tick. Next wake up time: {0:HH:mm:ss}", DateTime.Now + TimeSpan.FromMilliseconds(wakeTime));

            _ready = true;
        }
    }
}
