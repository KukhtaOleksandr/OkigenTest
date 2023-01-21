using System.Collections.Generic;
using Basket;
using DG.Tweening;
using StateMachine.Base;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Zenject;

namespace Human.StateMachine
{
    public class WalkToConveyorState : IState
    {
        private const string WalkTrigger = "Walk";
        private const string WalkFinishTrigger = "WalkFinish";
        private const int Duration = 3;

        private BasketContainer _basketContainer;
        private Transform _walkTo;
        private Transform _human;
        private Animator _animator;
        private SignalBus _signalBus;
        private TwoBoneIKConstraint _constraint;
        private RigBuilder _rigBuilder;
        private List<Transform> _basketPositions;
        private Transform _target;

        public WalkToConveyorState(Transform walkTo, Transform human, Animator animator, SignalBus signalBus,
        TwoBoneIKConstraint constraint, RigBuilder rigBuilder, List<Transform> basketPositions, Transform target, BasketContainer basketContainer)
        {
            _animator = animator;
            _human = human;
            _walkTo = walkTo;
            _signalBus = signalBus;
            _constraint = constraint;
            _rigBuilder = rigBuilder;
            _basketPositions = basketPositions;
            _target = target;
            _basketContainer = basketContainer;
        }

        public void Enter()
        {
            _animator.SetTrigger(WalkTrigger);
            _human.DOMove(_walkTo.position, Duration).SetEase(Ease.Linear).OnComplete(() => WalkedToConveyor());
        }

        public void Exit()
        {

        }

        private void WalkedToConveyor()
        {
            _animator.SetTrigger(WalkFinishTrigger);
            _signalBus.Fire<MonoSignalChangedState>(new MonoSignalChangedState()
            {
                State = new IdleState(_animator, _signalBus, _constraint, _rigBuilder, 
                _basketPositions, _target, _basketContainer, _human)
            });
        }
    }
}