using System;
using System.IO;
using System.Linq;
using System.Reflection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using StringCalculatorApi.Controllers;
using Swashbuckle.AspNetCore.Swagger;

namespace StringCalculatorApi
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
            services.AddApplicationInsightsTelemetry(Configuration["ApplicationInsights:InstrumentationKey"]);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            services.AddApiVersioning(o => o.ReportApiVersions = true);

            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescription => apiDescription.First());

                for (int version = 1; version <= 2; version++)
                {
                    c.SwaggerDoc("v" + version, new Info
                    {
                        Version = "v" + version,
                        Title = "StringCalculator API",
                        Description = "API para sumar números",
                        Contact = new Contact
                        {
                            Name = "Adriana Peñate",
                            Url = "https://github.com/adripsau/"
                        }
                    });
                }

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)) + ".xml";
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("File", "https://localhost:5001/health");
            });

            services.AddHealthChecks()
                .AddCheck("File write permissions", new ExampleHealthCheck());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(config => config.UIPath = "/health-ui");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StringCalculator API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "StringCalculator API V2");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

}

