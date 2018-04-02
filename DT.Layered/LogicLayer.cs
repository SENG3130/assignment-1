using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.Layered
{
    class LogicLayer
    {
        public void Logicify()
        {
            FileAccessLayer fal = new FileAccessLayer();
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
            return list;
        }
    }
}
