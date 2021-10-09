using System;
using System.Globalization;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HandsOnTestGoDigital.Auth;
using HandsOnTestGoDigital.Common;
using HandsOnTestGoDigital.Core;
using HandsOnTestGoDigital.Infraestructure;
using HandsOnTestGoDigital.Infraestructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace HandsOnTestGoDigital
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var key = "This is the demo key";
            services.AddCors();

            services.AddControllers().
                AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.WriteIndented = true;
                });
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x => {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });
            services.AddAuthorization();
            services.ConfigureRepositoryWrapper();
            services.AddSingleton<IJwtAuthenticationService>(new JwtAuthenticationService(key));
            services.AddMvc();

            AddSwagger(services);

            CultureInfo.CurrentCulture = new CultureInfo("es-ES");

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new InfraestructureModule());

            builder.Populate(services);

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"API {groupName}",
                    Version = groupName,
                    Description = "API",
                    Contact = new OpenApiContact
                    {
                        Name = "Jorge Luis Canchon Espinosa",
                        Email = "jorgecanchon@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/jorge-luis-canchon-espinosa-0312aa183"),
                    }
                });
            });
        }
    }
}
