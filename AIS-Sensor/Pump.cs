using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Sensor
{
    class Pump
    {
        public DateTime time { get; }
        public int moistureNow { get; }
        public int moistureMin { get; }

        public Pump(int now, int min)
        {
            this.moistureNow = now;
            this.moistureNow = min;
        }

        public void Start()
        {
            //Pump water in 5s
            Console.WriteLine("Start pumping water");
        }

    }
}
