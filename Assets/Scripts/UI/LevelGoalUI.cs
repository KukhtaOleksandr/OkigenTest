using Architecture.Services.Base;
using Level;
using TMPro;
using UnityEngine;
using Zenject;

public class LevelGoalUI : MonoBehaviour
{
    [Inject] private ILevelGoalGeneratorService levelGoalGeneratorService;

    private TextMeshProUGUI _goalText;

    void Start()
    {
        _goalText = GetComponent<TextMeshProUGUI>();
        LevelGoal levelGoal = levelGoalGeneratorService.GetLevelGoal();
        if (levelGoal.FoodType == FoodType.Apple || levelGoal.FoodType == FoodType.Banana)
        {
            _goalText.text = "Collect " + levelGoal.Count + " " + levelGoal.FoodType.ToString() + "s";
        }
        else if (levelGoal.FoodType == FoodType.Strawberry)
        {
            _goalText.text = "Collect " + levelGoal.Count + " Strawberries";
        }
    }
}
