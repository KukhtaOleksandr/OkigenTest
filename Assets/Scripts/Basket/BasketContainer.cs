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
        [Inject] private IShowProductAddedTextService showProductAddedTextService;
        [Inject] private ILevelGoalGeneratorService levelGoalGeneratorService;
        [Inject] private SignalBus _signalBus;
        [SerializeField] private Rigidbody _basketRigidBody;

        public Rigidbody BasketRigidBody { get => _basketRigidBody; }

        private List<Product> _food;
        private Product _lastProduct;
        private LevelGoal _levelGoal;

        void Start()
        {
            _food = new List<Product>();
            _levelGoal = levelGoalGeneratorService.GetLevelGoal();
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
                    if (_food.Count == 8 && goalProducts.Count != _levelGoal.Count)
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
                    if (product.FoodType == _levelGoal.FoodType)
                        showProductAddedTextService.Show(true);
                    else
                        showProductAddedTextService.Show(false);
                }
                _lastProduct = product;
            }
        }
    }
}