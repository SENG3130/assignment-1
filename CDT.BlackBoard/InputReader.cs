// File Name:   InputReader.cs
// Developer:   Jordan Cork
//
// Description: Implements an agent from the Blackboard Architecture which
//              reads the input file for use in the KWIC system
// Notes:          

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CDT.BlackBoard
{
    class InputReader
    {
        Blackboard blackboard;

        public InputReader(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public void readInput()
        {

            // Reads file and stores in LinkedList
            LinkedList<String> list = ReadFromFile();

            try
            {
                blackboard.setList(list); // Accesses Blackboard and sets list to input
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }

        private LinkedList<string> ReadFromFile()
        {
            LinkedList<string> output = new LinkedList<string>();


            try
            {
                String inputFile = "../../input.txt";
                // Open StreamReader to read from file FileName.
                StreamReader sr = new StreamReader(inputFile);
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    // Add end of line delimiter to line and append to linked list output.
                    output.AddLast(line + " /");
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadKey();
            }
            return output;
        }


    }
}