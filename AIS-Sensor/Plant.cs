using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_Sensor
{
    public class Plant
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int SoilMoistureMin { get; set; }
        public int SoilMoistureMax { get; set; }
        public int SoilMoistureNow { get; set; }
        public string Category { get; set; }
        public int SunlightMin { get; set; }
        public int SunlightMax { get; set; }
        public int SunlightNow { get; set; }
        public int ID_Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Updated { get; set; }
    }
}
