using StateMachine.Base;
using Zenject;

namespace Architecture.StateMachine
{
    public class LoadPlayModeState : IState
    {
        [Inject] private SignalBus _signalBus;

        public void Enter()
        {
            //_signalBus.Fire<SignalChangedState>(new SignalChangedState() { State = new HandleRowClickState() });
        }

        public void Exit()
        {
            
        }
    }
}