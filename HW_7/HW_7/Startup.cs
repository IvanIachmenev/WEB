using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW_7.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HW_7
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Server=(localdb)\\MSSQLlocaldb;Database=task_7db;Trusted_Connection=True;";
            services.AddDbContext<MobileContext>(options => options.UseSqlServer(con));
            services.AddControllers(); 
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
