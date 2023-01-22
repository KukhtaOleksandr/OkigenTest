using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WinPanelUI : MonoBehaviour
{
    [SerializeField] private LevelPassedText _levelPassedText;
    [SerializeField] private LeanButton _nextLevelBtn;

    void OnEnable()
    {
        Animate();
    }

    public void Animate()
    {
        GetComponent<Image>().DOFade(0.3f, 1);
    }
}
