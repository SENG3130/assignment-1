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

            LinkedList<String> list1, list2, list3;
            list1 = new LinkedList<string>();
            list2 = new LinkedList<string>();
            list3 = new LinkedList<string>();

            Rotator filter1 = new Rotator(list1, list2);
            Indexor filter2 = new Indexor(list2, list3);

            list1.AddLast("Pattern-Orientated Software Architecture /");
            list1.AddLast("Software Architecture /");
            list1.AddLast("Introducing Design Patterns /");

            Thread rotateThread1 = new Thread(delegate () { filter1.Rotate(); });
            Thread indexThread1  = new Thread(delegate () { filter2.Index(); });

            // Start threads.
            rotateThread1.Start();
            indexThread1.Start();
            

            
            
    
            //Console.WriteLine("With " + filter1.Count + " permutations");
            Console.ReadKey();
        }
    }
}
