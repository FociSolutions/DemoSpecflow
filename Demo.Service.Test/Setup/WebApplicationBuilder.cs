using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace Demo.Service.Test.Setup
{
    public class WebApplicationBuilder
    {
        private IWebHost _host;


        public WebApplicationBuilder()
        {

        }

        public void StartServer()
        {
            _host = CreateHostBuilder().Build();
            _host.Start();
            Console.WriteLine("Server started.");
        }

        public void StopServer()
        {
            _host?.Dispose();
            Console.WriteLine("Server stopped.");
        }

        public IWebHostBuilder CreateHostBuilder() =>
            WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>();
    }
}
