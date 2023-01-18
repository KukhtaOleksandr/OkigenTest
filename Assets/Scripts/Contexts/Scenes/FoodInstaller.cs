using System.Collections.Generic;
using Food;
using UnityEngine;
using Zenject;

namespace Contexts.Scenes
{
    public class FoodInstaller : MonoInstaller
    {
        [SerializeField] private List<ProductBase> _food;
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _layerMask;
        public override void InstallBindings()
        {
            Container.BindInstance(_camera).WhenInjectedInto<FoodClickHandler>();
            Container.BindInstance(_layerMask).WhenInjectedInto<FoodClickHandler>();
            Container.BindInstance(_food).WhenInjectedInto<FoodFactory>();
            Container.BindInterfacesAndSelfTo<FoodFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<FoodClickHandler>().AsSingle().NonLazy();
        }
    }
}