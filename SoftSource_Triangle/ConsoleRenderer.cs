using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSource_Triangle
{
    class ConsoleRenderer : IRenderer
    {
        private const string c_iteration = "{0} second(s)";
        private const string c_side = "*";
        private const string c_empty = " ";
        private const string c_completion = "Complete";

        public void DisplayIterationNumber(uint iteration)
        {
            Console.WriteLine(string.Format(c_iteration, iteration));
        }

        public void RenderIteration(Triangle triangle)
        {
            foreach (var side in triangle.Sides)
            {
                foreach (var value in side)
                {
                    Console.Write((value) ? c_side : c_empty);
                }
                Console.WriteLine();
            }
        }

        public void DisplayIterationSeparator()
        {
            Console.WriteLine();
        }

        public void DisplayCompletion()
        {
            Console.WriteLine(c_completion);
        }
    }
}
