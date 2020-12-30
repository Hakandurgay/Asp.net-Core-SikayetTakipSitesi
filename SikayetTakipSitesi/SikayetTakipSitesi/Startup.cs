using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SikayetTakipSitesi.Data;

namespace SikayetTakipSitesi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();                  //Session için eklendi
            services.AddDistributedMemoryCache();   //Session için eklendi

            //çoklu dil desteði
            //localization
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";   
            });

            services
                .AddMvc()
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.AddControllersWithViews();
            services.AddDbContext<SikayetDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SikayetDbContext")));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         
            //standart routing mekanizmasý ile dil desteði kullanmak
            //kullanýlacak diller
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-Us"),
            };

            //default dilin tanýmlanmasý
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                SupportedCultures = supportedCultures,
                SupportedUICultures=supportedCultures,
                DefaultRequestCulture=new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR")
            });

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
            app.UseSession();// session için eklendi
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=BrandDetail}/{action=Index}/{id?}");
            });

        }
    }
}
