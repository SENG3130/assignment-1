// File Name:   InteractiveLayer.cs
// Developer:   Jordan Cork
//
// Description: Layer to handle user interaction i.e. adding/deleting to/from the list, printing KWIC list
//              and quitting application. Also stores the the basic (UnKWICed list)
//

using System;
using System.Collections.Generic;

namespace CDT.InteractiveKWIC
{
    class InteractiveLayer
    {

        InterLogicLayer interLL = new InterLogicLayer();

        // Stores the input list
        LinkedList<string> basicList = new LinkedList<string>();

        // Runs the Interactive KWIC application
        public void run()
        {
            string option = "";
            string line = "";

            while (true)
            {
                // User Prompt
                Console.Write("Add, Delete, Print, Quit: ");

                option = Console.ReadLine();

                if (object.Equals(option, "a")) // Add line
                {
                    Console.Write("> ");

                    line = Console.ReadLine();

                    addLine(line);
                }
                else if (object.Equals(option, "d")) // Delete line
                {
                    Console.Write("> ");

                    line = Console.ReadLine();

                    deleteLine(line);
                }
                else if (object.Equals(option, "p")) // Print KWIC list
                {
                    printKWIC();
                }
                else if (object.Equals(option, "q")) // quit program
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
        }

        private void addLine(string line)
        {
            basicList.AddLast(line + " /");
        }

        private void deleteLine(string line)
        {
            basicList.Remove(line + " /");
        }

        private void printKWIC()
        {
            LinkedList<string> KWIClist = interLL.getKWIClist(basicList);

            foreach (string node in KWIClist)
            {
                Console.WriteLine(node);
            }
        }
    }
}