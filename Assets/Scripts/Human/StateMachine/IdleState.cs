using System.Collections.Generic;
using Food;
using StateMachine.Base;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Zenject;

namespace Human.StateMachine
{
    public class IdleState : IState
    {
        private Animator _animator;
        private SignalBus _signalBus;
        private TwoBoneIKConstraint _constraint;
        private RigBuilder _rigBuilder;
        private List<Transform> _basketPositions;
        private Transform _target;

        public IdleState(Animator animator, SignalBus signalBus,
        TwoBoneIKConstraint constraint, RigBuilder rigBuilder, List<Transform> basketPositions, Transform target)
        {
            _animator = animator;
            _signalBus = signalBus;
            _constraint = constraint;
            _rigBuilder = rigBuilder;
            _basketPositions = basketPositions;
            _target = target;
        }
        public void Enter()
        {
            _signalBus.Subscribe<SignalFoodClicked>(OnSignalFoodClicked);
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<SignalFoodClicked>(OnSignalFoodClicked);
        }

        public void OnSignalFoodClicked(SignalFoodClicked args)
        {
            _signalBus.Fire<MonoSignalChangedState>(new MonoSignalChangedState()
            {
                State = new GrabProductState(_constraint, _animator, _rigBuilder, _basketPositions,
                args.Product.parent.GetComponent<Product>().GrabTarget,_signalBus)
            });
        }
    }
}