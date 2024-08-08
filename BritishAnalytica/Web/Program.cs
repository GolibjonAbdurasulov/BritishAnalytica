using System.Text;
using DatabaseBroker;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using Services.Services;
using Web.BackgroundServices;
using Web.Extension;
using Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddDbContextPool<DataContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    optionsBuilder.UseLazyLoadingProxies();
    //optionsBuilder.UseChangeTrackingProxies();
});


builder.Services.Configure<TelegramBotSetting>(builder.Configuration.GetSection("TelegramBotSetting"));


builder.Services.AddSingleton<TelegramBotService>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<TelegramBotService>());

builder.WebHost.ConfigureKestrel(x => x.ListenAnyIP(80));



builder
    .Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        string key = builder.Configuration.GetSection("Jwt")["SecurityKey"];
        string issuer = builder.Configuration.GetSection("Jwt")["Issuer"];
        string audience = builder.Configuration.GetSection("Jwt")["Audience"];
        int expiresInMinutes = builder.Configuration.GetSection("Jwt").GetValue<int>("ExpireAtInMinutes");
        
        
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ClockSkew = TimeSpan.Zero
        };
        
    });


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "https://britishanalytica", Version = "v1" });

  
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});


 builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });


builder.Services
    .AddAuthorization(options =>
    {
        // options.
    });


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureRepositories();


builder.Services.ConfigureServicesFromTypeAssembly<UserService>();
builder.Services.ConfigureServicesFromTypeAssembly<AuthService>();
builder.Services.ConfigureServicesFromTypeAssembly<FileService>();
builder.Services.ConfigureServicesFromTypeAssembly<TranslationService>();
builder.Services.ConfigureServicesFromTypeAssembly<TokenService>();

// Global xato boshqaruv middleware ni qo'shish
builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

var app = builder.Build();

// Xato boshqaruv middleware ni qo'shish
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// HTTP so'rovlarini konfiguratsiya qilish
app.UseHttpsRedirection();
app.UseRouting();

// Autentifikatsiya va ruxsat middleware larni qo'shish
app.UseAuthentication();
app.UseAuthorization();

// Raqamlarni tayyorlash
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.UseCors("AllowAllOrigins");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();

// Dasturni ishga tushirish
app.Run();
