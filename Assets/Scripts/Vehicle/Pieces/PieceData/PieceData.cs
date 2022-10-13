using UnityEngine;
using Block;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PieceData", menuName = "Pieces/PieceData", order = 1)]
public class PieceData : ScriptableObject
{
    [Tooltip("The Pieces of the game")]
    [SerializeField] private List<GameObject> pieces;

    [Tooltip("The Mesh of wheel")]
    [SerializeField] private GameObject wheelBlock;
    [Tooltip("The WheelCollider GameObject of wheel")]
    [SerializeField] private GameObject wheelCollider;

    [Tooltip("The Material that shows when you mouse over block in DestroyMode")]
    [SerializeField]private Material destroyMaterial;
    public GameObject GetWheelBlock => wheelBlock;
    public GameObject GetWheelCollider => wheelCollider;
    public Material GetDestroyMaterial => destroyMaterial;

    public GameObject FindPiece(string pieceName){
        GameObject obj = null;
        foreach (GameObject item in pieces)
        {
            if (item.GetComponent<BlockBehavior>().settings.label == pieceName)
            {
                obj = item;
            }
        }
        return obj;
    }


}
