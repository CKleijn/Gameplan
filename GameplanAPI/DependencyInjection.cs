﻿using FluentValidation;
using GameplanAPI.Features.Competition._Interfaces;
using GameplanAPI.Features.Competition;
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
            builder.Services.AddScoped<ICompetitionRepository, CompetitionRepository>();
            builder.Services.AddScoped<ICompetitionMapper, CompetitionMapper>();
            builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();
            builder.Services.AddScoped<ISeasonMapper, SeasonMapper>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Services.AddLogging(cfg => cfg.AddConsole());

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}
