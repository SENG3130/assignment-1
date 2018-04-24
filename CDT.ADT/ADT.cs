// File Name:   ADT.cs
// Developer:   Brad Turner
//
// Description: Implements an abstract data type build of a standard KWIC indexing system.
//
// Notes: 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDT.Core;

namespace CDT.ADT
{
    class ADT
    {
        static void Main(string[] args)
        {
            Inputter input = new Inputter(args);
            Rotator rot = new Rotator();
            Indexor idx = new Indexor();
            Outputter output = new Outputter(args);

            output.Output(idx.Index(rot.Rotate(input.Input())));
            //disadvantage have to know the signatures to all methods otherwise cant do this^.

        }
    }
}
