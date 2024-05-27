using FluentValidation;
using GameplanAPI.Features.Competition;
using GameplanAPI.Features.Competition._Interfaces;
using GameplanAPI.Features.Season;
using GameplanAPI.Features.Season._Interfaces;
using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Abstractions.Handling;
using GameplanAPI.Shared.Abstractions.Interfaces;
using GameplanAPI.Shared.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
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

builder.Services.AddScoped<ICompetitionRepository, CompetitionRepository>();
builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddLogging(cfg => cfg.AddConsole());

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseRouting();
app.MapControllers();

app.Run();