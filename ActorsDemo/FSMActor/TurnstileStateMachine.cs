using System;
using ActorsDemo.FSM.Messages;
using ActorsDemo.FSMwithReceiveActor.Messages;
using Akka.Actor;

namespace ActorsDemo.FSMActor
{
    public class TurnstileStateMachine : FSM<ITurnstileState, ITurnstileData>
    {
        public TurnstileStateMachine()
        {
            When(
                Locked.Instance,
                @event =>
                {
                    if (@event.FsmEvent is TicketValidated)
                    {
                        Console.WriteLine("Ticket is validated");
                        return GoTo(UnLocked.Instance);
                    }

                    return Stay();
                }
            );

            When(
                UnLocked.Instance,
                @event =>
                {
                    if (@event.FsmEvent is TurnstilePushed || @event.FsmEvent is StateTimeout)
                    {
                        Console.WriteLine("User has pushed the turnstile");

                        Console.WriteLine("Turnstile is locking now");
                        return GoTo(Locked.Instance);
                    }

                    return Stay();
                },
                TimeSpan.FromSeconds(10)
            );

            OnTransition(OnTransition);
            StartWith(Locked.Instance, new TurnstileData());
            Initialize();
        }

        public void OnTransition(ITurnstileState prevState, ITurnstileState nextState)
        {
            if (prevState is Locked && nextState is UnLocked)
            {
                BarrierLock.UnLock();
            }
            else if (prevState is UnLocked && nextState is Locked)
            {
                BarrierLock.Lock();
            }
            else if (prevState is UnLocked && nextState is UnLocked)
            {
                Console.WriteLine("Barrier is still Unloacked !");
            }
            else if (prevState is Locked && nextState is Locked)
            {
                Console.WriteLine("Barrier is still locked !");
            }
        }
    }
}
