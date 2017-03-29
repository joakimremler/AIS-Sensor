using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Sensor
{
    class Sensor
    {
        public long ID { get; }


        public Sensor(long id)
        {
            this.ID = id;
        }

        public int GetSoilMoistureNow(int random)
        {
            //get sensor output
            return random;
        }

        public bool Online()
        {
            // check if sensor is connected true/false
            return true;
        }
        
    }
}
