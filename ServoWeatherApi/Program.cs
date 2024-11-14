using InfluxDB3.Client;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Formatter;
using ServoWeatherDomain.API.InfluxDBRepositories;
using ServoWeatherDomain.API.InfluxDBRepositories.Interfaces;
using ServoWeatherDomain.API.MqttRepositories;
using ServoWeatherDomain.API.MqttRepositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfigurationSection broker = builder.Configuration.GetSection("BrokerHostSettings");
IConfigurationSection influx = builder.Configuration.GetSection("InfluxDbSettings");

builder.Services.AddSingleton(new MqttFactory().CreateMqttClient());
builder.Services.AddSingleton(new MqttClientOptionsBuilder()
                .WithTcpServer(broker["Host"], Convert.ToInt32(broker["Port"]))
                .WithProtocolVersion(MqttProtocolVersion.V311)
                .WithTlsOptions(x => x.UseTls()));

builder.Services.AddSingleton(new InfluxDBClient(influx["Host"], token: influx["Database"], database: influx["AuthToken"]));

builder.Services.AddHostedService<WorkerRepository>();
builder.Services.AddSingleton<IPublishRepository, PublishRepository>();
builder.Services.AddSingleton<IInfluxRepository, InfluxRepository>();

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
