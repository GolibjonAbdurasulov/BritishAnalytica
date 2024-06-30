using DatabaseBroker;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Services.Services;
using Web.BackgroundServices;
using Web.Extension;
var builder = WebApplication.CreateBuilder(args);

// Konfiguratsiyani o'qish
builder.Services.Configure<TelegramBotSetting>(builder.Configuration.GetSection("TelegramBotSetting"));

// DB konteksti konfiguratsiyasi
builder.Services.AddDbContextPool<DataContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

// Hosted service qo'shish
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
}

builder.Services.Configure<TelegramBotSetting>(builder.Configuration.GetSection("TelegramBotSetting"));

// Hosted service qo'shish
builder.Services.AddSingleton<TelegramBotService>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<TelegramBotService>());

// Other service configurations...
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServicesFromTypeAssembly<UserService>();
builder.Services.ConfigureServicesFromTypeAssembly<AuthService>();
builder.Services.ConfigureServicesFromTypeAssembly<FileService>();
builder.Services.ConfigureServicesFromTypeAssembly<TranslationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//NpgsqlConnection.GlobalTypeMapper.UseJsonNet();
NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
