using Animations.Human;
using UnityEngine;
using Zenject;

namespace Contexts.Scenes
{
    public class HumanInstaller : MonoInstaller
    {
        [SerializeField] private Human _human;
        public override void InstallBindings()
        {
            Container.BindInstance(_human).AsSingle();
        }
    }
}