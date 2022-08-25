using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Autofac;
using HumanResource.Config;
using MassTransit;
using Swashbuckle.AspNetCore.Swagger;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;
using HumanResource.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Presentation.RestApi
{
    public class Startup
    {
        private readonly ExpertDbContextConfig _expertDbContextConfig;
        private readonly string _ExpertAllowSpecificOrigins = "ExpertAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _expertDbContextConfig = Configuration.GetSection("ExpertDbContextConfig").Get<ExpertDbContextConfig>();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ExpertDbContext>(options => options.UseSqlServer(_expertDbContextConfig.ConnectionString));

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy(_ExpertAllowSpecificOrigins,
                    b =>
                    {
                        b.WithOrigins()
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            //services.AddControllers().AddFluentApiValidation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HumanResource Presentation RestApi", Version = "v1" });
                c.AddEnumsWithValuesFixFilters();
                c.AddFluentValidationRulesScoped();
            });

            //services.AddMassTransitHostedService();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
           // builder.RegisterModule(new GeneralBootstrapperModule()).RegisterModule(new BootstrapperHumanResourceModule(_HumanResourceConfig));
            //EndPointConfig.Config(builder, _HumanResourceConfig);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HumanResource Presentation RestApi v1"));
            app.UseCors(_ExpertAllowSpecificOrigins);
            app.UseRouting();
            app.UseAuthorization();
            //app.ConfigureExceptionHandling(exceptionLoggerRepository, _HumanResourceConfig);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}