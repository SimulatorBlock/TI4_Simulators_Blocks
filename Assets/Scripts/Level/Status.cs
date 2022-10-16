using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class Status : MonoBehaviour
    {
        private readonly List<Constants.Levels> completedLevels = new();
        public static Status Instance;

        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            CompleteLevel(Constants.Levels.Level_01);
        }

        public void CompleteLevel(Constants.Levels level)
        {
            completedLevels.Add(level);
        }

        public bool IsAvailableLevel(Constants.Levels level)
        {
            return completedLevels.Contains(level);
        }
    }
}
