# Control af Motor and Telemetry Monitoring



## T.O.C

* [Intro](#Intro)
* [Requeriments](#Requeriments)

* [Instructions](#Instructions)

   * [Libraries](#Libraries)
   * [Structure](#Structure)

* [Changelog](#Changelog)
* [To-Do](#To-do)
* [Contributing](#Contributing)


## Requirements

- Arduino MKR WiFi 1010. [See Here](https://docs.arduino.cc/hardware/mkr-wifi-1010/)
- DHT11 sensor for temperature and humidity. [See Here](https://ardustore.dk/produkt/dht-11-temperature-humidity-module)
- Servo motor. [See Here](https://docs.arduino.cc/learn/electronics/servo-motors/)
- Visual Studio Code [See Here](https://code.visualstudio.com/)

## Intro

This project is about use Mqtt protocol to send and receive data between the arduino device and the API. 
(MQTT is used for messaging and data exchange between IoT and industrial IoT (IIoT) devices, such as embedded devices, sensors, industrial PLCs, etc.)

![OverviewIoT drawio](https://github.com/user-attachments/assets/0f525995-3d60-4257-ab02-a0c899f5a58d)

I did build a device that send the temperature and humidity of the room constantly as a Json. All the data is stored on a Cloud DB call InfluxDB.
The device has a Servo motor connected too so its possible to control the motor with a message ( On/Off ).

## Instructions

1. Connect the components provided in Requeriments, and make sure all is connected properly.
2. Install the required libraries by following their respective installation instructions.
3. Open Visual Studio Code.

### Libraries

  - ArduinoBearSSL - by arduino libraries

  - ArduinoJson - by bblanchon

  - DHT sensor library - by Adafruit

  - Servo - by arduino libraries

  - Adafruit Unified Sensor - by Adafruit

  - WiFiNINA - by arduino libraries

  - ArduinoMqttClient - by arduino libraries

### Structure

  #### main.cpp
    - Functions:
        void setup()
        void loop()
        void onMqttMessage(int messageSize)
      
    This file contains some extern variables for the efficiency of the functions.
    Remember to include "arduino_secrets.h".
    
  #### arduino_secrets.h
  
    - Includes
    - Function Prototypes
    - Defines

## Changelog
[Github](https://github.com/Cabuxito/MqttWebApiInfluxDB/tree/feature/InfluxDB) - The full project is ready for you to try it.



## To-do



## Contributing

* Im working with Thomas, he was a big help with the project.
