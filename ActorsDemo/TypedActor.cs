using System;
using Akka.Actor;

namespace ActorsDemo
{
    public class TypedActor : Akka.Actor.TypedActor, IHandle<VocalGreeting>
    {
        public void Handle(VocalGreeting greeting)
        {
            Console.WriteLine("Hello there !");
        }
    }
}
