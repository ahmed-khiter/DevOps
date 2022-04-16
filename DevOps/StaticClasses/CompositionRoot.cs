using DevOps.Helper;
using DevOps.Interfaces.Auth;
using DevOps.Services.AuthManagement;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DevOps.StaticClasses
{
    public class CompositionRoot
    {
        public static void InjectDependencies(IServiceCollection services)
        {
            //Allow Domain x Talk to you 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
                });
            });

            //JWt injection
            services.AddScoped<IJwt, JwtToken>();


        }

        public static void InjectAuthantication(IServiceCollection services, IConfiguration Configuration)
        {

            //Mapping appsettings with class JWT.
            services.Configure<JWT>(Configuration.GetSection("JWT"));

            //Prepare schema of Authentication of system
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                };
            }).AddCookie(options =>
            {
                options.LoginPath = "/account/google-login";
            });


        }

    }

}
