using System.Collections.Generic;
using Basket;
using DG.Tweening;
using Food;
using StateMachine.Base;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Zenject;

namespace Human.StateMachine
{
    public class GrabProductState : IState
    {
        private const float Duration = 0.4f;
        private const string GrabProductTrigger = "GrabProduct";
        
        private TwoBoneIKConstraint _constraint;
        private Animator _animator;
        private RigBuilder _rigBuilder;
        private List<Transform> _basketPositions;
        private Transform _target;
        private SignalBus _signalBus;
        private BasketContainer _basketContainer;
        private Transform _human;

        public GrabProductState(TwoBoneIKConstraint constraint, Animator animator, RigBuilder rigBuilder,
                                List<Transform> basketPositions, Transform target, SignalBus signalBus, BasketContainer basketContainer, Transform human)
        {
            _constraint = constraint;
            _animator = animator;
            _rigBuilder = rigBuilder;
            _basketPositions = basketPositions;
            _target = target;
            _signalBus = signalBus;
            _basketContainer = basketContainer;
            _human = human;
        }

        public void Enter()
        {
            _signalBus.Subscribe<SignalOnGrabbedProduct>(OnGrabbedProduct);
            GrabProduct(_target);
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<SignalOnGrabbedProduct>(OnGrabbedProduct);
        }

        public void GrabProduct(Transform target)
        {
            _target = target.parent;
            _constraint.data.target = _target.GetComponent<Product>().GrabTarget;
            _rigBuilder.Build();
            _animator.SetTrigger(GrabProductTrigger);
        }

        private void OnGrabbedProduct()
        {
            ProductMovement productMovement = _target.GetComponent<ProductMovement>();
            GameObject.Destroy(productMovement);

            Transform basketPosition = _basketPositions[0];

            _target.transform.DOScale(0.8f, Duration);

            _target.transform.DOMove(basketPosition.position, Duration).OnComplete(() => OnMovedProductToBasket());
            _basketPositions.Remove(basketPosition);
            _basketPositions.Add(basketPosition);
        }

        private void OnMovedProductToBasket()
        {
            Product product = _target.GetComponent<Product>();
            product.ModelRigidBody.isKinematic = false;
            product.ModelCollider.isTrigger = false;
            _signalBus.Fire<MonoSignalChangedState>(new MonoSignalChangedState() 
            {
                State = new IdleState(_animator,_signalBus,_constraint,_rigBuilder,_basketPositions,_target,_basketContainer,_human)
            });
        }
    }
}