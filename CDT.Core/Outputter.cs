// File Name:   Outputter.cs
// Developer:   Brad Turner
//
// Description: Writes the contents of the linkedlist input to file specified by FileName.
//
// Notes:       

using System;
using System.Collections.Generic;
using System.IO;

namespace CDT.Core
{
    class Outputter
    {
        private string FileName;

        public Outputter(string[] args)
        {
            if (args.Length > 1)
            {
                FileName = "../../../" + args[2];
            }

            else
            {
                FileName = "../../../output.txt";
            }
        }

        public Outputter()
        {
            FileName = "../../../output.txt";
        }

        public void Output(List<string> input)
        {
#if DEBUG
            Console.WriteLine(DateTime.Now + " Outputter.Output started");
#endif

            // Write each node to file.
            try
            {
                StreamWriter sw = new StreamWriter(FileName);

                foreach (string node in input)
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

#if DEBUG
            Console.WriteLine(DateTime.Now + " Outputter.Output finished");
#endif
        }
    }
}
