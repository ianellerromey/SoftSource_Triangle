using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSource_Triangle
{
    interface IRenderer
    {
        void DisplayIterationNumber(uint iteration);
        void RenderIteration(Triangle triangle);
        void DisplayIterationSeparator();
        void DisplayCompletion();
    }
}
