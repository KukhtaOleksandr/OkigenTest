using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Food;

namespace Animations.Human
{
    public class Human : MonoBehaviour
    {
        [SerializeField] private TwoBoneIKConstraint _constraint;
        [SerializeField] private Animator _animator;
        [SerializeField] private RigBuilder _rigBuilder;
        [SerializeField] private Transform _basket;
        [SerializeField] private List<Transform> _basketPositions;
        [SerializeField] private Transform _hand;

        private Transform _target;
        public void GrabProduct(Transform target)
        {
            _target = target.parent;
            _constraint.data.target = _target.GetComponent<Product>().GrabTarget;
            _rigBuilder.Build();
            _animator.SetTrigger("GrabProduct");
        }

        public void OnGrabbedProduct()
        {
            ProductMovement productMovement = _target.GetComponent<ProductMovement>();
            GameObject.Destroy(productMovement);

            Transform basketPosition = _basketPositions[0];

            _target.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.4f);

            _target.transform.DOMove(basketPosition.position, 0.4f).OnComplete(() => OnMovedProductToBasket());
            //_basketPositions.Remove(basketPosition);
            //_basketPositions.Add(basketPosition);
        }

        private void OnMovedProductToBasket()
        {
            //_constraint.data.target = null;
            //_rigBuilder.Build();
            Product product = _target.GetComponent<Product>();
            product.Model.GetComponent<Rigidbody>().isKinematic = false;
            product.Model.GetComponent<Collider>().isTrigger = false;
        }
    }
}