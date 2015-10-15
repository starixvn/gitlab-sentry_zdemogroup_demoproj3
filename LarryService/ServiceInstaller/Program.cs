using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Collections;
using System.Diagnostics;

namespace ServiceInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"D:\LarryService\LarryService.exe";
            string serviceName = "LarryService";
            string machineName = "10.19.10.105";

            var isServiceExisting = IsServiceExisting(machineName, serviceName);

            if (isServiceExisting)
            {
                UninstallRemoteService(machineName, serviceName, fileName);
            }
            else
            {
                InstallRemoteService(machineName, serviceName, fileName);
            }
        }

        private static void InstallRemoteService(string machineName, string serviceName, string executableFilePath)
        {
            string fileName = "sc.exe";
            string arguments = string.Format(@"\\{0} create {1} binpath= {2}", machineName, serviceName, executableFilePath);

            ProcessStartInfo startInfo = new ProcessStartInfo(fileName, arguments);
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        private static void UninstallRemoteService(string machineName, string serviceName, string executableFilePath)
        {
            string fileName = "sc.exe";
            string arguments = string.Format(@"\\{0} delete {1} binpath= {2}", machineName, serviceName, executableFilePath);

            ProcessStartInfo startInfo = new ProcessStartInfo(fileName, arguments);
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        private static bool IsServiceExisting(string machineName, string serviceName)
        {
            bool isExisting = ServiceController.GetServices(machineName)
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
