using ActorsDemo.FSM.Messages;

namespace ActorsDemo.FSM
{
    public class TurnstileActor : Akka.Actor.ReceiveActor
    {
        public TurnstileActor()
        {
            Become(Locked);
        }

        void Locked()
        {
            Receive<TicketValidated>(x => Become(UnLocked));
            Receive<TurnstilePushed>(x => { });
        }

        void UnLocked()
        {
            Receive<TurnstilePushed>(x => Become(Locked));
            Receive<TicketValidated>(x => { });
        }
    }
}
