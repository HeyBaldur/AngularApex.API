using AngularApex.API.Extensions;
using AngularApex.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularApex.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add health checks
            services.AddHealthChecks();

            // DB Connection
            services.AddDbContext<DataContext>
               (x => x.UseSqlServer(
                   Configuration.GetConnectionString("DefaultCnx"),
                   b => b.MigrationsAssembly("AngularApex.API")));

            services.AddApplicationInsightsTelemetry();
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AngularApex.API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.
                        AllowAnyOrigin().
                        AllowAnyMethod().
                        AllowAnyHeader();
                    });
            });

            // Add Automapper
            services.AddAutoMapper(typeof(Startup));

            // Configurations of services
            AddDependencies.Dependencies(services);

            // Token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero,
                        RequireExpirationTime = false
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AngularApex.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
