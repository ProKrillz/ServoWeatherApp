using InfluxDB3.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Formatter;
using ServoWeatherDomain.API.InfluxDBRepositories;
using ServoWeatherDomain.API.InfluxDBRepositories.Interfaces;
using ServoWeatherDomain.API.MqttRepositories;
using ServoWeatherDomain.API.MqttRepositories.Interfaces;
using ServoWeatherDomain.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString)).AddLogging();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddCors(options => options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

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
app.MapIdentityApi<IdentityUser>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
