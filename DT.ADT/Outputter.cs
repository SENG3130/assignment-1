// File Name:   Outputter.cs
// Developer:   Brad Turner
//
// Description: Writes the contents of the linkedlist input to file specified by FileName.
//
// Notes:       

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.ADT
{
    class Outputter
    {
        private string FileName;

        public Outputter()
        {
            FileName = "../../output.txt";
        }

        public void Output(LinkedList<string> input)
        {
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
        }
    }
}
