using System;
using Akka.Actor;

namespace ActorsDemo
{
    public class PersonActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            if (message is VocalGreeting)
            {
                Console.WriteLine("Hello there");
            }
        }
    }
}
