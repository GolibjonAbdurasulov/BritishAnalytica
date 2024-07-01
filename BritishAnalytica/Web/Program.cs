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

// Konfiguratsiyani o'qish
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// DB konteksti konfiguratsiyasi
builder.Services.AddDbContextPool<DataContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    optionsBuilder.UseChangeTrackingProxies(); // ChangeTrackingProxies ni qo'shish
    optionsBuilder.UseLazyLoadingProxies();
});

// Telegram bot sozlamalarni konfiguratsiyalash
builder.Services.Configure<TelegramBotSetting>(builder.Configuration.GetSection("TelegramBotSetting"));

// TelegramBotService ni qo'shish
builder.Services.AddSingleton<TelegramBotService>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<TelegramBotService>());


// JWT autentifikatsiyani sozlash
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


// Swagger UI ni sozlash
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "hytps://britishanalytica", Version = "v1" });

    // JWT ni Swagger ga integratsiya qilish
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



builder.Services
    .AddAuthorization(options =>
    {
        // options.
    });

// Dasturning muhiti to'g'risida yangi yechimlar qo'shish
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

// Endpoint-larni tayyorlash
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();

// Dasturni ishga tushirish
app.Run();
