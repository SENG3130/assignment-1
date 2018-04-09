// File Name:   Inputter.cs
// Developer:   Brad Turner
//
// Description: Reads the file specified by FileName, and appends to the linkedlist output.
//
// Notes:       Concatenates each line of the file with an end of line delimiter ( /).

using System;
using System.Collections.Generic;
using System.IO;

namespace CDT.Core
{
    class Inputter
    {
        private string FileName;
        public Inputter()
        {
            FileName = "../../input.txt";
        }
        public LinkedList<string> Input()
        {
            LinkedList<string> output = new LinkedList<string>();
            try
            {
                // Open StreamReader to read from file FileName.
                StreamReader sr = new StreamReader(FileName);
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
