using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTalk.WindowsPhone.Model
{

    public class Car
    {
        public string id { get; set; }
        public string modelIdentifier { get; set; }
        public string modelName { get; set; }
        public string name { get; set; }
        public string make { get; set; }
        public string group { get; set; }
        public string color { get; set; }
        public string series { get; set; }
        public string fuelType { get; set; }
        public float fuelLevel { get; set; }
        public string transmission { get; set; }
        public string licensePlate { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string innerCleanliness { get; set; }
        public string carImageUrl { get; set; }
    }

}
