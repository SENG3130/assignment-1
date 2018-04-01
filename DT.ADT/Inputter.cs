using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.ADT
{
    class Inputter
    {
        public LinkedList<string> Input()
        {
            // This is a stub.
            LinkedList<string> list = new LinkedList<string>();
            list.AddLast("Pattern-Orientated Software Architecture /");
            list.AddLast("Software Architecture /");
            list.AddLast("Introducing Design Patterns /");
            return list;
        }
    }
}
