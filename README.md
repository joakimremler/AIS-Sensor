# Automatic Irrigation System - Sensor (AIS-Sensor)

## Description AIS
Automatic Irrigation System is a automatic system that measure soil moisture with a sensor and decides if it need water or not.
The system then register this data to a open rest API (AIS-API) and a WEB based system gets this data and output it on a webpage (AIS-WEB).

The final goal with this project is that you can have a lots of fresh plants and flowers without have to spend time of to managing them.

## Description AIS-Sensor
AIS-Sensor is a system that checks the soil moisture of a plant or flower. If the soil moisture is dry then it starts a water pump and pumps water. All results from this process is stored in a REST API (AIS-API).
 Do to limited time the sensor and waterpump is not fully functional and has been replased by a simulation. When AIS-Sensor calls the sensor class it replies with a random number.

# BETA
This is a beta and it is not right fully complete and it has not been tested on a Raspberry PI.
Do to limited time I haven't been able to install a pump and a sensor.  

## TODO
* Add security to the webpage that nobody that hasent been autorized can POST, DELETE or PUT values to your system.
* Add login
* Add multiply users

## Languages
This project is written in C#

## Features
* Easy to manages.
* Gets all data.
* Connected to a REST API.
* Updates API with sensor values.


## Tested software versions
* Mysql Workbench 6.3.8
* Microsoft Visual Studio Professional 2017
* Microsoft Visual Studio Community 2015

## Recommended software versions
* Mysql Workbench 6.3.8
* Microsoft Visual Studio Professional 2017

## Installation (WRITE THIS!!!!!)
1. Download and setup repo: [AIS-API](https://github.com/joakimremler/AIS-API)

2. Download repo: [AIS-Sensor](https://github.com/joakimremler/AIS-Sensor)

3. Start AIS-API.

4. You're done, enjoy!

## Resources
Tutorial on MVC projects and connections to API:
[MVC Connect to API](https://www.youtube.com/watch?v=P8QtHXmCpCc)
