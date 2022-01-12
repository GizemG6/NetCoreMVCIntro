using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCIntro
{
    //IServiceProvider interface ile uygulama içerisinde kullanýlan servisler yani uygulamanýn instance almasý gereken servislerin uygulama tanýtýlmasýný bu interface üzerinden saðlýyoruz
    //ISession ile web sunucu üzerinde oturum bilgileri saklanýyor
    //Web Client Web Server request attýðý an itibari ile web server üzerinde o web clienta ait bir session oturum açýlýr ve o request için bir sessionID üretilir.Kiþi ayný browserdan tarayýcýdan yaptýðý istekler için bu sessionID deðiþmez.Taki End User browserý kapatýp uygulama ile iletiþimi kesene kadar
  
    //...............

    //public delegate Task RequestDelegate(HttpContext context);
    //net core ortamýnda gelen isteklerin execute edilmesini çalýþtýrýlmasýný bu delegate saðlar yani gelen istekleri async olarak yakalar içerisinde HttpContext ile web uygulamasýna ait tüm nesneleri barýndýrýr.HttpContext içerisinde temelde iki önemli nesne bulunmaktadýr.Request diðeri ise response Request client taraftan 
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //servislerin tanýtýldýðý bölüm,addcontrollerwithviews yani mvc uygulamasý
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();//html tarafýnda control+f5 ile aç kapa yapmadan sayfayý yenileme,controllerda yapýlan ayarlar için gözükmez
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //özellikleri kazandýrdýk.uygulamayý inþa eden interface IApplicationBuilder.ayaða kaldýrýrken özellikler kazandýrýlýr.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Middleware ara yazýlým.Uygulamaya yapýlan isteklerde istek sonlandýrýlmadan önce araya girip uygulamaya yeni bir davranýþý çalýþma zamanýnda ekleme iþlemi

            //rundan sonra bir middleware varsa sonlandýrý middleware olduðu için next methodu olmadýðý için yani sonlandýrýcý olduðu için baþka hiç bir kod çalýþmaz

                ////configure middleware using IApplicationBuilder here..

                //app.Run(async (context) =>
                //{
                //    await context.Response.WriteAsync("Hello World!");

                //});

                //// other code removed for clarity.. 
            
        



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
