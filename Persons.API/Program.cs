using Newtonsoft.Json;
using Person.API.Middleware;
using Persons.Application;
using Persons.Infrastructure;
using Serilog;

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
builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling =ReferenceLoopHandling.Ignore; 
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseLoggingMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
