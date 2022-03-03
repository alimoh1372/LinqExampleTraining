using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinq
{
    class City:ICity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CityCodeNumber { get; set; }

    }
}
