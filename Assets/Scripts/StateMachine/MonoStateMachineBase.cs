using UnityEngine;
using Zenject;
using System;

namespace StateMachine.Base
{
    public abstract class MonoStateMachineBase : MonoBehaviour
    {
        protected IState _currentState;

        [Inject]
        protected readonly DiContainer _container;
        [Inject]
        protected readonly SignalBus _signalBus;

        void OnEnable()
        {
            _signalBus.Subscribe<MonoSignalChangedState>(OnChangedState);
            Initialize();
        }

        void OnDisable()
        {
            _signalBus.Unsubscribe<MonoSignalChangedState>(OnChangedState);
        }

        private void OnChangedState(MonoSignalChangedState args)
        {
            //ChangeState(args.State.GetType());
            ChangeState(args.State);
        }

        protected void ChangeState<TState>() where TState : IState
        {
            ChangeState(typeof(TState));
        }

        protected void ChangeState(IState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
        protected void ChangeState(Type state)
        {
            _currentState?.Exit();
            _currentState = CreateState(state);
            _currentState.Enter();
        }

        private IState CreateState(Type state)
        {
            return _container.Instantiate(state) as IState;
        }

        protected abstract void Initialize();
    }

}