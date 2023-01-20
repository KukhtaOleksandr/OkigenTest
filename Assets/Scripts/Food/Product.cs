using UnityEngine;

namespace Food
{
    public class Product : MonoBehaviour
    {
        [SerializeField] private FoodType _foodType;
        [SerializeField] private Transform _model;
        [SerializeField] private Transform _grabTarget;
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private Collider _collider;

        public FoodType FoodType { get => _foodType; }
        public Transform Model { get => _model; }
        public Transform GrabTarget { get => _grabTarget; }
        public Rigidbody ModelRigidBody { get => _rigidBody; }
        public Collider ModelCollider { get => _collider; }
    }
}