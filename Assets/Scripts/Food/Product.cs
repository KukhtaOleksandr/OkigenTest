using UnityEngine;

namespace Food
{
    public class Product : MonoBehaviour
    {
        [SerializeField] private FoodType _foodType;
        [SerializeField] private Transform _appleModel;
        [SerializeField] private Transform _grabTarget;

        public FoodType FoodType { get => _foodType; }
        public Transform AppleModel { get => _appleModel; }
        public Transform GrabTarget { get => _grabTarget; }
    }
}