using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using Microsoft.Owin.Hosting;

namespace Newbe.CQP.Framework.Docs
{
    class Program
    {
        static void Main(string[] args)
        {
            var wi = WindowsIdentity.GetCurrent();
            var wp = new WindowsPrincipal(wi);

            var runAsAdmin = wp.IsInRole(WindowsBuiltInRole.Administrator);
            if (!runAsAdmin)
            {
                // It is not possible to launch a ClickOnce app as administrator directly,
                // so instead we launch the app as administrator in a new process.
                var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase)
                {
                    UseShellExecute = true,
                    Verb = "runas"
                };

                // The following properties run the new process as administrator

                // Start the new process
                try
                {
                    Process.Start(processInfo);
                }
                catch (Exception)
                {
                    // The user did not allow the application to run as administrator
                    Console.WriteLine("尝试以管理员身份启动失败！");
                }

                // Shut down the current process
                Environment.Exit(1);
            }
            else
            {
                // We are running as administrator
                var httpLocalhost = "http://localhost:36524";
                using (WebApp.Start<Startup>(httpLocalhost))
                {
                    Process.Start(httpLocalhost);
                    Console.ReadLine();
                }
            }
        }
    }
}