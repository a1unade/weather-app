using ServiceB.Web.Extensions;
using ServiceB.Web.Interfaces;
using ServiceB.Web.Services;
using ServiceB.Web.Workers;
using WeatherApp.Contracts.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddKafkaConsumer(builder.Configuration.GetSection("Kafka"));
builder.Services.AddHostedService<KafkaBackgroundService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();