// File Name:   Program.cs
// Developer:   Brad Turner
//
// Description: Implements a pipe filter build of a standard KWIC indexing system using threading.
//
// Notes:       

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DT.PipeAndFilter
{
    class PipeAndFilter
    {
        static void Main(string[] args)
        {
            

            Output output = new Output("output.txt");

            LinkedList<String> pipe1, pipe2, pipe3;
            pipe1 = new LinkedList<string>();
            pipe2 = new LinkedList<string>();
            pipe3 = new LinkedList<string>();

            Rotator filter1 = new Rotator(pipe1, pipe2);
            Indexor filter2 = new Indexor(pipe2, pipe3);

            pipe1.AddLast("Pattern-Orientated Software Architecture /");
            pipe1.AddLast("Software Architecture /");
            pipe1.AddLast("Introducing Design Patterns /");

            Thread rotateThread1 = new Thread(delegate () { filter1.Start(); });
            Thread indexThread1  = new Thread(delegate () { filter2.Start(); });

            // Start threads.
            rotateThread1.Start();
            indexThread1.Start();
            

            
            
    
            //Console.WriteLine("With " + filter1.Count + " permutations");
            Console.ReadKey();
        }
    }
}
