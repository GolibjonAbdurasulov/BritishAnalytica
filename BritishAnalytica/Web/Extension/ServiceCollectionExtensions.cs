using System;
using System.Reflection;
using System.Text;
using Castle.Core.Configuration;
using DatabaseBroker;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Interfaces;
using Services.Services;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Web.Extension;

public static class ServiceCollectionExtensions
{

    public static void AddCustomService(this IServiceCollection services)
    {
        //services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        //Folder Name: IUSerService
        services.AddScoped<IUserService, UserService>();
    }

    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            // options.TokenValidationParameters = new TokenValidationParameters
            // {
            //     ValidateIssuer = true,
            //     ValidateAudience = false,
            //     ValidateLifetime = true,
            //     ValidateIssuerSigningKey = true,
            //     ValidIssuer = configuration["Jwt:Issuer"],
            //     ValidAudience = configuration["JWT:Audience"],
            //     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
            //     ClockSkew = TimeSpan.Zero
            // };
        });
    }

    public static void AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tahseen.Api", Version = "v1" });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{ }
            }
        });
        });
    }
    // public  static void ConfigureServices(IServiceCollection services)
    // {
    //     services.AddDbContext<DataContext>(options =>
    //     {
    //         options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    //     });
    //
    //     // Qolgan xizmatlar
    //     services.AddControllers();
    //     services.AddSwaggerGen();
    // }

}