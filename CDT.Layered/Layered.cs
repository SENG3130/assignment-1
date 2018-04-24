// File Name:   Layered.cs
// Developer:   Brad Turner
//
// Description: Implements a stardard 3-tier layered build of a standard KWIC indexing system..
//
// Notes:       

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDT.Layered
{
    class Layered
    {
        static void Main(string[] args)
        {
            LogicLayer ll = new LogicLayer();
            ll.Logicify(args);
        }
    }
}
