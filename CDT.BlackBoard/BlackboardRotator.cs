// File Name:   BlackboardRotator.cs
// Developer:   Jordan Cork
//
// Description: Implements an agent from the Blackboard Architecture which
//               performs the rotating actino of the KWIC System
// Notes:       

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CDT.BlackBoard
{
    class BlackboardRotator
    {

        Blackboard blackboard;

        public BlackboardRotator(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public void rotate()
        {
            try
            {
                LinkedList<string> list;

                // Accesses blackboard and gets list
                list = blackboard.getList();

                list = Rotate(list); // The KWIC operation is performed on the list

                // Blackboard is accessed and the new list is stored
                blackboard.setList(list);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

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

    }
}