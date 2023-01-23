using UI;
using UnityEngine;
using Zenject;

namespace UI
{
    public class NextLevelBtn : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;

        public void OnNextLevelBtnClicked()
        {
            _signalBus.Fire<SignalNextLevelBtnClicked>();
        }
    }
}