using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLib
{
    public class Location
    {
        public string Address { get; set; }
        public override string ToString()
        {
            return Address;
        }
    }
}
