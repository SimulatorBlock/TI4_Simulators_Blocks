﻿using UnityEngine;

namespace BlockSystem
{
    [CreateAssetMenu(fileName = "Block Engine", menuName = "Block Type/Engine", order = 20)]
    public class EngineScriptableObject : BlockScrObj
    {
        public int torque;
    }
}
