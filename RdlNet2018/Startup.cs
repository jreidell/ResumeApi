using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RdlNet2018.Contracts;
using RdlNet2018.Data;
using RdlNet2018.Repos;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace RdlNet2018
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add EF services to the services container.
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<RDL2018Context>(options =>
                  options.UseSqlServer(Configuration["DefaultConnection"]));

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<ICareerInfoRepository, CareerInfoRepository>();

            services.AddScoped<IJobSkillRepository, JobSkillRepository>();

            services.AddScoped<IWorkHistoryRepository, WorkHistoryRepository>();

            services.AddScoped<IWorkHistoryDetailRepository, WorkHistoryDetailRepository>();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddSingleton<IWorkHistoryDetailRepository, WorkHistoryDetailRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Reidell.net 2018 - RdlNet2018 Web API",
                    Description = "ASP.NET Core Web API - RdlNet2018",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Reidell.net 2018 - RdlNet2018 Web API", Email = "joe@reidell.net", Url = "reidell.net" }
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            if (!Configuration["DisableSwagger"].Equals("true", StringComparison.InvariantCultureIgnoreCase))
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
