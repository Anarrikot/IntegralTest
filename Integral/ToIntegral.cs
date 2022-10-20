using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral
{
    public class ToIntegral
    {
        public double A { get; set; }
        public double B { get; set; }
        public double N { get; set; }

        public double F(double x)
        {
            return 332 * (x) - 2 - Math.Log(11 * x);
        }
        public double F(double x, bool test)
        {
            return x * x;
        }
    }
}
    