using System.Collections.Generic;
using Architecture.Services.Base;
using Food;
using UnityEngine;
using Zenject;

public class BasketContainer : MonoBehaviour
{
    [Inject] private IShowProductAddedTextService showProductAddedTextService;
    private List<Product> _food;
    private Product _lastProduct;

    void Start()
    {
        _food = new List<Product>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null)
        {
            if (other.transform.parent.TryGetComponent(out Product product))
            {
                if (product != _lastProduct)
                {
                    _food.Add(product);
                    showProductAddedTextService.Show();
                }
                _lastProduct=product;
            }
        }
    }
}
