using Architecture.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Contexts.Scenes
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private TextMeshProUGUI _basketTextPrefab;
        [SerializeField] private Canvas _basketCanvas;
        public override void InstallBindings()
        {
            Container.BindInstance(_basketTextPrefab).WhenInjectedInto<ShowProductAddedTextService>();
            Container.BindInstance(_basketCanvas).WhenInjectedInto<ShowProductAddedTextService>();
        }
    }
}