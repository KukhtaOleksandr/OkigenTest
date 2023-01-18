using System;
using Input;
using UnityEngine;
using Zenject;

namespace Food
{
    public class FoodClickHandler : IInitializable, IDisposable
    {
        [Inject] private Camera _camera;
        [Inject] private LayerMask _layerMask;
        [Inject] private SignalBus _signalBus;

        public void Initialize()
        {
           _signalBus.Subscribe<SignalMouseClicked>(HandleClick);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SignalMouseClicked>(HandleClick);
        }
        
        private void HandleClick(SignalMouseClicked args)
        {
            Ray ray = _camera.ScreenPointToRay(args.MousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, _layerMask))
            {
                Debug.Log(hit.collider.GetComponent<Product>().FoodType);
            }
        }
    }
}