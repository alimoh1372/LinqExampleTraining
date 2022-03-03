using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinq
{
    interface IPerson
    {
        int ID { get; set; }
        string Name { get; set; }
        string Family { get; set; }
        int Age { get; set; }
        string PhonNumber { get; set; }
        string Mobile { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        int CtiyID { get; set; }

    }
}
