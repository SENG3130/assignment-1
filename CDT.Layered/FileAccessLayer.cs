// File Name:   FileAccessLayer.cs
// Developer:   Brad Turner
//
// Description: Reads and writes to the files specified by inputFile and/or outputFile.
//
// Notes:       Concatenates each input line of the file with an end of line delimiter ( /).

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDT.Layered
{
    class FileAccessLayer
    {
        private string inputFile, outputFile;

        public FileAccessLayer(string[] args)
        {
            if (args.Length > 0)
            {
                inputFile = "../../../" + args[0];
            }

            else
            {
                inputFile = "../../../input.txt";
            }

            if (args.Length > 1)
            {
                outputFile = "../../../" + args[0];
            }

            else
            {
                outputFile = "../../../output.txt";
            }
        }

        public FileAccessLayer()
        {
            inputFile = "../../../input.txt";
            outputFile = "../../../output.txt";
        }

        public LinkedList<string> ReadFromFile()
        {
            LinkedList<string> output = new LinkedList<string>();
            try
            {
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

        public void WriteToFile(LinkedList<string> list)
        {
            // Write each node to file.
            try
            {
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
