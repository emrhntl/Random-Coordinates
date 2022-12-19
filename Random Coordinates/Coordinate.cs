using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Coordinates
{
    internal class Coordinate
    {
        public double degree { get; set; }
        public double minute { get; set; }
        public double second { get; set; }
        public double milliSecond { get; set; }
        public Coordinate()
        {
            degree = 0;
            minute = 0;
            second = 0;
            milliSecond = 0;
        }
    }
}
