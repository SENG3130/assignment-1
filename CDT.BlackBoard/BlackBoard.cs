// File Name:   Blackboard.cs
// Developer:   Jordan Cork
//
// Description: Implements the Blackboard form the Blackboard Architecture which
//              stores a List with access/mutate methods to be used in the KWIC System
// Notes:     

using System;
using System.Collections.Generic;

namespace CDT.BlackBoard
{
    class Blackboard
    {

        LinkedList<String> list;

        public Blackboard()
        {
            list = new LinkedList<String>();
        }

        public LinkedList<String> getList()
        {
            return list;
        }

        public void setList(LinkedList<String> list)
        {
            this.list = list;
        }


    }
}