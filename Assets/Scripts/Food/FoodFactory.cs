using System.Collections.Generic;
using Zenject;
using UnityEngine;

namespace Food
{
    public class FoodFactory : IInitializable
    {
        private readonly Vector3 CreationPosition = new Vector3(2, 0.345f, 0.111f);
        private readonly Vector3 CreationRotation = new Vector3(-90, 0, 0);

        [Inject] private List<ProductBase> _food;
        [Inject] private DiContainer _container;

        private Dictionary<FoodType, ProductBase> _foodPairs;

        public void Create(FoodType foodType)
        {
            var product = _container.InstantiatePrefabForComponent<Product>(_foodPairs[foodType].ProductPrefab, 
                                                CreationPosition, 
                                                Quaternion.identity,null);
            product.Model.rotation = Quaternion.Euler(_foodPairs[foodType].Rotation);
        }

        public void Initialize()
        {
            _foodPairs = new Dictionary<FoodType, ProductBase>();
            foreach (var product in _food)
            {
                _foodPairs.Add(product.FoodType, product);
            }
        }
    }
}