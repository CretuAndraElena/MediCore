using System;
using DataDomain;
using DataPersistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Repositories;
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
                services.AddTransient<ICrudRepository<Schedule>, CrudRepository<Schedule>>();
                services.AddTransient<ICrudRepository<Medic>, CrudRepository<Medic>>();
                services.AddTransient<ICrudRepository<Patient>, CrudRepository<Patient>>();
                services.AddTransient<ICrudRepository<Diagnosis>, CrudRepository<Diagnosis>>();
                services.AddTransient<ICrudRepository<Person>, CrudRepository<Person>>();
            var conection = @"Server = .\SQLEXPRESS; Database = MediCore; Trusted_Connection = true;";
                services.AddDbContext<DataBaseContext>(opt => opt.UseSqlServer(conection));
                services.AddMvc();
                services.AddSession(options =>
                {
                    // Set a short timeout for easy testing.
                    options.IdleTimeout = TimeSpan.FromSeconds(100);
                    options.Cookie.HttpOnly = true;
                    options.IOTimeout=TimeSpan.FromMinutes(30);
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
                app.UseSession();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseBrowserLink();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }

                app.UseStaticFiles();

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Persons}/{action=Login}/{id?}");
                });
            }
    }
}
