using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSource_Triangle
{
    class ConsoleInitiator : IInitiator
    {
        private const string c_initiate = "Press enter to start ...";
        private const ConsoleKey c_initationKey = ConsoleKey.Enter;

        public void Initiate()
        {
            Console.WriteLine(c_initiate);

            // wait
            while ((Console.ReadKey().Key != c_initationKey)) ;

            Console.WriteLine();
        }

        public void Terminate()
        {
            Console.ReadKey();
        }
    }
}
