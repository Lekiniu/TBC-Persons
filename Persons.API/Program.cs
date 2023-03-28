using FluentValidation.AspNetCore;
using FluentValidation;
using Newtonsoft.Json;
using Person.API.Middleware;
using Persons.Application;
using Persons.Infrastructure;
using Serilog;
using System.Reflection;
using Person.API;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Persons.API.Middleware.Filters;
using Microsoft.AspNetCore.Mvc;

//Environment.CurrentDirectory = AppContext.BaseDirectory;
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();

var builder = WebApplication.CreateBuilder(args);
//var logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .Enrich.FromLogContext()
//    .CreateLogger();
//builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

//builder.Host.UseContentRoot(Directory.GetCurrentDirectory());
//builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    var env = hostingContext.HostingEnvironment;
//    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
//    config.AddEnvironmentVariables();
//});
//builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
//                    .ReadFrom.Configuration(hostingContext.Configuration));





// Add services to the container.
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers(
    //options =>   options.Filters.Add<ValidationFilter>()
).AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });
//builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true;
//});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TBC-Persons.API", Version = "v1" });
});
//builder.Services.AddLocalization(options => options.ResourcesPath = "CommonResource");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TBC-Persons.API v1"));
}
app.UseLoggingMiddleware();

app.UseMiddleware<LocalizationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
