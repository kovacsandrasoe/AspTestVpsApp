using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspTestVpsApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel(o => {
                        o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(5);
                        o.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(5);
                        o.Listen(IPAddress.Any, 80);
                        o.Listen(IPAddress.Any, 443);
                    });
                });
    }
}
