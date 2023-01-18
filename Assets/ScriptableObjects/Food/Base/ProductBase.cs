using Food;
using UnityEngine;

[CreateAssetMenu(menuName = "Food/Product")]
public class ProductBase : ScriptableObject
{
    [SerializeField] private FoodType _foodType;
    [SerializeField] private Product _productPrefab;
    [SerializeField] private Vector3 _rotation;

    public FoodType FoodType { get => _foodType; }
    public Product ProductPrefab { get => _productPrefab; }
    public Vector3 Rotation { get => _rotation; }
}

