using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp31.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreApp31
{
    public class Program
    {
        public static void Main(string[] args)
        {
             CreateHostBuilder(args).Build().Run();
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var exceptionlogcontext = services.GetRequiredService<VodafoneExceptionDbContext>();               
                
            //        var modelMetadata = services.GetRequiredService<IModelMetadataProvider>();

            //        CustomFilters.MyExceptionFilterAttribute myClass = new CustomFilters.MyExceptionFilterAttribute(modelMetadata, exceptionlogcontext);
                               
            //}
            //host.Run();
        }
        /// <summary>
        /// Define a contract between the Hosting Env (IIS/NGinx/Apache/Docker/Self-Contain) and
        /// the ASP.NET Core Application Hosting Process (dotnet.exe + ASP.NET Core Runtime)
        /// 1. Session Management
        /// 2. Identity Management
        /// 3. Dependency Management
        /// 4. Http Request Initialization
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}
