// File Name:   BlackboardMain.cs
// Developer:   Jordan Cork
//
// Description: Implements the KWIC System using the Blackboard Architecture
//
// Notes:     

using System;

namespace CDT.BlackBoard
{
    class BlackboardMain
    {

        static void Main(string[] args)
        {

            // Blackboard initialised which stores the List of Sentences
            Blackboard blackboard = new Blackboard();

            // Initialise Agents which access blackboard
            InputReader inputReader = new InputReader(blackboard);
            BlackboardRotator rotator = new BlackboardRotator(blackboard);
            Sorter sorter = new Sorter(blackboard);
            BlackboardOutputer outputer = new BlackboardOutputer(blackboard);

            try
            {
                // Performs KWIC Operations
                inputReader.readInput();
                rotator.rotate();
                sorter.sort();
                outputer.outputList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }


    }
}