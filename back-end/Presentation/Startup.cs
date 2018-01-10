using System;
using DataDomain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DataPersistence;
using Repositorys;
using Swashbuckle.AspNetCore.Swagger;

namespace Presentation
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
                services.AddTransient<IDataBaseContext, DataBaseContext>();
                services.AddTransient<IRepository<Schedule>, ScheduleRepository>();
                services.AddTransient<IRepository<Medic>, MedicRepository>();
                services.AddTransient<IRepository<Patient>, PatientRepository>();
            var conection = @"Server = .\SQLEXPRESS; Database = MediCore; Trusted_Connection = true;";
                services.AddDbContext<DataBaseContext>(opt => opt.UseSqlServer(conection));
                services.AddMvc();
            // Adds a default in-memory implementation of IDistributedCache.
                services.AddDistributedMemoryCache();

                services.AddSession(options =>
                {
                    // Set a short timeout for easy testing.
                    options.IdleTimeout = TimeSpan.FromSeconds(10);
                    options.Cookie.HttpOnly = true;
                });
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "My Category API", Version = "v1" });
                });
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Category V1");
                });
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                app.UseSession();

                app.UseDefaultFiles();
                app.UseStaticFiles();

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=People}/{action=Login}");
                });
        }
    }
}
