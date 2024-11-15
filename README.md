# ServoWeather

## Intro

This app must be able to display a graph based on telemetry measurements

#### Project Details
| Platform | GUI | Timeframe | Database Solution |
|----------|-----|-----------|-------------------|
|Mobil | Maui | One day | InfluxDB |



![Alt text](https://ilearn.eucsyd.dk/pluginfile.php/840871/course/section/202846/OverviewIoT.drawio.png)

#### Dependencies

- [InfluxDB3.Client](https://github.com/InfluxCommunity/influxdb3-csharp/tree/main/Client)
- [CommunityToolkit.Mvvm](https://github.com/CommunityToolkit/dotnet)
- [Syncfusion.Maui.Charts](https://www.syncfusion.com/maui-controls?utm_source=nuget&utm_medium=listing)
- [MQTTnet.Extensions.TopicTemplate](https://github.com/dotnet/MQTTnet)

#### Broker and Db

- [InfluxDb](https://cloud2.influxdata.com)
- [Hivemq](https://www.hivemq.com)

## Api

| Api                             | Description                                                                                 | Request body |   Response body  |
|---------------------------------|---------------------------------------------------------------------------------------------|:------------:|:----------------:|
| GET/api/Db/GetTelemtry/{option} | Option: (All) Get all data. (LastHour) Get data from last hour. (Today) Get data from today | none         | List of Telemtry |
| POST/api/Mqtt/activate/{status} | Status: on, off. activate servo motor on deviece                                            | none         | none             |
|                                 |                                                                                             |              |                  |

#### Deploy with Dev Tunnel

Use Persistent tunnel and select public.

In project service change BaseUrl in Constants.cs to your dev tunnel url.

#### Mqtt broker

In appsettings.json you can set up broker url and port under BrokerHostSettings

#### Test

You can test in WebApiMqtt.http and swagger

## Domain

#### User secrets

This is for mqtt clients

Device one must be publicer

- "DeivceOneUsername" 
- "DeivceOnePassword"

Device Two must be publicer and subscriber

- "DeivceTwoUsername"
- "DeivceTwoPassword"




## Git

features are brached out from develpoer.

if failed processing manifest appears when cloned  
Just remove app icon in Android manifest,
Rebuild and Re-add it.

## Troubleshooting

- Check Dev tunnel is Persistent and public and selected when startup.
  - Config Constants.cs HostUrl in Service Project 
- Check Mqtt client is configured corret and is in user secrets in Domain.
- Check if broker settings i corret in appsettings.json in api projcet
- Check in InfluxRepository in Domain and config hostUrl, database and authToken
- Check if api is working in swagger or http
  
## Embedded

[Github](https://github.com/Cabuxito/MqttWebApiInfluxDB/tree/feature/InfluxDB) - Embeded 
