using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private IConfiguration Configuration;
        public Startup(IConfiguration config) => Configuration = config;
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<MigrationsManager>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IGenericRepository<ContactDetails>, GenericRepository<ContactDetails>>();
            services.AddTransient<IGenericRepository<ContactLocation>, GenericRepository<ContactLocation>>();
            var conString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<EFDatabaseContext>(options => options.UseSqlServer(conString));
            var conCustString = Configuration["ConnectionStrings:CustomerConnection"];
            services.AddDbContext<EFCustomerContext>(options => options.UseSqlServer(conCustString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EFDatabaseContext prodCtx, EFCustomerContext custCtx)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            if (env.IsDevelopment())
            {
                SeedData.Seed(prodCtx);
                SeedData.Seed(custCtx);
            }
        }
    }
}
