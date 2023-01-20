using Human.StateMachine;
using StateMachine.Base;
using UnityEngine;
using Zenject;

namespace Contexts.Scenes
{
    public class HumanInstaller : MonoInstaller
    {
        [SerializeField] private Animations.Human.Human _human;
        [SerializeField] private HumanStateMachine _humanStateMachine;
        public override void InstallBindings()
        {
            Container.DeclareSignal<MonoSignalChangedState>();
            Container.DeclareSignal<SignalOnGrabbedProduct>();
            Container.BindInstance(_human).AsSingle();
            Container.BindInstance(_humanStateMachine).AsSingle();
        }
    }
}