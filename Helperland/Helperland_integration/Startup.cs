using Helperland_integration.Controllers;
using Helperland_integration.Data;
using Helperland_integration.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_integration
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
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
            });
            services.AddControllersWithViews();
            services.AddDbContext<HelperlandContext>();
            services.AddScoped<UserRegistration>();
            services.AddScoped<LoginRepository>();
            services.AddScoped<ContactRepository>();
            services.AddScoped<ForgotPassword>();
            services.AddScoped<BookingRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<HelperRepository>();
            services.AddScoped<AdminRepository>();
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif       
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

            app.UseSession();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=index}/{id?}");
                    
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
