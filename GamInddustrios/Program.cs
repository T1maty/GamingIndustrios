using GamingIndustrios.DataContextClass;
using GamingIndustrios.Models.Authorization;
using GamingIndustrios.Service;
using GamingIndustrios.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

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
//Di to Computer accessories 
builder.Services.AddScoped<IComputerService, ComputerService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//This is Serilog  cmd visual studio
builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
});


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


app.MapControllers();

 app.UseOcelot();
app.Run();

