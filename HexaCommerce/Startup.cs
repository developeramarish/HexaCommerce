using AutoMapper;
using Hexa.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using Hexa.Core.Infrastructure;

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

            services.AddAutoMapper();
            services.AddMvc().AddJsonOptions(options =>
             {
                 options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
             });

            services.RegisterServices();

            //services.AddSingleton(typeof(IHexaRepository<>), typeof(HexaRepository<>));
            //services.AddTransient<IHexaRepository<CustomerRole>, HexaRepository<CustomerRole>>();
            //services.AddTransient<IHexaRepository<CustomerCustomerRole>, HexaRepository<CustomerCustomerRole>>();
            //services.AddTransient<IHexaRepository<TokenManager>, HexaRepository<TokenManager>>();
            //services.AddTransient<IHexaRepository<Category>, HexaRepository<Category>>();
            //services.AddTransient<IHexaRepository<Log>, HexaRepository<Log>>();
            //services.AddTransient<IHexaRepository<Picture>, HexaRepository<Picture>>();
            //services.AddTransient<IHexaRepository<Product>, HexaRepository<Product>>();
            //services.AddTransient<IHexaRepository<ProductCategoryMapping>, HexaRepository<ProductCategoryMapping>>();
            //services.AddTransient<IHexaRepository<ProductPictureMapping>, HexaRepository<ProductPictureMapping>>();

            //services.AddTransient<ICustomerService, CustomerService>();
            //services.AddTransient<ICategoryService, CategoryService>();
            //services.AddTransient<ILogService, LogService>();
            //services.AddTransient<IPictureService, PictureService>();
            //services.AddTransient<IProductService, ProductService>();

            var physicalProvider = _hostingEnvironment.ContentRootFileProvider;
            var embeddedProvider = new EmbeddedFileProvider(Assembly.GetEntryAssembly());
            var compositeProvider = new CompositeFileProvider(physicalProvider, embeddedProvider);
            services.AddSingleton<IFileProvider>(compositeProvider);
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
