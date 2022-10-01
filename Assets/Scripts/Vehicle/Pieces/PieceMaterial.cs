using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMaterial : MonoBehaviour
{
    [Header("Materials")]
    [Space(10)]
    [Tooltip("The Destroy Material, Gets on start by the GameManager.cs")]
    [SerializeField] private Material destroyMaterial;
    [Tooltip("The Default Material, Gets on start by the block")]
    [SerializeField] private Material defaultMaterial;

    // [Header("Utility")]    
    // [Space(10)]
    // [Tooltip("The MainBlock, Gets on start by the GameManager.cs")]
    // [SerializeField] private GameObject mainBlock;

    [Header("Data")]    
    [Space(10)]
    [SerializeField] private PieceData pieceData;

    private void Start() {
        // mainBlock = GameManager.instance.GetMainBlock;
        defaultMaterial = GetComponentInChildren<Renderer>().material;
        destroyMaterial = pieceData.GetDestroyMaterial;
    }

    private void Update(){
        ResetMaterial();
    }

    /// <summary>
    ///     This function resets the block to the default material, 
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Observation
    ///     </para>
    ///     <para>
    ///         The diference of this and the SetToDefaultMaterial is that this function will be called on the update function and this function was made for we can reset material by exiting the EditMode or the DestroyMode without remove mouse over the block that we suposed want to delete.
    ///     </para>
    /// </remarks>
    public void ResetMaterial()
    {
        if ((!GameManager.instance.GetCanDestroy || !GameManager.instance.GetIsEditing) && (GetCurrentMaterial() != defaultMaterial))
        {
            SetToDefaultMaterial();
        }
    }

    /// <summary>
    ///     This function set the block to the destroy material.
    /// </summary>
    private void SetToDestroyMaterial()
    {
        this.gameObject.GetComponentInChildren<Renderer>().material = destroyMaterial;
    }

    /// <summary>
    ///     This function set the block to the default material.
    /// </summary>
    private void SetToDefaultMaterial()
    {
        this.gameObject.GetComponentInChildren<Renderer>().material = defaultMaterial;
    }

    /// <summary>
    ///     This function gets the current material used by block.
    /// </summary>
    private Material GetCurrentMaterial()
    {
        return this.gameObject.GetComponentInChildren<Renderer>().material;
    }

    /// <summary>
    ///     This is native function that check if the mouse exited over the block, i used this function to reset the block to the default material.
    /// </summary>
    private void OnMouseExit()
    {
        if (GameManager.instance.GetCanDestroy /* && (this.gameObject != mainBlock) */)
        {
            SetToDefaultMaterial();
        }
    }

    /// <summary>
    ///     This is native function that check if the mouse is over the block, i used this function to set the block to the destroy material.
    /// </summary>
    private void OnMouseEnter()
    {
        if (GameManager.instance.GetCanDestroy /* && (this.gameObject != mainBlock) */)
        {
            SetToDestroyMaterial();
        }
    }
}
