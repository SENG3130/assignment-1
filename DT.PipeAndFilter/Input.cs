﻿// File Name:   Input.cs
// Developer:   Brad Turner
//
// Description: Reads the file specified by FileName, and appends to the linkedlist output.
//
// Notes:       Concatenates each line of the file with an end of line delimiter ( /).

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.PipeAndFilter
{
    class Input
    {
        private LinkedList<string> output;
        private string FileName;

        public Input()
        {
            FileName = "../../input.txt";
            this.output = new LinkedList<string>();
        }
        public Input(LinkedList<string> output)
        {
            FileName = "../../input.txt";
            this.output = output;
        }

        public void ReadFromFile()
        {
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
            
        }
    }
}
