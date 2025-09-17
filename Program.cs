using System;
using System.ServiceProcess;
using System.Management;
using System.IO;

namespace NvidiaServiceDisabler
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] services = { "NVDisplay.ContainerLocalSystem", "NvTelemetryContainer" };
            string logPath = @"C:\gpu_shutdown_log.txt";

            foreach (string serviceName in services)
            {
                try
                {
                    // Stoppa tjänsten
                    ServiceController sc = new ServiceController(serviceName);
                    if (sc.Status != ServiceControllerStatus.Stopped &&
                        sc.Status != ServiceControllerStatus.StopPending)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                        File.AppendAllText(logPath, $"{DateTime.Now}: Stoppade {serviceName}\n");
                    }
                    else
                    {
                        File.AppendAllText(logPath, $"{DateTime.Now}: {serviceName} redan stoppad\n");
                    }

                    // Ändra starttyp till Disabled
                    string wmiPath = $"Win32_Service.Name='{serviceName}'";
                    using (ManagementObject service = new ManagementObject(wmiPath))
                    {
                        service.InvokeMethod("ChangeStartMode", new object[] { "Disabled" });
                        File.AppendAllText(logPath, $"{DateTime.Now}: Satte {serviceName} till Disabled\n");
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText(logPath, $"{DateTime.Now}: Fel vid {serviceName}: {ex.Message}\n");
                }
            }

            Console.WriteLine("✅ NVIDIA-tjänster stoppade och inaktiverade.");
        }
    }
}