using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            /*builder.Services.AddApplicationPersistence(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddApplicationApi();
            builder.Services.AddSwagger();*/
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(o =>
                    {
                        o.TokenValidationParameters = new TokenValidationParameters
                        {
                            ClockSkew = TimeSpan.FromMinutes(60),
                            ValidateLifetime = true,
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = builder.Configuration["JwtOptions:ValidIssuer"],
                            ValidAudience = builder.Configuration["JwtOptions:ValidAudience"],
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"]!))
                        };
                        o.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Console.WriteLine(context.Exception); // Log the exception
                                return Task.CompletedTask;
                            }
                        };
                    });
            builder.Services.AddAuthorization(o =>
            {
                o.AddPolicy("AdminActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, UserRole.Admin.ToString());
                });
            });
            builder.Services.AddCors(o => o.AddPolicy("AddCors", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AddCors");

            app.UseHttpsRedirection();
            app.UseRequestLocalization();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
