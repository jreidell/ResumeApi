using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RdlNet2018.Common.Contracts;
using RdlNet2018.Common.Repos;
using RdlNet2018.Data;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace RdlMvcUI
{
    public class Startup
    {
        private bool disableJWT = true;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            disableJWT = Configuration["DisableJWT"].Equals("true", StringComparison.InvariantCultureIgnoreCase);

            if (!disableJWT)
            {
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.Authority = Environment.GetEnvironmentVariable("rdn_UrlNoTrailingSlash");
                    options.Audience = Environment.GetEnvironmentVariable("rdn_Audience");
                    //options.RequireHttpsMetadata = false;
                });
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add EF services to the services container.
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<RDL2018Context>(options =>
                  options.UseSqlServer(Configuration["Data:ConnectionStrings:DefaultConnection"]));

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
                    Title = "Reidell.net - MVC Resume Viewer",
                    Description = "ASP.NET Core MVC/Web API ",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Reidell.net - MVC Resume Viewer", Email = "joe@reidell.net", Url = "reidell.net" }
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (!disableJWT)
                app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            if (!Configuration["DisableSwagger"].Equals("true", StringComparison.InvariantCultureIgnoreCase))
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reidell.net - MVC Resume Viewer");
                });
            }
        }
    }
}
