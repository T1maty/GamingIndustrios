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
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Ocelot.Values;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using GamingIndustrios.ActionFilters;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;
using System.Web.Http;
using System.Configuration;
using Nethereum.JsonRpc.Client;

var builder = WebApplication.CreateBuilder(args);

 // ConfigurationManager configuration = builder.Configuration;


// static void Register(HttpConfiguration config)
//{
  //  config.EnableCors();
   // config.MapHttpAttributeRoutes();

    
//}


builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
});


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
builder.Services.AddScoped<ICryptoService, CryptoService>();

builder.Services.AddHealthChecks();

builder.Services.AddAuthorization();

builder.Services.AddControllers();
//Connect Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();


//connection React Application in CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

    var frontendURL = builder.Configuration.GetValue<string>("frontend_url");

    c.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});



//Using Controllers
builder.Services.AddControllers(config =>
{
    config.Filters.Add(new ActionFiltersExample("Global"));
});


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
    config.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "Gaming-Industrios", Version = "v1" });
});






//MediatR
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName).AddChakraCore();

//ConfigurationManager configuraton = builder.Configuration;

//Data Class to migration
builder.Services.AddDbContext<DataClass>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
options.AddPolicy("CORSPolicy", builder => builder
.AllowAnyMethod()
.AllowAnyHeader()
.AllowCredentials()
.SetIsOriginAllowed((host) => true));
    
});
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});


var options = new RewriteOptions();


var app = builder.Build();


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});



//app.UseSwaggerUI(config =>
//config.SwaggerEndpoint("/swagger/v1/swagger.json", "Gaming Industrios v1"));

//Use CORS
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Hsts
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();



app.UseHealthChecks("/Health");

app.UseDefaultFiles();
app.UseStaticFiles();


app.MapControllers();

app.UseRewriter(options);



 app.UseOcelot();

app.Run();

