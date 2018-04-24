// File Name:   PipeAndFilter.cs
// Developer:   Brad Turner
//
// Description: Implements a pipe filter build of a standard KWIC indexing system using threading.
//
// Notes:       

using System;
using System.Collections.Generic;
using System.Threading;

namespace CDT.PipeAndFilter
{
    class PipeAndFilter
    {
        static void Main(string[] args)
        {
            // Creates pipes as linkedlists.
            LinkedList<String> pipe1, pipe2, pipe3;
            pipe1 = new LinkedList<string>();
            pipe2 = new LinkedList<string>();
            pipe3 = new LinkedList<string>();

            // Initialises classes and links them in a pipe filter context.
            Input input = new Input(args, pipe1);
            Output output = new Output(args, pipe3);
            Rotator filter1 = new Rotator(pipe1, pipe2);
            Indexor filter2 = new Indexor(pipe2, pipe3);
            
            // Creates threads to execute almost simultaenously. 
            Thread inputThread1 = new Thread(delegate () { input.ReadFromFile(); });
            Thread rotateThread1 = new Thread(delegate () { filter1.Rotate(); });
            Thread indexThread1  = new Thread(delegate () { filter2.Index(); });
            Thread outputThread1 = new Thread(delegate () { output.WriteToFile(); });

            // Start said threads.
            inputThread1.Start();
            rotateThread1.Start();
            indexThread1.Start();
            outputThread1.Start();

        }
    }
}
