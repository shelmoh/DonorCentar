using DonorCentar.WebAPI.Filters;
using DonorCentar.WebAPI.Database;
using DonorCentar.WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.WebAPI
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
            
            services.AddDbContext<BazaPodataka>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("database")));

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen();
            services.AddControllers(x =>
            {
                x.Filters.Add<ErrorFilter>();
            });


            services.AddScoped<IKorisniciService, KorisniciService>();

            services.AddScoped<IKantonService, KantonService>();

            services.AddScoped<IGradService, GradService>();

            services.AddScoped<ITipKorisnikaService, TipKorisnikaService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DonorCentarAPI");
            });
        }
    }
}
