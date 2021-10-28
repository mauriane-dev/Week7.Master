using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.Core.InterfaceRepositories;
using Week7.Master.MVC.Models;
using Week7.Master.RepositoryEF;
using Week7.Master.RepositoryEF.RepositoryEF;
using Week7.Master.RepositoryMock;

namespace Week7.Master.MVC
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
            services.AddControllersWithViews();

            services.AddTransient<ICounterService, CounterService>();
            //services.AddScoped<ICounterService, CounterService>();
            //services.AddSingleton<ICounterService, CounterService>();

            services.AddScoped<IBusinessLayer, MainBusinessLayer>();

            //services.AddTransient<IRepositoryCorsi, RepositoryCorsiMock>();
            //services.AddTransient<IRepositoryStudenti, RepositoryStudentiMock>();
            //services.AddTransient<IRepositoryLezioni, RepositoryLezioniMock>();
            //services.AddTransient<IRepositoryDocenti, RepositoryDocentiMock>();
            services.AddScoped<IRepositoryCorsi, RepositoryCorsiEF>();
            services.AddScoped<IRepositoryStudenti, RepositoryStudentiEF>();
            services.AddScoped<IRepositoryLezioni, RepositoryLezioniEF>();
            services.AddScoped<IRepositoryDocenti, RepositoryDocentiEF>();
            services.AddScoped<IRepositoryUtenti, RepositoryUtentiEF>();

            services.AddDbContext<MasterContext>(options =>
           {
               options.UseSqlServer(Configuration.GetConnectionString("EFConnection"));
           });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Login");
                    option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Forbidden");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Adm", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("User", policy => policy.RequireRole("User"));
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //L'ordine è importante
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
