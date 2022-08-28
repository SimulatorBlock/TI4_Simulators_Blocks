using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]private GameObject selectedBlock;
    [SerializeField]private GameObject mainBlock;
    [SerializeField]private Material destroyMaterial;

    [Header("Booleans")]
    [SerializeField] private bool isEditing = false;
    [SerializeField] private bool canDestroy = false;
    [SerializeField] private bool canCreate = false;

    void Awake(){
        instance = this;
    }
    void Start(){
        SetSelectedBlock(GetMainBlock());
    }

    public void SetSelectedBlock(GameObject block){
        selectedBlock = block;
    }
    public GameObject GetSelectedBlock(){
        if (selectedBlock == null)
        {
            SetSelectedBlock(GetMainBlock());
        }
        return selectedBlock;
    }
    public GameObject GetMainBlock(){
        return mainBlock;
    }
    public Material GetDestroyMaterial(){
        return destroyMaterial;
    }
    public bool IsEditing(){
        return isEditing;
    }
    public bool IsDetroying(){
        return canDestroy;
    }
    public bool IsCreating(){
        return canCreate;
    }
    
    public void SetEditMode(bool set)
    {
        isEditing = set;
    }
    public void SetCanCreate(bool set)
    {
        canCreate = set;
    }
    public void SetCanDestroy(bool set)
    {
        canDestroy = set;
    }
}
