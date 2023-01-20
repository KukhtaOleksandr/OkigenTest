using TMPro;
using UnityEngine;
using Zenject;
using DG.Tweening;
using Architecture.Services.Base;

namespace Architecture.Services
{
    public class ShowProductAddedTextService : IShowProductAddedTextService
    {
        [Inject] private TextMeshProUGUI _textPrefab;
        [Inject] private Canvas _basketCanvas;
        public void Show()
        {
            Vector3 position = new Vector3(_basketCanvas.transform.position.x,
                                           _basketCanvas.transform.position.y - 0.3f,
                                           _basketCanvas.transform.position.z);
            TextMeshProUGUI text = GameObject.Instantiate(_textPrefab, position, Quaternion.identity, _basketCanvas.transform);
            text.DOFade(1, 0.3f);
            text.transform.DOScale(new Vector3(1.2f, 0.8f, 1), 0.3f);

            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(text.transform.DOMoveY(0.22f, 0.3f).SetRelative(true));
            mySequence.Append(text.transform.DOScale(1, 0.3f));
            mySequence.Append(text.transform.DOScale(0, 0.3f).OnComplete(() => GameObject.Destroy(text.gameObject)));
            mySequence.Insert(2, text.DOFade(0, 0.3f));
        }
    }
}