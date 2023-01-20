using System.Collections.Generic;
using Architecture.Services.Base;
using Level;
using UnityEngine;
using Zenject;

namespace Architecture.Services
{
    public class LevelGoalGeneratorService : ILevelGoalGeneratorService, IInitializable
    {
        [SerializeField] private List<FoodType> _food;

        public void Initialize()
        {
            _food = new List<FoodType>();
            _food.Add(FoodType.Apple);
            _food.Add(FoodType.Banana);
            _food.Add(FoodType.Strawberry);
        }

        public LevelGoal Generate()
        {
            LevelGoal levelGoal = new LevelGoal();
            
        }
    }
}