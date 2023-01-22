using Architecture.Services.Base;
using Architecture.StateMachine;
using DG.Tweening;
using Level;
using TMPro;
using UnityEngine;
using Zenject;

public class LevelGoalUI : MonoBehaviour
{
    private const int StartYPosition = 150;
    private const int EndYPosition = -212;
    private const int Duration = 1;
    [Inject] private ILevelGoalGeneratorService levelGoalGeneratorService;
    [Inject] private SignalBus _signalBus;

    private TextMeshProUGUI _goalText;
    private RectTransform _rectTransform;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _goalText = GetComponent<TextMeshProUGUI>();
        LevelGoal levelGoal = levelGoalGeneratorService.GetLevelGoal();
        if (levelGoal.Count == 1)
        {
            _goalText.text = "Collect " + levelGoal.Count + " " + levelGoal.FoodType.ToString();
        }
        else if (levelGoal.FoodType == FoodType.Apple || levelGoal.FoodType == FoodType.Banana)
        {
            _goalText.text = "Collect " + levelGoal.Count + " " + levelGoal.FoodType.ToString() + "s";
        }
        else if (levelGoal.FoodType == FoodType.Strawberry)
        {
            _goalText.text = "Collect " + levelGoal.Count + " Strawberries";
        }

        DoAppearAnimation();
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<SignalGameFinished>(OnGameFinished);
    }

    void OnDisable()
    {
        _signalBus.Unsubscribe<SignalGameFinished>(OnGameFinished);
    }

    private void DoAppearAnimation()
    {
        _rectTransform.DOAnchorPosY(StartYPosition, 0);
        _rectTransform.DOAnchorPosY(EndYPosition, Duration);
        _goalText.DOFade(0, 0);
        _goalText.DOFade(1, Duration);
    }

    private void OnGameFinished()
    {
        // _rectTransform.DOAnchorPosY(StartYPosition, Duration);
         _goalText.DOFade(0, Duration/2);
    }
}
