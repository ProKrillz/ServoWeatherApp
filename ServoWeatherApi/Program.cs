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

//builder.Services.Configure<BrokerHostSettings>(builder.Configuration.GetSection("BrokerHostSettings"));

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
