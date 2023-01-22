using System.Threading.Tasks;
using Architecture.Services.Base;
using DG.Tweening;
using Food;
using StateMachine.Base;
using UI;
using UnityEngine;
using Zenject;

namespace Architecture.StateMachine
{
    public class WinState : IState
    {
        [Inject] private FoodSpawner _foodSpawner;
        [Inject] private ISceneLoaderService _sceneLoaderService;
        [Inject] private FoodClickHandler _foodClickHandler;
        [Inject] private WinPanelUI _winPanel;
        [Inject] private SignalBus _signalBus;
        [Inject] private Camera _camera;

        private readonly Vector3 _cameraMovePosition = new Vector3(0, -0.5f, 0.3f);
        private const int _cameraAnimationDuration = 1;

        public void Enter()
        {
            GameObject.Destroy(_foodSpawner);
            _foodClickHandler = null;
            _winPanel.gameObject.SetActive(true);

            AnimateCamera();

            _signalBus.Fire<SignalGameFinished>();
            _signalBus.Subscribe<SignalNextLevelBtnClicked>(OnNextLevelButtonClicked);
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<SignalNextLevelBtnClicked>(OnNextLevelButtonClicked);
        }

        private void AnimateCamera()
        {
            _camera.transform.DOMove(_cameraMovePosition, _cameraAnimationDuration).SetRelative();
            _camera.transform.DORotate(new Vector3(30, 0, 0), _cameraAnimationDuration);
        }

        private async void OnNextLevelButtonClicked()
        {
            await Task.Delay(250);
            _sceneLoaderService.Load(Services.Scenes.MainScene);
        }

    }
}