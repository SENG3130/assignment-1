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
            });

            Bus.Register("input-completed", delegate (object data) {
                Bus.Fire("rotate-completed", rotator.Rotate((LinkedList<string>)data));
            });

            Bus.Register("rotate-completed", delegate (object data) {
                Bus.Fire("index-completed", indexor.Index((LinkedList<string>)data));
            });

            Bus.Register("index-completed", delegate (object data) {
                outputter.Output((List<string>)data);

                Bus.Fire("output-completed");
            });

            Bus.Fire("start");
        }
    }
}
