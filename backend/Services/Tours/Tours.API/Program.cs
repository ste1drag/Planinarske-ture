using Microsoft.EntityFrameworkCore;
using Tours.Application;
using Tours.Application.BackgroundServices;
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

// Add background service for updating tour statuses
builder.Services.AddHostedService<TourStatusUpdateService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ToursDbContext>();
    dbContext.Database.Migrate();

    // Seed data if database is empty
    if (!dbContext.Mountains.Any())
    {
        dbContext.Mountains.AddRange(SeedData.AddMountains());
        dbContext.SaveChanges();
    }

    if (!dbContext.Tours.Any())
    {
        dbContext.Tours.AddRange(SeedData.AddTours());
        dbContext.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();
app.UseCors("MyPolicy");
app.UseAuthorization();
app.MapControllers();
app.Urls.Add("http://0.0.0.0:8080");

app.Run();