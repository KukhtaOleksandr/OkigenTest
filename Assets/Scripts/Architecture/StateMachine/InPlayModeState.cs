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
            _signalBus.Subscribe<SignalBasketFull>(GameLoose);
        }


        public void Exit()
        {
            _signalBus.Unsubscribe<SignalBasketFilledWithRightFood>(GameWin);
            _signalBus.Unsubscribe<SignalBasketFull>(GameLoose);
        }

        private void GameWin()
        {
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() { State = new WinState() });
        }

        private void GameLoose()
        {
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() { State = new LooseState() });
        }
    }
}