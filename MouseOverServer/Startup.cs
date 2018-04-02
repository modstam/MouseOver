using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MouseOverServer.Infrastructure.Managers;
using MouseOverServer.Infrastructure.Services;
using System.Runtime.InteropServices;

namespace MouseOverServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMouseManager, MouseManager>();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                services.AddTransient<IMouseService, WindowsMouseService>();
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //TODO: Implement Linux support
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //TODO: Implement OSX support
            }


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
