using GamingIndustrios.DataContextClass;
using GamingIndustrios.Service;
using GamingIndustrios.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using JavaScriptEngineSwitcher.ChakraCore;
using Hangfire;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics;
using MediatR;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

//  Dependency Injection
builder.Services.AddScoped<IXboxServices, XboxServices>();
//DI Subscription
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
//DI Playstation 4 or 5
builder.Services.AddScoped<IPlaystationService, PlaystationService>();
//DI Games to crossplatform
builder.Services.AddScoped<IGamesService, GameServices>();
//DI to Customer
builder.Services.AddScoped<ICustomerService, CustomerService>();
//DI to Computer accessories 
builder.Services.AddScoped<IComputerService, ComputerService>();

builder.Services.AddHealthChecks();

builder.Services.AddControllers();
//Connect Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
//Using Controllers
builder.Services.AddControllers();
//Using AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddDistributedMemoryCache();

//This is Serilog  cmd visual studio
builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
});
//Add Service RedisCache
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["ConnectionString:Redis"];
    options.InstanceName = "SampleInstance"; ;

});

builder.Services.AddSwaggerGen(config =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});


//MediatR
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName).AddChakraCore();

ConfigurationManager configuraton = builder.Configuration;

//Data Class to migration
 builder.Services.AddDbContext<DataClass>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Ocelot API Gateway CORS
builder.Services.AddCors(options =>
{
options.AddPolicy("CORSPolicy", builder => builder
.AllowAnyMethod()
.AllowAnyHeader()
.AllowCredentials()
.SetIsOriginAllowed((host) => true));
    
});
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);


var app = builder.Build();

//Use CORS
app.UseCors("CORSPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseHealthChecks("/Health");

app.UseDefaultFiles();
app.UseStaticFiles();


app.MapControllers();



 app.UseOcelot();

app.Run();

