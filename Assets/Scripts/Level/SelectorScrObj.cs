using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "Level Selector Settings", menuName = "Settings/Level Selector")]
    public class SelectorScrObj : ScriptableObject
    {
        [Header("Materials")]
        public Material standard;
        public Material over;
        public Material blocked;
    }
}
