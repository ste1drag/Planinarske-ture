using Microsoft.EntityFrameworkCore;
using Reviewing.Infrastructure.Persistence;
using Reviewing.Infrastructure.Repositories;
using Reviewing.Application.Contracts;
using Reviewing.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReviewContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ReviewRepository>();
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

    /*
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ReviewContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<ReviewContextSeed>>();
        await context.Database.MigrateAsync();
        await ReviewContextSeed.SeedAsync(context, logger);
    }
    */
}

app.UseAuthorization();

app.MapControllers();

app.Run();
