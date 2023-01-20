using System.Collections.Generic;
using System.Linq;
using Architecture.Services.Base;
using Food;
using Level;
using UnityEngine;
using Zenject;

public class BasketContainer : MonoBehaviour
{
    [Inject] private IShowProductAddedTextService showProductAddedTextService;
    [Inject] private ILevelGoalGeneratorService levelGoalGeneratorService;
    [SerializeField] private Transform _hand;
    private List<Product> _food;
    private Product _lastProduct;
    private LevelGoal _levelGoal;

    void Start()
    {
        _food = new List<Product>();
        _levelGoal = levelGoalGeneratorService.GetLevelGoal();
    }

    void Update()
    {
        //transform.position = new Vector3(_hand.position.x, _hand.position.y - 0.4f, _hand.position.z);
    }

    void OnTriggerEnter(Collider other)
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
                showProductAddedTextService.Show();
                List<Product> goalProducts = _food.Where(x => x.FoodType == _levelGoal.FoodType).ToList();
                if (goalProducts.Count == _food.Count)
                    Debug.Log("WIN!!!");
            }
            _lastProduct = product;
        }
    }
}

