using System.ServiceProcess;

namespace LarryService
{
    public partial class LarryService : ServiceBase
    {
        public LarryService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

        }

        protected override void OnStop()
        {
        }
    }
}
