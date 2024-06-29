using DatabaseBroker;
using DatabaseBroker.Repositories.AboutBusinessModelRepository;
using DatabaseBroker.Repositories.Common;
using DatabaseBroker.Repositories.ContactRepository;
using DatabaseBroker.Repositories.FaqQuestionsRepository;
using DatabaseBroker.Repositories.FileRepository;
using DatabaseBroker.Repositories.HomeModelRepository;
using DatabaseBroker.Repositories.MottoRepository;
using DatabaseBroker.Repositories.NewsRepository;
using DatabaseBroker.Repositories.OurServicesRepository;
using DatabaseBroker.Repositories.PpsRepository;
using DatabaseBroker.Repositories.ServicePercentRepository;
using DatabaseBroker.Repositories.TeamMemberRepository;
using DatabaseBroker.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Services;
using Web.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<DataContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    
});



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 // builder.Services.AddScoped<IUserRepository, UserRepository>();
 // builder.Services.AddScoped<IAboutBusinessModelRepository, AboutBusinessModelRepository>();
 // builder.Services.AddScoped<IContactRepository, ContactRepository>();
 // builder.Services.AddScoped<IFaqQuestionRepository, FaqQuestionRepository>();
 // builder.Services.AddScoped<IFileRepository, FileRepository>();
 // builder.Services.AddScoped<IHomeModelRepository, HomeModelRepository>();
 // builder.Services.AddScoped<IMottoRepository, MottoRepository>();
 // builder.Services.AddScoped<INewsRepository, NewsRepository>();
 // builder.Services.AddScoped<IOurServicesRepository, OurServicesRepository>();
 // builder.Services.AddScoped<IPpsRepository, PpsRepository>();
 // builder.Services.AddScoped<IServicePercentRepository, ServicePercentRepository>();
 // builder.Services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();


builder.Services.ConfigureRepositories();

builder.Services.ConfigureServicesFromTypeAssembly<UserService>();
builder.Services.ConfigureServicesFromTypeAssembly<AuthService>();
builder.Services.ConfigureServicesFromTypeAssembly<FileService>();

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