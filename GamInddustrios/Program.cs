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

builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

builder.Services.AddScoped<IPlaystationService, PlaystationService>();

builder.Services.AddScoped<IGamesService, GameServices>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
});


ConfigurationManager configuraton = builder.Configuration;

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


var app = builder.Build();

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

