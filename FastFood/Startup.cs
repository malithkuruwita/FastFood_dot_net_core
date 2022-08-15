using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFood.Data.Repositories;
using FastFood.Data;
using FastFood.Data.Interfaces;
using FastFood.Data.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace FastFood
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            


            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IFoodRepository, FoodRepository>();

           

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
           
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();

           

            app.UseMvc(routes => {

                routes.MapRoute(
                    name:"default",
                    template:"{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "fooddescription",
                   template: "FastFood/Details/{foodId?}",
                   defaults: new { Controller = "FastFood", action = "Details" });

                routes.MapRoute(
                name:"FoodDetails",
                template:"FastFood/{action}/{categoryid?}",
                defaults: new { Controller="FastFood",action="List"});
                
            });

           // DbInitializer.Seed(app);
        }
    }
}
