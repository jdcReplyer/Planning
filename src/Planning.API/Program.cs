using Common.Extensions.HostingEnvironment;
using Common.Messaging.Common;
using Common.Messaging.Events.BusinessNotifier;
using Common.Middlewares.Exceptions;
using Common.Middlewares.WrappersController;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Planning.Business.Messaging.EventHandlers;
using Planning.DataAccess.Http.Client;
using Planning.Translators;
using static Planning.Business.Extensions.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

// AppSettings iniettato tramite chart da Kubernetes al pod
builder.Configuration.AddJsonFile("/app/settings/appsettings.json", true);

// Service Principal iniettato tramite chart da Kubernetes al pod e utilizzato per l'accesso al DB
builder.Configuration.AddKeyPerFile("/app/secrets-sp-secret", true);

// Add services to the container.
builder.Services.AddDatabaseServices(builder.Configuration);
builder.Services.AddBusinessServices();

builder.Services.AddAutoMapper(typeof(PlanningMapperProfile));
builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions
      .ReferenceHandler = ReferenceHandler.IgnoreCycles;

}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
   // options.SerializerSettings.DateFormatString = "dd/MM";
});


var controllerTypes = Assembly.GetExecutingAssembly().GetTypes()
    .Where(type => typeof(ControllerBase).IsAssignableFrom(type) && !type.IsAbstract);
foreach (var controllerType in controllerTypes)
{
    Console.WriteLine("-----------------");
    Console.WriteLine(controllerType.Name);
    Console.WriteLine("-----------------");

}




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Any",
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

// Microservices intracommunication settings (RabbitMQ for local, Azure Service Bus for live environments)



var app = builder.Build();

//Client.Initialize(app.Configuration);

// Configure the HTTP request pipeline.
Console.WriteLine("_---------------------------------------------------------------");

app.MigrateDatabase();



app.UseCors("Any");

if (app.Environment.IsLocal())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseMiddleware<DataWrapperControllerMiddleware>();

var supportedCultures = new[] { "it-IT" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);
Thread.CurrentThread.CurrentCulture = new CultureInfo(supportedCultures[0]);

if (!app.Environment.IsLocal())
{ 
    app.UseHttpsRedirection();
}
app.UseHttpLogging();

app.UseAuthorization();

app.MapControllers();




app.Run();
