using System.Net.Mime;
using StateMachine.Base;
using Zenject;
using UnityEngine;

namespace Architecture.StateMachine
{
    public class BootStrapState : IState
    {
        [Inject] private SignalBus _signalBus;

        public void Enter()
        {
            Application.targetFrameRate=60;
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() { State = new InPlayModeState() });
        }

        public void Exit()
        {
            
        }
    }
}