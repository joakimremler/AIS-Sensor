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
* Replace the simulation sensor to a real sensor that reads moisture in the soil and output the signal to AIS-Sensor.
* Add a small electrical pump to the Raspberry pi gpio pinns and control the pump, a preferible duration is 5s.
* Add protection
* Add multiply users

## Languages
This project is written in C#

## Features
* Easy to manages.
* Outputs data.
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
1. Clone this repo and set folder Linkify to localhost or create a [Virtual directory](https://en.wikipedia.org/wiki/Virtual_directory)
  `git clone git@github.com:joakimremler/Linkify.git`.

2. Create a Database in Mysql called Linkify `CREATE DATABASE Linkify;`.

3. Import `linkify.sql` MySql backup file. Navigate to assets/mysql and insert this line:

    `mysql -u root -p Linkify < linkify.sql`

4. Edit your settings in core/init.php.

5. You're done, enjoy!

## Resources
Great tutorial on C# REST API Client:
[API Client](https://www.youtube.com/watch?v=i1HSG7ttDtM)
