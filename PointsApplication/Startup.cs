using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PointsApplication.Models;
using System;

namespace PointsApplication
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        [Obsolete]
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            var appsettings = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
            Configuration = appsettings;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConnectionStrings con = new ConnectionStrings();
            Configuration.Bind("ConnectionStrings", con);
            services.AddSingleton(con); //DI Singleton
            services.AddControllers(); // используем контроллеры без представлений
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ".Net Core 3 Web API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ".Net Core 3 Web API V1");
            });
        }
    }
}