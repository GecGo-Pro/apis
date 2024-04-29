using apis.Controllers;
using apis.IRepository;
using apis.Models;
using apis.Services;
using apis.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Twilio.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient<ITwilioRestClient, SendSmsService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContextPool<DatabaseContext>
    (d => d.UseMySql(builder.Configuration.GetConnectionString("myConnect"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("myConnect"))));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.RequireHttpsMetadata = false;
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

/*
builder.Services.AddCors(o =>
{
    o.AddPolicy("MyAppCors", policy =>
    {
        policy.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>())
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});*/

builder.Services.AddTransient<ExceptionError>();


builder.Services.AddScoped<ICustomerOTPRepo, CustomerOTPService>();
builder.Services.AddScoped<IDispatcherOTPRepo, DispatcherOTPService>();

builder.Services.AddScoped<IDispatcherRepo, DispatcherService>();
builder.Services.AddScoped<IDispatchJobRepo, DispatchJobService>();

builder.Services.AddScoped<IDriverRepo, DriverService>();


builder.Services.AddScoped<ITokenRepo, TokenService>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Image")),
    RequestPath = "/Image"
});

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
