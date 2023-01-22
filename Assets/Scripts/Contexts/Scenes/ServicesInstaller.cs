using Architecture.Services;
using Architecture.StateMachine;
using StateMachine.Base;
using Zenject;

namespace Contexts.Scenes
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<SignalChangedState>();
            Container.DeclareSignal<SignalGameFinished>();
            
            Container.BindInterfacesAndSelfTo<ShowProductAddedTextService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelGoalGeneratorService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoaderService>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayStateMachine>().AsSingle().NonLazy();
            Container.BindInitializableExecutionOrder<PlayStateMachine>(-20);
        }
    }
}