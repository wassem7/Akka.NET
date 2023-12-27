using System;
using Akka.Actor;

namespace ActorsDemo
{
    public class Actor : Akka.Actor.ReceiveActor
    {
        private int _count;

        public Actor()
        {
            Receive<VocalGreeting>(v =>
            {
                _count++;
                Console.WriteLine($"I've met {_count} people");
            });
        }
    }
}
