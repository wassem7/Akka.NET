using System;

namespace ActorsDemo
{
    public class ReceiveActor : Akka.Actor.ReceiveActor
    {
        public ReceiveActor(object message)
        {
            Receive<VocalGreeting>(x => Console.WriteLine("Hello there !"));
        }
    }
}
