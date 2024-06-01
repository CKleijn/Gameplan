using Carter;
using GameplanAPI;

var builder = WebApplication.CreateBuilder(args);

DependencyInjection.Configure(builder);

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

var apiGroup = app.MapGroup("/api");
apiGroup.MapCarter();

app.Run();