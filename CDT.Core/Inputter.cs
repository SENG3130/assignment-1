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

        public Inputter(string[] args)
        {
            if (args.Length > 0)
            {
                FileName = "../../../" + args[0];
            }

            else
            {
                FileName = "../../../input.txt";
            }
        }

        public Inputter()
        {
            FileName = "../../../input.txt";
        }

        public LinkedList<string> Input()
        {
#if DEBUG
            Console.WriteLine(DateTime.Now + " Inputter.Input started");
#endif

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

#if DEBUG
            Console.WriteLine(DateTime.Now + " Inputter.Input finished");
#endif

            return output;
        }
    }
}
