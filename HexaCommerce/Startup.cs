using Hexa.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using Hexa.Service.Mapper;
using System;
using Hexa.Core.Infrastructure;
using Hexa.Service.DependencyRegistrar;

namespace HexaCommerce
{
    public class Startup
    {
        private IHostingEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration,
            IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HexaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //register AutoMapper
            services.RegisterMapper();

            services.AddMvc().AddJsonOptions(options =>
             {
                 options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
             });
            
            var physicalProvider = _hostingEnvironment.ContentRootFileProvider;
            var embeddedProvider = new EmbeddedFileProvider(Assembly.GetEntryAssembly());
            var compositeProvider = new CompositeFileProvider(physicalProvider, embeddedProvider);
            services.AddSingleton<IFileProvider>(compositeProvider);

            // register dependancy injection
            services.RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables();

            //use the authentication  
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                     name: "areaRoute",
                     template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
