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
    //IServiceProvider interface ile uygulama i�erisinde kullan�lan servisler yani uygulaman�n instance almas� gereken servislerin uygulama tan�t�lmas�n� bu interface �zerinden sa�l�yoruz
    //ISession ile web sunucu �zerinde oturum bilgileri saklan�yor
    //Web Client Web Server request att��� an itibari ile web server �zerinde o web clienta ait bir session oturum a��l�r ve o request i�in bir sessionID �retilir.Ki�i ayn� browserdan taray�c�dan yapt��� istekler i�in bu sessionID de�i�mez.Taki End User browser� kapat�p uygulama ile ileti�imi kesene kadar
  
    //...............

    //public delegate Task RequestDelegate(HttpContext context);
    //net core ortam�nda gelen isteklerin execute edilmesini �al��t�r�lmas�n� bu delegate sa�lar yani gelen istekleri async olarak yakalar i�erisinde HttpContext ile web uygulamas�na ait t�m nesneleri bar�nd�r�r.HttpContext i�erisinde temelde iki �nemli nesne bulunmaktad�r.Request di�eri ise response Request client taraftan 
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //servislerin tan�t�ld��� b�l�m,addcontrollerwithviews yani mvc uygulamas�
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();//html taraf�nda control+f5 ile a� kapa yapmadan sayfay� yenileme,controllerda yap�lan ayarlar i�in g�z�kmez
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //�zellikleri kazand�rd�k.uygulamay� in�a eden interface IApplicationBuilder.aya�a kald�r�rken �zellikler kazand�r�l�r.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Middleware ara yaz�l�m.Uygulamaya yap�lan isteklerde istek sonland�r�lmadan �nce araya girip uygulamaya yeni bir davran��� �al��ma zaman�nda ekleme i�lemi

            //rundan sonra bir middleware varsa sonland�r� middleware oldu�u i�in next methodu olmad��� i�in yani sonland�r�c� oldu�u i�in ba�ka hi� bir kod �al��maz

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
