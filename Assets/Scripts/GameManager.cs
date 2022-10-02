using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum BlockType{Block, Wheel, Engine}
    [SerializeField] private BlockType currentBlockType;

    #region GameObjects
    [SerializeField]private GameObject selectedBlock;
    [SerializeField]private GameObject mainBlock;
    [SerializeField]private GameObject vehicle;
    #endregion

    #region Controls
    [Header("Booleans")]
    [SerializeField] private bool isEditing = false;
    [SerializeField] private bool canDestroy = false;
    [SerializeField] private bool canCreate = false;
    #endregion

    #region Lists
    [SerializeField] private List<Block> blocks;
    [SerializeField] private List<Engine> engines;
    [SerializeField] private List<WheelCollider> wheelColliders;
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

    #region  Vehicle
    public GameObject GetVehicle => vehicle;
    #endregion

    #region Controls
    
    #region IsEditing
    public bool GetIsEditing => isEditing;
    public void SetIsEditing(bool set)
    {
        isEditing = set;
    }
    #endregion

    #region CanDestroy
    public bool GetCanDestroy => canDestroy;
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

    #region Lists
    public List<Block> GetBlocks => blocks;
    public void AddBlock(Block block){
        blocks.Add(block);
    }
    public List<Engine> GetEngines => engines;
    public void AddEngine(Engine engine){
        engines.Add(engine);
    }
    public List<WheelCollider> GetWheelColliders => wheelColliders;
    public void AddWheelCollider(WheelCollider wheelCollider){
        wheelColliders.Add(wheelCollider);
    }
    #endregion
}
