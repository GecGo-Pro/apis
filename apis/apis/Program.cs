using apis.IRepository;
using apis.Models;
using apis.Services;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddScoped<ICustomerRepo, CustomerService>();


builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsProduction())
{*/
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
