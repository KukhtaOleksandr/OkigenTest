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
    public class LooseState : IState
    {
        [Inject] private FoodSpawner _foodSpawner;
        [Inject] private ISceneLoaderService _sceneLoaderService;
        [Inject] private FoodClickHandler _foodClickHandler;
        [Inject] private LoosePanelUI _loosePanel;
        [Inject] private SignalBus _signalBus;
        [Inject] private Camera _camera;

        private readonly Vector3 _cameraMovePosition = new Vector3(0, -0.5f, 0.3f);
        private const int _cameraAnimationDuration = 1;

        public void Enter()
        {
            GameObject.Destroy(_foodSpawner);
            _foodClickHandler = null;
            _loosePanel.gameObject.SetActive(true);

            AnimateCamera();

            _signalBus.Fire<SignalGameFinished>();
            _signalBus.Subscribe<SignalRestartBtnClicked>(RestartBtnClicked);
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<SignalRestartBtnClicked>(RestartBtnClicked);
        }

        private void AnimateCamera()
        {
            _camera.transform.DOMove(_cameraMovePosition, _cameraAnimationDuration).SetRelative();
            _camera.transform.DORotate(new Vector3(30, 0, 0), _cameraAnimationDuration);
        }

        private async void RestartBtnClicked()
        {
            await Task.Delay(250);
            _sceneLoaderService.Load(Services.Scenes.MainScene);
        }
    }
}