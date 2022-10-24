using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHoldersData : MonoBehaviour
{
    [Tooltip("The PlaceHolders of the game")]
    [SerializeField] private List<GameObject> placeHolders = new();

    public GameObject FindPlaceHolder(string placeHolderName){
        GameObject obj = null;
        foreach (GameObject placeHolder in placeHolders)
        {
            if (placeHolder.name == placeHolderName)
                obj = placeHolder;
        }
        return obj;
    }
}
