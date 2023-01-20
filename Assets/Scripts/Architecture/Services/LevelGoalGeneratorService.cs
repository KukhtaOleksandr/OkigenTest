using System.Collections.Generic;
using Architecture.Services.Base;
using Level;
using UnityEngine;
using Zenject;

namespace Architecture.Services
{
    public class LevelGoalGeneratorService : ILevelGoalGeneratorService, IInitializable
    {
        private LevelGoal _levelGoal;

        public void Initialize()
        {
            Generate();
        }

        public LevelGoal GetLevelGoal()
        {
            return _levelGoal;
        }

        private void Generate()
        {
            _levelGoal = new LevelGoal();
            _levelGoal.FoodType = (FoodType)Random.Range(0, (float)FoodType.Last);
            _levelGoal.Count = Random.Range(1, 6);
        }
    }
}