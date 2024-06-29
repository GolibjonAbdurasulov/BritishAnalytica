using DatabaseBroker;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


     // var builder = WebApplication.CreateBuilder(args);
     // // Add services to the container.
     //    builder.Services.AddControllers();
     //    builder.Services.AddEndpointsApiExplorer();
     //    builder.Services.AddSwaggerGen();
     //
     // var configurationBuilder = new ConfigurationBuilder()
     //     .SetBasePath(Directory.GetCurrentDirectory())
     //     .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
     // var configuration = configurationBuilder.Build();
     //
     //    var app = builder.Build();
     // builder.Services.AddDbContext<DataContext>(options =>
     // {
     //     options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
     // });
     //
     //
     //    // Configure the HTTP request pipeline.
     //    if (app.Environment.IsDevelopment())
     //    {
     //        app.UseSwagger();
     //        app.UseSwaggerUI();
     //    }
     //
     //    app.UseHttpsRedirection();
     //    app.UseAuthorization();
     //    app.MapControllers();
     //
     //    app.Run();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration setup
var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
        
var configuration = configurationBuilder.Build();

// Add DbContext using PostgreSQL
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();