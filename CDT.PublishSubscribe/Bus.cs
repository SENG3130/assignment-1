// File Name:   Bus.cs
// Developer:   Mitchell Davis
//
// Description: Implements a publish-subscribe bus taking an event name and action (with optional data parameter).

using System;
using System.Collections.Generic;

namespace CDT.PublishSubscribe
{
    static class Bus
    {
        // Store a mapping of strings to delegate functions
        private static Dictionary<string, Dictionary<int, Action<object>>> subscriptions;

        private static int lastIndex;

        static Bus()
        {
            subscriptions = new Dictionary<string, Dictionary<int, Action<object>>>();
            lastIndex = 0;
        }

        public static int Register(string eventName, Action<object> callback)
        {
            int index = lastIndex++;

            Dictionary<int, Action<object>> callbacks;

            if (!subscriptions.TryGetValue(eventName, out callbacks))
            {
                callbacks = new Dictionary<int, Action<object>>();

                subscriptions.Add(eventName, callbacks);
            }

            callbacks.Add(index, callback);
            
            return index;
        }

        public static void Deregister(string eventName, int index)
        {
            Dictionary<int, Action<object>> callbacks;

            if (subscriptions.TryGetValue(eventName, out callbacks))
            {
                callbacks.Remove(index);
            }
        }

        public static void Fire(string eventName, object data = null)
        {
            Dictionary<int, Action<object>> callbacks;

            if (subscriptions.TryGetValue(eventName, out callbacks))
            {
                foreach(KeyValuePair<int, Action<object>> item in callbacks)
                {
                    Action<object> action = item.Value;

                    action(data);
                }
            }
        }
    }
}
