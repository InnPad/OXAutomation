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
            StartImplementation();
        }

        protected override void OnStop()
        {
            StopImplementation();
        }
    }
}
