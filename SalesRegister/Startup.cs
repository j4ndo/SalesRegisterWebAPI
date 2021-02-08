using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SalesRegisterWebAPI.Application;
using SalesRegisterWebAPI.Domain.DTO;
using SalesRegisterWebAPI.Domain.Models;
using SalesRegisterWebAPI.Domain.Repository;
using SalesRegisterWebAPI.Infra.Contexts;
using SalesRegisterWebAPI.Infra.Repository;
using System;

namespace SalesRegisterWebAPI
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
            services.AddDbContext<SalesRegisterContext>(opt => opt.UseInMemoryDatabase("SalesRegister"));
            services.AddScoped<ISalesRegisterRepository, SalesRegisterRepository>();
            services.AddScoped<ISalesRegisterApplication, SalesRegisterApplication>();


            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ); ;

            
            AutoMapperConfig(services);
            // Register the Swagger generator, defining 1 or more Swagger documents
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sales Register API",
                    Description = "Sales Register Application using ASP.NET Core Web API",
                    TermsOfService = new Uri("https://www.linkedin.com/in/janderson-fa/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Janderson Fonseca",
                        Email = "janderson-fonseca@hotmail.com",
                        Url = new Uri("https://www.linkedin.com/in/janderson-fa/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
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

            app.UseHttpsRedirection();

            app.UseRouting();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sales Register API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AutoMapperConfig(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SalesRegisterDTO, SalesRegister>();
                cfg.CreateMap<SellerDTO, Seller>();
                cfg.CreateMap<VehicleDTO, Vehicle>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
