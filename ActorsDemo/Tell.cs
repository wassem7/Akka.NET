using Akka.Actor;

namespace ActorsDemo
{
    public class HumanActor : Akka.Actor.ReceiveActor
    {
        public HumanActor()
        {
            Receive<VocalGreeting>(v =>
            {
                Context.Sender.Tell(new VocalGreeting("Hello there"));
            });
        }
    }
}
