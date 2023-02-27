//using Serilog;

using Villa_VillaAPI.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Changing Logger with Dependency Injection. Instead of using the build in (console logging) 
// after installing Serilog.AspNetCore and Seril.Sinks.File will log to a file instead of the console window
// Anything about the debug level will be logged
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/villaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger(); ;
// Using seriLob
//builder.Host.UseSerilog();

// register the new custom logging:
// addSingleton     -> maximum life time when the application start, one object throughout the application 
// addScoped        -> for every request it will create a new object
// addTransient     -> every time object is accessed (if 1 request and object accessed 10 times, it will create 10 different objects)
builder.Services.AddSingleton<ILogging, LoggingV2>();

builder.Services
    .AddControllers(option => {
        //option.ReturnHttpNotAcceptable = true;          // if the format is not acceptable will return the appropriate message in headers Accepet
        })
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();          // headers will Accept application/xml
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
