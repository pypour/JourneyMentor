using Application;
using Application.Commands.Airports;
using Application.Commands.Dto;
using Application.Commands.Flights;
using Application.Configs;
using Application.Queries.Airports.SearchAirport;
using Application.Queries.Flights.SearchFlight;
using Domain.Airports;
using Domain.Flights;
using Infrastructure;
using Infrastructure.Database;
using Infrastructure.Domain.Airports;
using Infrastructure.Domain.Flights;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace API
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
            services.Configure<AviationStackOption>(Configuration.GetSection("AviationStackOption"));

            services.AddInfrastructure(Configuration);

            services.AddApplication();

            services.AddMemoryCache();
            services.AddControllers();

            services.AddHttpClient();
            services.AddSingleton<HttpClientHelper>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Journey Mentor",
                    Version = "v1",
                    Description = ".NET Core REST API",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Journey Mentor");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<DataContext>();

                // Here is the migration executed
                dbContext.Database.Migrate();
            }
        }
    }
}
