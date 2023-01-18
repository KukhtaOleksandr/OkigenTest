using Input;
using Zenject;

namespace Contexts.Scenes
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<SignalMouseClicked>();
        }
    }
}