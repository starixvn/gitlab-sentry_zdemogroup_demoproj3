using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Collections;

namespace ServiceInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"D:\Projects\demoproj3\LarryService\LarryService\bin\Debug\LarryService.exe";
            string serviceName = "LarryService";

            var isServiceExisting = IsServiceExisting(serviceName);

            if (isServiceExisting)
            {
                UninstallService(fileName);
            }
            else
            {
                InstallService(fileName);
            }
        }

        private static bool IsServiceExisting(string serviceName)
        {
            bool isExisting = ServiceController.GetServices()
                                .Any(s => s.ServiceName.Equals(serviceName, StringComparison.InvariantCultureIgnoreCase));

            return isExisting;
        }

        private static void InstallService(string fileName)
        {
            ManagedInstallerClass.InstallHelper(new[] { fileName });
        }

        private static void UninstallService(string fileName)
        {
            ManagedInstallerClass.InstallHelper(new[] { "/u", fileName });
        }
    }
}
