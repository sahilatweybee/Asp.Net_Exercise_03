using Asp.Net_Exercise_03.DataBase;
using Asp.Net_Exercise_03.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03
{
    public class Startup
    {
        private readonly IConfiguration _Configuration = null;
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<PartyDbContext>(options => options.UseSqlServer(_Configuration.GetConnectionString("PartyDB")));
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            services.AddTransient<IPartyRepository, PartyRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IAssignPartyRepository, AssignPartyRepository>();
            services.AddTransient<IProductRateRepository, ProductRateRepository>();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Party",
                    pattern: "{controller=Party}/{action=PartyList}/{id?}");
            });
        }
    }
}
