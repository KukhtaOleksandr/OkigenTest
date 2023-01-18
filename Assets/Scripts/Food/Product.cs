using UnityEngine;

namespace Food
{
    public class Product : MonoBehaviour
    {
        [SerializeField] private FoodType _foodType;

        public FoodType FoodType { get => _foodType;}
    }
}