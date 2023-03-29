
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Person.API.Middleware;
using Persons.Application;
using Persons.Application.Infrastructure.Behaviours;
using Persons.Infrastructure;
using Serilog;
using System.Reflection;

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
    options => options.Filters.Add<ValidationFilter>())
//    .AddFluentValidation(options =>
//{
//    //x.AutomaticValidationEnabled = false;
//    // Validate child properties and root collection elements
//    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
//    options.ImplicitlyValidateChildProperties = true;
//    options.ImplicitlyValidateRootCollectionElements = true;
//})
.AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddFluentValidationRulesToSwagger();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var actionExecutingContext =
            actionContext as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

        // if there are modelstate errors & all keys were correctly
        // found/parsed we're dealing with validation errors
        if (actionContext.ModelState.ErrorCount > 0
            && actionExecutingContext?.ActionArguments.Count == actionContext.ActionDescriptor.Parameters.Count)
        {
            return new UnprocessableEntityObjectResult(actionContext.ModelState);
        }

        // if one of the keys wasn't correctly found / couldn't be parsed
        // we're dealing with null/unparsable input
        return new BadRequestObjectResult(actionContext.ModelState);
    };
});




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


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseLoggingMiddleware();

app.UseMiddleware<LocalizationMiddleware>();
//app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
