using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Architecture.Services.Base;
using Food;
using Level;
using UnityEngine;
using Zenject;

namespace Basket
{
    public class BasketContainer : MonoBehaviour
    {
        private const int BasketCapacity = 7;
        [Inject] private IShowProductAddedTextService _showProductAddedTextService;
        [Inject] private ILevelGoalGeneratorService _levelGoalGeneratorService;
        [Inject] private SignalBus _signalBus;
        [SerializeField] private Rigidbody _basketRigidBody;

        private List<Product> _food;
        private Product _lastProduct;
        private LevelGoal _levelGoal;

        void Start()
        {
            _food = new List<Product>();
            _levelGoal = _levelGoalGeneratorService.GetLevelGoal();
        }

        async void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent != null)
            {
                if (other.transform.parent.TryGetComponent(out Product product))
                {
                    foreach (var p in _food)
                    {
                        if (p == product)
                            return;
                    }

                    _food.Add(product);
                    product.transform.parent = transform;
                    await Task.Delay(200);

                    product.ModelRigidBody.isKinematic = true;

                    List<Product> goalProducts = _food.Where(x => x.FoodType == _levelGoal.FoodType).ToList();

                    if (_food.Count == BasketCapacity && goalProducts.Count != _levelGoal.Count)
                    {
                        _signalBus.Fire<SignalBasketFull>();
                        return;
                    }
                    if (goalProducts.Count == _levelGoal.Count)
                    {
                        _signalBus.Fire<SignalBasketFilledWithRightFood>();
                        _lastProduct = product;
                        return;
                    }
                    if (ProductsAreIdenticalType(product.FoodType, _levelGoal.FoodType))
                        _showProductAddedTextService.Show(true);
                    else
                        _showProductAddedTextService.Show(false);
                }
                _lastProduct = product;
            }
        }

        private bool ProductsAreIdenticalType(FoodType product, FoodType other)
        {
            return product == other;
        }
    }
}