using ServiceB.Web.Extensions;
using ServiceB.Web.Interfaces;
using ServiceB.Web.Services;
using ServiceB.Web.Workers;
using Weather;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddSingleton<IWeatherSenderService, WeatherSenderService>();
builder.Services.AddKafkaConsumer(builder.Configuration.GetSection("Kafka"));
builder.Services.AddHostedService<KafkaBackgroundService>();
builder.Services.AddGrpcClient<WeatherService.WeatherServiceClient>(o =>
{
    o.Address = new Uri(builder.Configuration["Grpc:Uri"]!);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();