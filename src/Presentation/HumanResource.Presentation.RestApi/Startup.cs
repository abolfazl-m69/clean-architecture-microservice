using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Autofac;
using MassTransit;
using Swashbuckle.AspNetCore.Swagger;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;

namespace HumanResource.Presentation.RestApi
{
    public class Startup
    {
        //private readonly HumanResourceConfig _HumanResourceConfig;
        private readonly string _HumanResourceAllowSpecificOrigins = "HumanResourceAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           // _HumanResourceConfig = Configuration.GetSection("HumanResourceConfig").Get<HumanResourceConfig>();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddDbContext<HumanResourceDbContext>(options => options.UseNpgsql(_HumanResourceConfig.ConnectionString));

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy(_HumanResourceAllowSpecificOrigins,
                    b =>
                    {
                        b.WithOrigins()
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            //services.AddEntityFrameworkNpgsql();

            //services.AddControllers().AddFluentApiValidation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HumanResource Presentation RestApi", Version = "v1" });
                c.AddEnumsWithValuesFixFilters();
                c.AddFluentValidationRulesScoped();
            });

            services.AddMassTransitHostedService();
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
            app.UseCors(_HumanResourceAllowSpecificOrigins);
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