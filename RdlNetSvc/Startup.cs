using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RdlNetSvc.Common.Contracts;
using RdlNetSvc.Common.Repos;
using RdlNetSvc.Data;
using Swashbuckle.AspNetCore.Swagger;

namespace RdlNetSvc
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
            // Add service and create Policy with options
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Environment.GetEnvironmentVariable("Auth0:Authority");
                options.Audience = Environment.GetEnvironmentVariable("Auth0:Audience");
                //options.RequireHttpsMetadata = false;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add EF services to the services container.
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<RDL2018Context>(options =>
                  options.UseSqlServer(Environment.GetEnvironmentVariable("Data:ConnectionStrings:DefaultConnection")));

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<ICareerInfoRepository, CareerInfoRepository>();

            services.AddScoped<IJobSkillRepository, JobSkillRepository>();

            services.AddScoped<IWorkHistoryRepository, WorkHistoryRepository>();

            services.AddScoped<IWorkHistoryDetailRepository, WorkHistoryDetailRepository>();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Reidell.net - Resume Web API Microservice",
                    Description = "ASP.NET Core Web API Microservice - RdlNetSvc",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Reidell.net - Resume Web API Microservice", Email = "joe@reidell.net", Url = "reidell.net" }
                });
            });

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
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();

            if (!Environment.GetEnvironmentVariable("DisableSwagger").Equals("true", StringComparison.InvariantCultureIgnoreCase))
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reidell.net 2018 - RdlNet2018 Web API");
                });
            }

        }
    }
}
