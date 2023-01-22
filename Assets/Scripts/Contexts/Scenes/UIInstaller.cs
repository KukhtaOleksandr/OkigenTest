using Architecture.Services;
using TMPro;
using UI;
using UnityEngine;
using Zenject;

namespace Contexts.Scenes
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private Color _rightColor;
        [SerializeField] private Color _wrongColor;
        [SerializeField] private WinPanelUI _winPanelUI;
        [SerializeField] private TextMeshProUGUI _basketTextPrefab;
        [SerializeField] private Canvas _basketCanvas;
        public override void InstallBindings()
        {
            Container.DeclareSignal<SignalNextLevelBtnClicked>();
            Container.BindInstance(_basketTextPrefab).WhenInjectedInto<ShowProductAddedTextService>();
            Container.BindInstance(_basketCanvas).WhenInjectedInto<ShowProductAddedTextService>();
            Container.BindInstance(_winPanelUI);
            Container.BindInstance(_rightColor).WithId("RightColor").WhenInjectedInto<ShowProductAddedTextService>();
            Container.BindInstance(_wrongColor).WithId("WrongColor").WhenInjectedInto<ShowProductAddedTextService>();
        }
    }
}