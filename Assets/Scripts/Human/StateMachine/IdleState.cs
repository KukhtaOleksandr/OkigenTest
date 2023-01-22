using System.Collections.Generic;
using Basket;
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
        private BasketContainer _basketContainer;
        private SignalBus _signalBus;
        private TwoBoneIKConstraint _constraint;
        private MultiAimConstraint _bodyConstraint;
        private RigBuilder _rigBuilder;
        private List<Transform> _basketPositions;
        private Transform _target;
        private Transform _human;

        public IdleState(Animator animator, SignalBus signalBus, TwoBoneIKConstraint constraint,
        RigBuilder rigBuilder, List<Transform> basketPositions, Transform target, BasketContainer basketContainer, Transform human, 
        MultiAimConstraint bodyConstraint)
        {
            _animator = animator;
            _signalBus = signalBus;
            _constraint = constraint;
            _rigBuilder = rigBuilder;
            _basketPositions = basketPositions;
            _target = target;
            _basketContainer = basketContainer;
            _human = human;
            _bodyConstraint = bodyConstraint;
        }
        public void Enter()
        {
            _signalBus.Subscribe<SignalFoodClicked>(OnSignalFoodClicked);
            _signalBus.Subscribe<SignalBasketFilledWithRightFood>(OnBasketFilledWithRightFood);
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<SignalFoodClicked>(OnSignalFoodClicked);
            _signalBus.Unsubscribe<SignalBasketFilledWithRightFood>(OnBasketFilledWithRightFood);
        }

        private void OnBasketFilledWithRightFood()
        {
            _signalBus.Fire<MonoSignalChangedState>(new MonoSignalChangedState()
            {
                State = new DanceState(_basketContainer, _human, _animator)
            });
        }

        private void OnSignalFoodClicked(SignalFoodClicked args)
        {
            _signalBus.Fire<MonoSignalChangedState>(new MonoSignalChangedState()
            {
                State = new GrabProductState(_constraint, _animator, _rigBuilder, _basketPositions,
                args.Product.parent.GetComponent<Product>().GrabTarget, _signalBus,_basketContainer,_human,_bodyConstraint)
            });
        }
    }
}