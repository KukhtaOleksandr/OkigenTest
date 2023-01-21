using Food;
using StateMachine.Base;
using UnityEngine;
using Zenject;

namespace Architecture.StateMachine
{
    public class WinState : IState
    {
        [Inject] private FoodSpawner _foodSpawner;
        [Inject] private FoodClickHandler _foodClickHandler;
        [Inject] private SignalBus _signalBus;
        public void Enter()
        {
            GameObject.Destroy(_foodSpawner);
            _foodClickHandler=null;
            _signalBus.Fire<SignalGameFinished>();
        }

        public void Exit()
        {
            
        }
    }
}