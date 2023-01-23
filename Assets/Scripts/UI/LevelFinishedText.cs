using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelFinishedText : MonoBehaviour
    {
        private const int StartYPosition = 150;
        private const int EndYPosition = -212;
        private const int Duration = 1;

        private TextMeshProUGUI _text;
        private RectTransform _rectTransform;

        void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _text = GetComponent<TextMeshProUGUI>();
            DoAnimation();
        }

        public void DoAnimation()
        {
            //_rectTransform.DOAnchorPosY(StartYPosition, 0);
            //_rectTransform.DOAnchorPosY(EndYPosition, Duration);
            //_text.DOFade(0, 0);
            //_text.DOFade(1, Duration);
            _rectTransform.DOScale(new Vector3(0.1f, 0.1f, 1), 0.5f).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }
}