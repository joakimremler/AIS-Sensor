using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AIS_Sensor
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                //Connect to server
                client.BaseAddress = new Uri("http://localhost:61347/");

                //Clears old data???
                client.DefaultRequestHeaders.Accept.Clear();

                //Sets the output formate to json
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/jsan"));
                //define variable
                HttpResponseMessage response;

                //**********// POST //**********//
                /*Console.WriteLine("Post");
                Plant newPlant = new Plant();
                newPlant.Name = "Timja";
                newPlant.SoilMoistureMin = 12; 
                newPlant.SoilMoistureMax = 25;
                newPlant.SoilMoistureNow = 16;
                newPlant.Category = "Plant";
                newPlant.SunlightMin = 25;
                newPlant.SunlightMax = 45;
                newPlant.SunlightNow = 30;
                newPlant.ID_Type = 4;
                newPlant.StartDate = DateTime.Parse("10/10/2016");
                newPlant.Updated = DateTime.Now;

                response = await client.PostAsJsonAsync("api/Plant", newPlant);
                if (response.IsSuccessStatusCode)
                {
                    Uri plantUrl = response.Headers.Location;
                    Console.WriteLine(plantUrl);

                    //update name (PULL)
                    newPlant.Name = "Advokado";
                    response = await client.PutAsJsonAsync(plantUrl, newPlant);

                    //delete
                    response = await client.DeleteAsync(plantUrl);
                }
                */

                //**********// GET specific //**********//
                //Console.WriteLine("Get");
                //response = await client.GetAsync("api/Plant/1");
                //if (response.IsSuccessStatusCode)
                //{
                //   Plant plant = await response.Content.ReadAsAsync<Plant>();
                //    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}", plant.ID, plant.Name, plant.SoilMoistureMin, plant.SoilMoistureMax, plant.SoilMoistureNow, plant.Category, plant.SunlightMin, plant.SunlightMax, plant.SunlightNow, plant.ID_Type, plant.StartDate, plant.Updated);
                //}

                //**********// GET all //**********//
                Console.WriteLine("Get all Plants");
                response = await client.GetAsync("api/Plant");
                if (response.IsSuccessStatusCode)
                {
                    List<Plant> plant = await response.Content.ReadAsAsync<List<Plant>>();


                    Random random = new Random();
                    for (int i = 0; i < plant.Count; i++)
                    {
                        //random number to simulate sensor output
                        var ran = random.Next(0, 20);

                        //input sensor id
                        var sensor = new Sensor(plant[i].ID);

                        //check if connection to sensor is ok
                        if (sensor.Online())
                        {
                            //pump water if the earth is dry
                            if (plant[i].SoilMoistureMin >= sensor.GetSoilMoistureNow(ran))
                            {
                                var pump = new Pump(sensor.GetSoilMoistureNow(ran), plant[i].SoilMoistureMin);
                                pump.Start();
                            }

                            //Update API value SoilMoistureNow and Updated 
                            Plant newPlant = new Plant();
                            newPlant.Name = plant[i].Name;
                            newPlant.SoilMoistureMin = plant[i].SoilMoistureMin; 
                            newPlant.SoilMoistureMax = plant[i].SoilMoistureMax;
                            newPlant.SoilMoistureNow = sensor.GetSoilMoistureNow(ran);
                            newPlant.Category = plant[i].Category;
                            newPlant.SunlightMin = plant[i].SunlightMin;
                            newPlant.SunlightMax = plant[i].SunlightMax;
                            newPlant.SunlightNow = plant[i].SunlightNow;
                            newPlant.ID_Type = plant[i].ID_Type;
                            newPlant.StartDate = plant[i].StartDate;
                            newPlant.Updated = DateTime.Now;
                            string url = String.Format("http://localhost:61347/api/Plant/{0}", plant[i].ID);
                            await client.PutAsJsonAsync(url, newPlant);

                            //output to console
                            Console.WriteLine("Sensor ID: {0} Sensor output: {1} ({2} to {3})\t ONLINE", sensor.ID, sensor.GetSoilMoistureNow(ran), plant[i].SoilMoistureMin, plant[i].SoilMoistureMax);
                        }
                        else
                        {
                            Console.WriteLine("Sensor is OFFLINE");
                        }

                        //Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}", plant[i].ID, plant[i].Name, plant[i].SoilMoistureMin, plant[i].SoilMoistureMax, plant[i].SoilMoistureNow, plant[i].Category, plant[i].SunlightMin, plant[i].SunlightMax, plant[i].SunlightNow, plant[i].ID_Type, plant[i].StartDate, plant[i].Updated);
                    }
                }
            }
        }
    }
}
