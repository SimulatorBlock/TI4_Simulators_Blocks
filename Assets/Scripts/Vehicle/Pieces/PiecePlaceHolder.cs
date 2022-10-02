using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlaceHolder : MonoBehaviour
{
    [SerializeField] private bool hasPieceOver = false;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material collisionMaterial;
    [SerializeField] private Vector3 sizeToDetect = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private Mesh meshToDraw;

    public bool GetHasPieceOver => hasPieceOver;
    public void SetHasPieceOver(bool value){
        hasPieceOver = value;
    }
    private void Start() {
        defaultMaterial = this.gameObject.GetComponentInChildren<Renderer>().material;
    }
    private void Update() {
        SetHasPieceOver(Physics.CheckBox(this.transform.position, sizeToDetect/2, this.transform.rotation/* , LayerMask.NameToLayer("Block") */));
        if(GetHasPieceOver)
            SetToCollisionMaterial();
        else
            SetToDefaultMaterial();
    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
        if(GetHasPieceOver)
            Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
        Gizmos.DrawMesh(meshToDraw, this.transform.position, this.transform.rotation, sizeToDetect);
    }
    
    /// <summary>
    ///     This function set the block to the collision material.
    /// </summary>
    private void SetToCollisionMaterial()
    {
        if (GetCurrentMaterial != collisionMaterial)
            this.gameObject.GetComponentInChildren<Renderer>().material = collisionMaterial;
    }
    /// <summary>
    ///     This function set the block to the default material.
    /// </summary>
    private void SetToDefaultMaterial()
    {
        if (GetCurrentMaterial != defaultMaterial)
            this.gameObject.GetComponentInChildren<Renderer>().material = defaultMaterial;
    }
    /// <summary>
    ///     This function gets the current material used by block.
    /// </summary>
    private Material GetCurrentMaterial => this.gameObject.GetComponentInChildren<Renderer>().material;
}
