using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.ADT
{
    class Outputter
    {
        public void Output(LinkedList<string> input)
        {
            foreach (string node in input)
            {
                Console.WriteLine(node);
            }
        }
    }
}
