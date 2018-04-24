// File Name:   Rotator.cs
// Developer:   Brad Turner
//
// Description: Sources strings from linkedlist input, circularly shifts said strings, and then appends to linkedlist output.
//
// Notes:       If a string is longer than 1 word, after every circular shift, also appends to linkedlist input.

using System.Collections.Generic;
using System.Linq;
using System;

namespace CDT.Core
{
    class Rotator
    {
        public LinkedList<string> Rotate(LinkedList<string> input)
        {
#if DEBUG
            Console.WriteLine(DateTime.Now + " Rotator.Rotate started");
#endif

            LinkedList<string> output = new LinkedList<string>();
            // Continually loop until the input queue is empty.
            while (input.Count > 0)
            {
                // Get from the input queue.
                string record = input.First();
                input.RemoveFirst();

                // Rotate the record by one word.
                int index = record.IndexOf(" ");
                if (index != -1)
                {
                    // If guards against empty cases.
                    string recordShift = record.Substring(index + 1) + " " + record.Substring(0, index);
                    //DEBUG:Console.WriteLine(recordShift);

                    // Check if the first char is the end of line delimiter ( / ).
                    if (recordShift[0] != '/')
                    {
                        input.AddLast(recordShift);
                    }
                    // Remove end of line delimeter and send to output queue
                    output.AddLast(recordShift.Replace("/ ", "").Replace(" /", ""));
                }
            }

#if DEBUG
            Console.WriteLine(DateTime.Now + " Rotator.Rotate finished");
#endif

            return output;
        }
    }


}
