// File Name:   Indexor.cs
// Developer:   Brad Turner
//
// Description: Alphabetically insertion sorts strings from linkedlist input to linkedlist output.
//
// Notes:       Sets first element of output to "/" to signal no more indexing.

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CDT.Core
{
    class Indexor
    {
        public List<string> Index(LinkedList<string> input)
        {
#if DEBUG
            Console.WriteLine(DateTime.Now + " Indexor.Index started");
#endif

            List<string> output = new List<string>(input);

            output.Sort();

#if DEBUG
            Console.WriteLine(DateTime.Now + " Indexor.Index finished");
#endif

            return output;
        }
    }
}
