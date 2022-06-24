using Framework.AssemblyHelper;
using Framework.DependencyInjection;
using Framework.Facade;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Books.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var assemblyHelper = new AssemblyHelper(nameof(Books));
            Registrar(services, assemblyHelper);

            var mvcBuilder = services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
            })
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            AddControllers(assemblyHelper, mvcBuilder);

            mvcBuilder.AddControllersAsServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Books.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{Controller=swagger}/{action=Index.html}");
            });

            app.UseMvc();
        }


        private void Registrar(IServiceCollection services, AssemblyHelper assemblyHelper)
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("AppSettings.json", true, true)
                .AddJsonFile($"AppSettings.{Environment.EnvironmentName}.json", true, true);

            var connectionString = builder.Build().GetConnectionString("DefaultConnection");
            var registrars = assemblyHelper.GetInstanceByInterface(typeof(IRegistrar));
            foreach (IRegistrar registrar in registrars)
                registrar.Register(services, connectionString);

            //services.AddDbContext<HRContext>(op =>
            //{
            //    op.UseSqlServer(connectionString, z => z.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds));

            //    //op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //}, ServiceLifetime.Transient);

        }


        private static void AddControllers(AssemblyHelper assemblyHelper, IMvcBuilder mvcBuilder)
        {
            var controllerAssemblies = assemblyHelper.GetAssemblies(typeof(FacadeCommandBase)).Distinct();

            foreach (var apiControllerAssembly in controllerAssemblies)
                mvcBuilder.AddApplicationPart(apiControllerAssembly);

            controllerAssemblies = assemblyHelper.GetAssemblies(typeof(FacadeQueryBase)).Distinct();
            foreach (var apiControllerAssembly in controllerAssemblies)
                mvcBuilder.AddApplicationPart(apiControllerAssembly);
        }
    }
}
