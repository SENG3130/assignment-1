using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DT.PipeAndFilter
{
    class Indexor
    {
        private LinkedList<string> input, output;
        

        public Indexor()
        {
            // Initialises two empty new queues to source from and to.
            input = new LinkedList<string>();
            output = new LinkedList<string>();
           
        }

        public Indexor(LinkedList<string> input, LinkedList<string> output)
        {
            // Initialises the Indexor with a Queue to source from and a Queue to source to.
            this.input = input;
            this.output = output;
           
        }

        public void Start()
        {
            // Waits indefinitely for its input list's size > 0
            while (input.Count == 0)
            {
                Thread.Sleep(5);
            }
            

            while (input.Count > 0)
            {
                // Gets first element of the input list.
                string record = input.First();
                input.RemoveFirst();

                // If the output list is empty just add record to output list.
                if (output.Count == 0)
                {
                    output.AddFirst(record);
                }

                // If output list's size is greater than 1 than sort alphabetically using insertion sort.
                else if (output.Count > 0)
                {
                    bool insertted = false;
                    for (int i = 0; i < output.Count; i++)
                    {
                        String nodeVal = output.ElementAt(i);
                        
                        // Compares the values of record and nodeVal, if record alphabetically comes before nodeVal then insert before nodeVal.
                        if (string.Compare(record, nodeVal) == -1)
                        {
                            LinkedListNode<string> node = output.Find(nodeVal);
                            output.AddBefore(node, record);
                            insertted = true;
                            break;
                        }
                    }
                    // If record was not insertted then it should be the last item insertted alphabetically.
                    if (insertted == false)
                    {
                        output.AddLast(record);
                    }
                }
            }
            output.AddFirst("");

            Console.WriteLine("Output queue is:");
            foreach (string item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}
