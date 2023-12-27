using System;
using Akka.Actor;

namespace ActorsDemo
{
    public class StashActor : Akka.Actor.UntypedActor, IWithUnboundedStash
    {
        public IStash Stash { get; set; }

        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }

        public void Initializing(object message)
        {
            if (message is ReadComplete)
            {
                Become(Initialized);
                Stash.UnstashAll();
            }
            else
                Stash.Stash();
        }

        public void Initialized(object message)
        {
            //Process messages
        }
    }
}
