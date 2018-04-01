using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.PipeAndFilter
{
    class Rotator
    {
        private LinkedList<string> input, output;
        private static int numPermutations;
        private static object obj;
        public int Count
        {
            get
            {
                return numPermutations;
            }
        }

        public Rotator()
        {
            // Initialises two empty new queues to source from and to.
            input = new LinkedList<string>();
            output = new LinkedList<string>();
            numPermutations = 0;
            obj = new object();
        }

        public Rotator(LinkedList<string> input, LinkedList<string> output)
        {
            // Initialises the Rotator with a Queue to source from and a Queue to source to.
            this.input = input;
            this.output = output;
            numPermutations = 0;
        }

        public void Rotate()
        {
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
                    Console.WriteLine(recordShift);
                    
                    // Check if the first char is the end of line delimiter ( / ).
                    if (recordShift[0] != '/')
                    {
                        numPermutations++;
                        input.AddLast(recordShift);
                        
                        
                    }
                    // Remove end of line delimeter and send to output queue
                    output.AddLast(recordShift.Replace("/ ", "").Replace(" /",""));
                }
            }
        }

        public void AddToInput(string obj)
        {
            input.AddLast(obj);
        }
    }
}
