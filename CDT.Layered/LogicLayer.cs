// File Name:   LogicLayer.cs
// Developer:   Brad Turner
//
// Description: Provides all private methods required to implement a standard KWIC indexing system.
//
// Notes:       


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDT.Layered
{
    class LogicLayer
    {
        public void Logicify(string[] args)
        {
            FileAccessLayer fal = new FileAccessLayer(args);
            fal.WriteToFile(Index(Rotate(fal.ReadFromFile())));
        }

        private LinkedList<string> Rotate(LinkedList<string> list)
        {
            LinkedList<string> output = new LinkedList<string>();
            // Continually loop until the input queue is empty.
            while (list.Count > 0)
            {
                // Get from the input queue.
                string record = list.First();
                list.RemoveFirst();

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
                        list.AddLast(recordShift);
                    }
                    // Remove end of line delimeter and send to output queue
                    output.AddLast(recordShift.Replace("/ ", "").Replace(" /", ""));
                }
            }
            return output;
        }

        private LinkedList<string> Index(LinkedList<string> list)
        {
            LinkedList<string> output = new LinkedList<string>();

            while (list.Count > 0)
            {
                // Gets first element of the input list.
                string record = list.First();
                list.RemoveFirst();

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

            return output;
        }
    }
}
