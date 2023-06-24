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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mercadorias.Presentation.Configurations;
using System.IO;

namespace Mercadorias.Presentation
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
            //definir que o modo de navegação do projeto web é MVC (Controllers e Views)
            services.AddControllersWithViews();
            //services.AddControllersWithViews().AddNewtonsoftJson();

            DependencyInjectionConfiguration.ConfigureServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //autenticação no projeto..
            app.UseCookiePolicy();
            app.UseAuthentication();
         

            app.UseHttpsRedirection();

         
            app.UseRouting();

            //para poder fazer o download do pdf
            app.UseStaticFiles();

            //mapeando a página inicial do projeto
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Mercadoria}/{action=Create}"
                );
            });

        }
    }
}
