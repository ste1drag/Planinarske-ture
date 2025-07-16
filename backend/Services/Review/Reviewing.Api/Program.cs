using Microsoft.EntityFrameworkCore;
using Reviewing.Infrastructure.Persistence; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReviewContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options
        =>
    {
        options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
    });
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ReviewContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<ReviewContextSeed>>();
        await context.Database.MigrateAsync();
        await ReviewContextSeed.SeedAsync(context, logger);
    }
}

app.UseAuthorization();

app.MapControllers();

app.Run();
