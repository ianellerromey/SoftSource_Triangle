using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSource_Triangle
{
    static class TriangleGenerator
    {
        public static Triangle GenerateTriangle(uint size)
        {
            List<List<bool>> sides = new List<List<bool>>();

            // always add the top row
            {
                List<bool> side = new List<bool>();
                side.Add(true);

                sides.Add(side);
            }

            if (size > 1)
            {
                // add the middle rows if we can
                uint previousFill = 1;
                for (uint i = 1; i < size - 1; ++i)
                {
                    List<bool> side = new List<bool>();

                    // bookend the empty values with display values
                    side.Add(true);
                    for (uint j = 0; j < previousFill; ++j)
                    {
                        side.Add(false);
                    }
                    side.Add(true);

                    sides.Add(side);

                    previousFill += 2;
                }

                // add the bottom row
                {
                    List<bool> side = new List<bool>();

                    // add one display value and one empty value
                    // up to the last position; add the last display value without a subsequent empty value
                    for (uint i = size; i > 1; --i)
                    {
                        side.Add(true);
                        side.Add(false);
                    }
                    side.Add(true);

                    // update preexisting sides based off of length of final side
                    var countOfValues = side.Count(x => x) - 1;
                    foreach (var oldSide in sides)
                    {
                        for (var count = countOfValues; count > 0; --count)
                        {
                            oldSide.Insert(0, false);
                        }

                        --countOfValues;
                    }

                    // add final side
                    sides.Add(side);
                }
            }

            return new Triangle(sides);
        }
    }
}
