using UnityEngine;

[CreateAssetMenu(fileName = "PieceData", menuName = "ScriptableObjects/PieceData", order = 1)]
public class PieceData : ScriptableObject
{
    [Tooltip("The GameObject ('Block') default")]
    [SerializeField] private GameObject defaultBlock;

    [Tooltip("The Mesh of wheel")]
    [SerializeField] private GameObject wheelBlock;
    [Tooltip("The WheelCollider GameObject of wheel")]
    [SerializeField] private GameObject wheelCollider;
    [Tooltip("The GameObject of engine")]
    [SerializeField] private GameObject engineBlock;

    [Tooltip("The Material that shows when you mouse over block in DestroyMode")]
    [SerializeField]private Material destroyMaterial;
    
    public GameObject GetDefaultBlock => defaultBlock;
    public GameObject GetWheelBlock => wheelBlock;
    public GameObject GetWheelCollider => wheelCollider;
    public GameObject GetEngineBlock => engineBlock;
    public Material GetDestroyMaterial => destroyMaterial;


}
