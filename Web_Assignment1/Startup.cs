using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment1.Data;
using Microsoft.EntityFrameworkCore;
using Web_Assignment1.Models;
using Microsoft.AspNetCore.Identity;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;


namespace Web_Assignment1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(10);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;

            });

            services.AddDbContext<PeopleDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<PeopleDbContext>();


            services.AddRazorPages();
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
                .AddV8();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseReact(config =>
                {
                    //config.AddScript("file");
                });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern:"{Controller=Home}/{action=Index}/{id?}");

               

                endpoints.MapControllerRoute(
                    name: "Doctor",
                    pattern: "/FeverCheck",
                    defaults: new { Controller = "Doctor", action = "FeverCheck" }
                    );

                endpoints.MapControllerRoute(
                   name: "Game",
                   pattern: "/NumberGuessingGame",
                   defaults: new { Controller = "Game", action = "NumberGuessingGame" }
                   );

                endpoints.MapControllerRoute(
                   name: "People",
                   pattern: "/PeopleIndex",
                   defaults: new { Controller = "People", action = "PeopleIndex" }
                   );
                endpoints.MapRazorPages();
                //endpoints.MapControllerRoute(
                //   name: "Ajax",
                //   pattern: "/Ajax",
                //   defaults: new { Controller = "Ajax", action = "Ajax" }
                //   );
            });
        }
    }
}
