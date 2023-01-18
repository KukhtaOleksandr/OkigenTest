using Conveyor;
using UnityEngine;
using Zenject;

namespace Contexts.Scenes
{
    public class ConveyorInstaller : MonoInstaller
    {
        [SerializeField] private ConveyorLineMovement _conveyorLineMovement;
        public override void InstallBindings()
        {
            Container.BindInstance(_conveyorLineMovement).AsSingle().WhenInjectedInto<ConveyorLinesFactory>();
            Container.Bind<ConveyorLinesFactory>().AsSingle().NonLazy();
        }
    }
}