using FluentValidation;
using GameplanAPI.Features.Season;
using GameplanAPI.Features.Season._Helpers;
using GameplanAPI.Features.Season._Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Carter;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Infrastructure.Persistence.Contexts;
using GameplanAPI.Common.Implementations;
using GameplanAPI.Common.Handlers;
using GameplanAPI.Features.Match._Interfaces;
using GameplanAPI.Features.Match;
using Asp.Versioning;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GameplanAPI.Features.User._Interfaces;
using GameplanAPI.Features.User;
using Microsoft.OpenApi.Models;
using GameplanAPI.Common.Services._Interfaces;
using GameplanAPI.Common.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GameplanAPI
{
    public static class DependencyInjection
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));

            builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:4200");
            }));

            builder.Services.AddCarter();
            builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();
            builder.Services.AddScoped<ISeasonMapper, SeasonMapper>();
            builder.Services.AddScoped<IMatchRepository, MatchRepository>();
            builder.Services.AddScoped<IMatchMapper, MatchMapper>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserMapper, UserMapper>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Services.AddLogging(cfg => cfg.AddConsole());

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme 
                    {
                        Reference = new OpenApiReference 
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }});
            });

            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("gameplan-firebase.json")
            });

            builder.Services
                .AddAuthentication()
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = configuration["Authentication:ValidIssuer"];
                    options.Audience = configuration["Authentication:Audience"];
                    options.TokenValidationParameters.ValidIssuer = configuration["Authentication:ValidIssuer"];
                    options.TokenValidationParameters.ValidAudience = configuration["Authentication:Audience"];
                    options.TokenValidationParameters.ValidateIssuer = true;
                    options.TokenValidationParameters.ValidateAudience = true;
                });

            builder.Services.AddAuthorization();
        }
    }
}
