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
			System.Threading.Thread.Sleep(60000);
        }

        protected override void OnStop()
        {
        }
    }
}
