using Basket;
using StateMachine.Base;
using Zenject;

namespace Architecture.StateMachine
{
    public class InPlayModeState : IState
    {
        [Inject] private SignalBus _signalBus;

        public void Enter()
        {
            _signalBus.Subscribe<SignalBasketFilledWithRightFood>(GameWin);
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<SignalBasketFilledWithRightFood>(GameWin);
        }

        private void GameWin()
        {
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() { State = new WinState() });
        }
    }
}