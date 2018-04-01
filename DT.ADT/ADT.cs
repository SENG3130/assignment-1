using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.ADT
{
    class ADT
    {
        static void Main(string[] args)
        {
            Inputter input = new Inputter();
            Rotator rot = new Rotator();
            Indexor idx = new Indexor();
            Outputter output = new Outputter();

            output.Output(idx.Index(rot.Rotate(input.Input())));
            //disadvantage have to know the signatures to all methods otherwise cant do this^.


            Console.ReadKey();
        }
    }
}
