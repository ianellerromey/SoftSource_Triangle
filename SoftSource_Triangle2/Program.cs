using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftSource_Triangle2
{
    class Program
    {
        static uint s_maxIteration = 10,
                    s_iteration = 1;
        static TimeSpan s_interval = new TimeSpan(0, 0, 1);
        static DateTime s_last = DateTime.Now;

        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start ...");
            while ((Console.ReadKey().Key != ConsoleKey.Enter)) ;
            Console.WriteLine();
            do
            {
                if (DateTime.Now - s_last >= s_interval)
                {
                    var maxX = s_iteration + (s_iteration - 1);
                    var midX = maxX / 2;

                    string[,] triangle = new string[maxX, s_iteration];

                    DrawSide(   0, midX,    0, s_iteration - 1,     midX,               0, 0, s_iteration - 1, maxX - 1, s_iteration - 1, triangle);
                    DrawSide(midX, maxX, midX,               0, maxX - 1, s_iteration - 1, 0, s_iteration - 1, maxX - 1, s_iteration - 1, triangle);

                    Console.WriteLine(string.Format("{0} second(s)", s_iteration));
                    for(uint y = 0; y < s_iteration; ++y)
                    {
                        for (uint x = 0; x < maxX; ++x)
                        {
                            Console.Write((triangle[x, y] != null) ? triangle[x, y] : " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();

                    s_last = DateTime.Now;
                    ++s_iteration;
                }
            } while (s_iteration <= s_maxIteration);
            Console.Write("Complete");
            Console.WriteLine();

            Console.ReadKey();
        }

        static void DrawSide(uint startX, uint endX, 
                             float sideX0, float sideY0, float sideX1, float sideY1, 
                             float bottomX0, float bottomY0, float bottomX1, float bottomY1,
                             string[,] triangle)
        {
            for (uint i = startX; i < endX; ++i)
            {
                var y = YLerp(sideX0, sideY0, sideX1, sideY1, i);
                triangle[i, y] = "*";

                y = YLerp(bottomX0, bottomY0, bottomX1, bottomY1, i);
                triangle[i, y] = (i % 2 == 0) ? "*" : null;
            }
        }

        static uint YLerp(float x0, float y0, float x1, float y1, uint x)
        {
            return (uint)(y0 + ((y1 - y0) * (((float)x - x0) / (x1 - x0))));
        }
    }
}
