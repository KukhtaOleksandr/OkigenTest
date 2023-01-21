using System.Collections.Generic;
using Basket;
using StateMachine.Base;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Human.StateMachine
{
    public class HumanStateMachine : MonoStateMachineBase
    {
        [SerializeField] private Transform _walkTo;
        [SerializeField] private BasketContainer _basket;
        [SerializeField] private Animator _animator;
        [SerializeField] private TwoBoneIKConstraint _constraint;
        [SerializeField] private RigBuilder _rigBuilder;
        [SerializeField] private List<Transform> _basketPositions;
        [SerializeField] private Transform _target;
        protected override void Initialize()
        {
            ChangeState(new WalkToConveyorState(_walkTo, transform, _animator, _signalBus,
                                                _constraint,_rigBuilder,_basketPositions,_target,_basket));
        }

        public void OnGrabbedProduct()
        {
            _signalBus.Fire<SignalOnGrabbedProduct>();
        }
    }
}