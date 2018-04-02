﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.ADT
{
    class Indexor
    {
        public LinkedList<string> Index(LinkedList<string> input)
        {
            LinkedList<string> output = new LinkedList<string>();

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

            return output;
        }
    }
}