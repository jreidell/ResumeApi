using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace RdlNetReact
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

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.Audience = "https://rdlnettesta0.auth0.com/api/v2/";
            //        options.Authority = "https://rdlnettesta0.auth0.com/oauth/token";
            //    });

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        // Clock skew compensates for server time drift.
            //        // We recommend 5 minutes or less:
            //        //ClockSkew = TimeSpan.FromMinutes(5),
            //        // Specify the key used to sign the token:
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("zlB8n7swrVFnmwkbvB7f-bXnlQzH1eYL_fydj56f1uWH6e2Wwr4H4O6lqPd5HaGE")),
            //        RequireSignedTokens = true,
            //        // Ensure the token hasn't expired:
            //        RequireExpirationTime = true,
            //        ValidateLifetime = true,
            //        // Ensure the token audience matches our audience value (default true):
            //        ValidateAudience = true,
            //        ValidAudience = "https://rdlnettesta0.auth0.com/api/v2/",
            //        // Ensure the token was issued by a trusted authorization server (default true):
            //        ValidateIssuer = true,
            //        ValidIssuer = "https://rdlnettesta0.auth0.com/oauth2/default"
            //    };
            //});

            //                     ValidIssuer = "https://rdlnettesta0.auth0.com/oauth/token",
            //                     ValidAudience = "https://rdlnettesta0.auth0.com/api/v2/",
            //                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("zlB8n7swrVFnmwkbvB7f-bXnlQzH1eYL_fydj56f1uWH6e2Wwr4H4O6lqPd5HaGE")) 
            //                 };
            //        });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
