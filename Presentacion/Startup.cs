using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Negocio.Helpers;
using Negocio.Services;
using Negocio.Services.Interfaces;
using Negocio.Util;
using Presentacion.Models;

namespace Presentacion {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();

            services.AddCors();
            services.AddControllers();
            // configure strongly typed settings object -> JWT
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.Configure<AppSettingsBD>(Configuration.GetSection("BDConection"));
            services.Configure<BedeliasAppSettings>(Configuration.GetSection("ApiBedelia"));

            //Inyeccion  de Depedencias
            services.AddDbContext<ContextoGeneral>();
            services.AddDbContext<ContextoParticular>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMultyTenancyService, MultyTenancyService>();
            services.AddScoped<IDocenteService, DocenteService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IFacultadesService, FacultadService>();
            services.AddScoped<IConversacionService, ConversacionService>();
            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<IEncuestaService, EncuestaService>();
			services.AddScoped<IEvaluacionService, EvaluacionService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IForoService, ForoService>();
            services.AddScoped<IDiscusionService, DiscusionService>();
            services.AddScoped<ISQLUtil, SQLUtil>();
            services.AddScoped<ICalendarioService, CalendarioService>();
            services.AddScoped<IClaseService, ClaseService>();

			services.AddHttpContextAccessor();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddRazorPages();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
             name: "default",
             pattern: "{controller=home}/{action=Index}/{id?}");
            });
        }
    }
}
