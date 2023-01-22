using UnityEngine;
using Zenject;

namespace UI
{
    public class RestartBtnUI : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;

        public void OnRestartBtnClicked()
        {
            _signalBus.Fire<SignalRestartBtnClicked>();
        }
    }
}