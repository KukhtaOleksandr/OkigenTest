using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WinPanelUI : MonoBehaviour
{
    void OnEnable()
    {
        Animate();
    }

    public void Animate()
    {
        GetComponent<Image>().DOFade(0.3f, 1);
    }
}
