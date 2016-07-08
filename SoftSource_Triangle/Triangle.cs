using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSource_Triangle
{
    class Triangle
    {
        public IEnumerable<IEnumerable<bool>> Sides
        {
            get;
            private set;
        }

        public Triangle(IEnumerable<IEnumerable<bool>> sides)
        {
            Sides = sides;
        }
    }
}
