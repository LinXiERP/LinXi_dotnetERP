using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinXi_ApiGateWay.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

namespace LinXi_ApiGateWay
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
            services.AddAuthentication("Bearer")
                 .AddIdentityServerAuthentication("ApiGateWay", option =>
                 {
                     option.ApiName = "api2";
                     option.RequireHttpsMetadata = false;
                     option.Authority = "http://localhost:56568";
                     option.JwtValidationClockSkew = TimeSpan.FromSeconds(0);
                 });

            services.AddOcelot(new ConfigurationBuilder()
                    .AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true)
                    .Build()).AddConsul();
            services.AddMyCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowCors");
            app.UseOcelot().Wait();
            app.UseAuthorization();
        }
    }
}