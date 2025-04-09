using Microsoft.EntityFrameworkCore;
using Tours.Application;
using Tours.Infrastructure;
using Tours.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddApplicationServices(services =>
{
    InfrastructureServiceRegistration.AddInfrastructureService(services, builder.Configuration);
});
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ToursDbContext>();
    dbContext.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tours API V1");
    c.RoutePrefix = string.Empty;
});

app.UseExceptionHandler();
app.UseCors("MyPolicy");
app.UseAuthorization();
app.MapControllers();
app.Urls.Add("http://0.0.0.0:8080");

app.Run();