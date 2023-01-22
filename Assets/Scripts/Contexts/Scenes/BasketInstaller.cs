using Basket;
using Zenject;

namespace Contexts.Scenes
{
    public class BasketInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<SignalBasketFilledWithRightFood>();
            Container.DeclareSignal<SignalBasketFull>();
        }
    }
}