using Architecture.Services;
using Zenject;

namespace Contexts.Scenes
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ShowProductAddedTextService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelGoalGeneratorService>().AsSingle();
        }
    }
}