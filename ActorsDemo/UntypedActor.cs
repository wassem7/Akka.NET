using System;
using Akka.Actor;

namespace ActorsDemo
{
    public class UntypedActor : Akka.Actor.UntypedActor
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
