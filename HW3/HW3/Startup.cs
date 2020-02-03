using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HW3
{
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern)
        {
            return builder.UseMiddleware<TokenMiddleware>(pattern);
        }
    }

    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        string pattern;
        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            this._next = next;
            this.pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            double x = 9;
            double y = 1;
            double z;
            z = Math.Sin(x) / x + Math.Log(5) / y + y * Math.Cos(y);
            await context.Response.WriteAsync($"sin({x}) / {x} + log(5) / {y} + {y} * cos({y}) = {z}");
        }
    }

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
            });

            app.Map("/index", Index);
            app.Map("/about", About);

            app.UseToken("55555555");

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private static void Index(IApplicationBuilder app)
        {
            double x = 9;
            double y = 1;
            double z;
            app.Use(async (context, next) =>
            {
                z = Math.Sin(x) / x + Math.Log(5) / y + y * Math.Cos(y);
                await context.Response.WriteAsync($"sin({x}) / {x} + log(5) / {y} + {y} * cos({y}) = {z}\n");
            });

            app.Run(async (context) =>
            {
                await Task.FromResult(0);
            });
        }
        private static void About(IApplicationBuilder app)
        {
            double x = 12;//Convert.ToDouble(Console.ReadLine());
            double y = 1;
            double z;

            app.Use(async (context, next) =>
            {
                z = Math.Sqrt(x) + Math.Pow(x, y) / Math.Sin(x) + Math.Tan(y) / y;
                await context.Response.WriteAsync($"sqrt({x}) + pow({x}, {y}) / sin({x} + tg({y}) / y = {z}\n");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("About");
            });
        }
    }
}
