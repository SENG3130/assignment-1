// File Name:   Output.cs
// Developer:   Brad Turner
//
// Description: Writes the contents of the linkedlist input to file specified by FileName.
//
// Notes:       For safety waits until input's first node is "/", as a signal for no more input to the linkedlist.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CDT.PipeAndFilter
{
    class Output
    {
        private string FileName;
        private LinkedList<string> input;

        public Output()
        {
            this.FileName = "../../../output.txt";

            input = new LinkedList<string>();
        }

        public Output(string[] args)
        {
            if (args.Length > 0)
            {
                FileName = "../../../" + args[0];
            }

            else
            {
                FileName = "../../../output.txt";
            }

            this.input = new LinkedList<string>();
        }

        public Output(string[] args, LinkedList<string> input)
        {
            if (args.Length > 0)
            {
                FileName = "../../../" + args[0];
            }

            else
            {
                FileName = "../../../output.txt";
            }

            this.input = input;
        }

        public Output(LinkedList<string> input)
        {
            this.FileName = "../../../output.txt";

            this.input = input;
        }

        public void WriteToFile()
        {
#if DEBUG
            Console.WriteLine(DateTime.Now + " Output.WriteToFile started");
#endif

            // Wait for input to have a size > 0.
            while (input.Count == 0)
            {
                Thread.Sleep(20);
            }

            // Wait to receive the signal ("/") that there is no more to input.
            while (input.First() != "/")
            {
                Thread.Sleep(20);
            }
            // Remove the signal.
            input.RemoveFirst();

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
            Console.WriteLine(DateTime.Now + " Output.WriteToFile finished");
#endif
        }
    }
}
