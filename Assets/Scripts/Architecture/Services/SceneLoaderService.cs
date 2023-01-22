using System.Collections.Generic;
using Architecture.Services.Base;
using UnityEngine.SceneManagement;
using Zenject;

namespace Architecture.Services
{
    public class SceneLoaderService : ISceneLoaderService, IInitializable
    {
        Dictionary<Scenes, string> _scenes;

        public void Initialize()
        {
            _scenes = new Dictionary<Scenes, string>();
            _scenes.Add(Scenes.MainScene, "MainScene");
        }

        public void Load(Scenes scene)
        {
            SceneManager.LoadScene(_scenes[scene]);
        }
    }

    public enum Scenes
    {
        MainScene
    }
}