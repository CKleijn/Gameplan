using Asp.Versioning;
using Carter;
using GameplanAPI;
using GameplanAPI.Common.Middleware;

var builder = WebApplication.CreateBuilder(args);

DependencyInjection.Configure(builder);

var app = builder.Build();

var apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1))
    .ReportApiVersions()
    .Build();

var apiGroup = app
    .MapGroup("/api/v{apiVersion:apiVersion}")
    .WithApiVersionSet(apiVersionSet);

apiGroup.MapCarter();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();

        foreach (var description in descriptions)
        {
            string url = $"/swagger/{description.GroupName}/swagger.json";
            string name = description.GroupName.ToUpperInvariant();

            options.SwaggerEndpoint(url, name);
        }
    });
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseMiddleware<AuthMiddleware>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.Run();