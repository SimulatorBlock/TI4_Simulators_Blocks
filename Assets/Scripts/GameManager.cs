using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum BlockType{Block, Wheel}
    [SerializeField] private BlockType currentBlockType;
    [SerializeField]private GameObject selectedBlock;
    [SerializeField]private GameObject mainBlock;

    #region Controlls
    [Header("Booleans")]
    [SerializeField] private bool isEditing = false;
    [SerializeField] private bool canDestroy = false;
    [SerializeField] private bool canCreate = false;
    #endregion

    void Awake(){
        instance = this;
    }
    void Start(){
        SetSelectedBlock(GetMainBlock);
    }

    #region CurrentBlockType
    public BlockType GetCurrentBlockType => currentBlockType;
    public void SetCurrentBlockType(BlockType type){
        currentBlockType = type;
    }
    #endregion

    #region SelectedBlock
    public GameObject GetSelectedBlock(){
        if (selectedBlock == null)
        {
            SetSelectedBlock(GetMainBlock);
        }
        return selectedBlock;
    }
    public void SetSelectedBlock(GameObject block){
        selectedBlock = block;
    }
    #endregion

    #region MainBlock
    public GameObject GetMainBlock => mainBlock;
    #endregion

    #region Controlls
    
    #region IsEditing
    public bool GetIsEditing => isEditing;
    public void SetIsEditing(bool set)
    {
        isEditing = set;
    }
    #endregion

    #region CanDestroy
    public bool GetCanDetroy => canDestroy;
    public void SetCanDestroy(bool set)
    {
        canDestroy = set;
    }
    #endregion

    #region CanCreate
    public bool GetCanCreate => canCreate;
    public void SetCanCreate(bool set)
    {
        canCreate = set;
    }
    #endregion

    #endregion
}
