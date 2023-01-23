using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UI
{
    public class WinPanelUI : MonoBehaviour
    {
        private const float Alpha = 0.3f;
        private const int Duration = 1;
        void OnEnable()
        {
            Animate();
        }

        public void Animate()
        {
            GetComponent<Image>().DOFade(Alpha, Duration);
        }
    }
}