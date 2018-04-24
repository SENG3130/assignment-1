// File Name:   PublishSubscribe.cs
// Developer:   Mitchell Davis
//
// Description: Implements a publish-subscribe build of a standard KWIC indexing system.

using System.Collections.Generic;
using CDT.Core;
using System;

namespace CDT.PublishSubscribe
{
    class PublishSubscribe
    {
        static void Main(string[] args)
        {
            Inputter inputter = new Inputter(args);
            Rotator rotator = new Rotator();
            Indexor indexor = new Indexor();
            Outputter outputter = new Outputter();

            Bus.Register("start", delegate (object data) {
                Bus.Fire("input-completed", inputter.Input());

                Console.WriteLine("input-completed");
            });

            Bus.Register("input-completed", delegate (object data) {
                Bus.Fire("rotate-completed", rotator.Rotate((LinkedList<string>)data));

                Console.WriteLine("rotate-completed");
            });

            Bus.Register("rotate-completed", delegate (object data) {
                Bus.Fire("index-completed", indexor.Index((LinkedList<string>)data));

                Console.WriteLine("index-completed");
            });

            Bus.Register("index-completed", delegate (object data) {
                outputter.Output((LinkedList<string>)data);

                Bus.Fire("output-completed");

                Console.WriteLine("output-completed");
            });

            Bus.Fire("start");
        }
    }
}
