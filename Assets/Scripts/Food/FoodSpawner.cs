using System.Collections;
using UnityEngine;
using Zenject;

namespace Food
{
    public class FoodSpawner : MonoBehaviour
    {
        [Inject] private FoodFactory _foodFactory;
        private const float MinTime = 0.8f;
        private const float MaxTime = 1.6f;

        private bool isDestroyed = false;

        void Start()
        {
            StartCoroutine("Spawn");
        }

        private IEnumerator Spawn()
        {
            while (isDestroyed == false)
            {
                FoodType foodType = (FoodType)Random.Range(0, (float)FoodType.Last);
                _foodFactory.Create(foodType);
                yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
            }
        }

        void OnDestroy()
        {
            isDestroyed = true;
        }


    }
}