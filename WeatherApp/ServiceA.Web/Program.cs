using ServiceA.Web.Extensions;
using ServiceA.Web.Interfaces;
using ServiceA.Web.Services;
using ServiceA.Web.Workers;
using WeatherApp.Contracts.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddLogging();
builder.Services.AddKafkaProducer<WeatherApiResponse>(builder.Configuration.GetSection("Kafka"));
builder.Services.AddSingleton<IWeatherCollector, WeatherCollector>();
builder.Services.AddHostedService<WeatherBackgroundService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();