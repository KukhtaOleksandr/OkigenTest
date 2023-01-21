using StateMachine.Base;
using Zenject;

namespace Architecture.StateMachine
{
    public class BootStrapState : IState
    {
        [Inject] private SignalBus _signalBus;

        public void Enter()
        {
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() { State = new InPlayModeState() });
        }

        public void Exit()
        {
            
        }
    }
}