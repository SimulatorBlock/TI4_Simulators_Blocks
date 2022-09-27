using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlaceHolder : MonoBehaviour
{
    [SerializeField] private bool hasPieceOver = false;

    public bool GetHasPieceOver => hasPieceOver;
    public void SetHasPieceOver(bool value){
        hasPieceOver = value;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Block")
        {
            SetHasPieceOver(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Block")
        {
            SetHasPieceOver(false);
        }
    }

}
