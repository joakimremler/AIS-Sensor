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
                            newPlant.Pic_url = plant[i].Pic_url;
                            string url = String.Format("http://localhost:61347/api/Plant/{0}", plant[i].ID);
                            await client.PutAsJsonAsync(url, newPlant);

                            //output to console
                            Console.WriteLine("Sensor ID: {0} Sensor output: {1} ({2} to {3})\t ONLINE", sensor.ID, sensor.GetSoilMoistureNow(ran), plant[i].SoilMoistureMin, plant[i].SoilMoistureMax);
                        }
                        else
                        {
                            Console.WriteLine("Sensor is OFFLINE");
                        }
                    }
                }
            }
        }
    }
}
