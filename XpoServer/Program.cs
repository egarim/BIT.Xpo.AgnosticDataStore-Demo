using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace XpoServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Comment this license to hide the state of your license
            BIT.Core.LicenseManager.EnableLogToConsole = true;
            BIT.Core.LicenseManager.EnableLogToFile = true;



            //Use the following line to load your license
            //LicenseManager.LoadLicense("BIT.Xpo.AgnosticDataStore.Server", File.ReadAllText("InvalidLicense.txt"));

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
