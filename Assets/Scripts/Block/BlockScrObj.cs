using UnityEngine;

namespace BlockSystem
{
    [CreateAssetMenu(fileName = "Block Standard", menuName = "Block Type/Standard", order = 10)]
    public class BlockScrObj : ScriptableObject
    {
        public string label;
        public GameObject prefab;

        [Space]
        [Header("Physic Data")]
        public int mass;
    }
}
