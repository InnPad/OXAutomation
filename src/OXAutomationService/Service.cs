using System.ServiceProcess;

namespace OXAutomation
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();

            InitializeService();
        }

        protected override void OnStart(string[] args)
        {
            Start();
        }

        protected override void OnStop()
        {
            Stop();
        }
    }
}
