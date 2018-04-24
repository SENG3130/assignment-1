// File Name:   BlackboardOutputer.cs
// Developer:   Jordan Cork
//
// Description: Implements an agent from the Blackboard Architecture which
//              writes the output of the KWIC System to a file
// Notes:     

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CDT.BlackBoard
{
    class BlackboardOutputer
    {

        Blackboard blackboard;

        public BlackboardOutputer(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public void outputList()
        {

            try
            {
                LinkedList<string> list;

                // Accesses blackboard and gets list (sorted list)
                list = blackboard.getList();

                WriteToFile(list); // Writes list to output file
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }


        }

        public void WriteToFile(LinkedList<string> list)
        {
            // Write each node to file.

            try
            {
                String outputFile = "../../../output.txt";
                StreamWriter sw = new StreamWriter(outputFile);

                foreach (string node in list)
                {
                    sw.WriteLine(node);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadKey();
            }
        }

    }
}