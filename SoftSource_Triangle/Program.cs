using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSource_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            IInitiator initiator = new ConsoleInitiator();
            IRenderer renderer = new ConsoleRenderer();
            var interval = new TimeSpan(0, 0, 1);
            var last = DateTime.Now;

            const uint maxIteration = 10;
            uint iteration = 1;

            initiator.Initiate();

            do
            {
                if (DateTime.Now - last >= interval)
                {
                    renderer.DisplayIterationNumber(iteration);

                    var triangle = TriangleGenerator.GenerateTriangle(iteration);
                    renderer.RenderIteration(triangle);

                    renderer.DisplayIterationSeparator();

                    last = DateTime.Now;
                    ++iteration;
                }
            } while (iteration <= maxIteration);

            renderer.DisplayCompletion();

            initiator.Terminate();
        }
    }
}
