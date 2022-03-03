using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinq
{
    interface ICity
    {
        int ID { get; set; }
        string Name { get; set; }
        string CityCodeNumber { get; set; }
    }
}
