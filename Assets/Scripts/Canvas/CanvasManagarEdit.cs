using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManagarEdit : MonoBehaviour
{
    [SerializeField] private Button blockButton, wheelButton, removeButton;
    void Start()
    {
        blockButton.onClick.AddListener(ClickBlockButton);
        wheelButton.onClick.AddListener(ClickWheelButton);
        removeButton.onClick.AddListener(ClickRemoveButton);
    }
    private void ClickBlockButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        if (GameManager.instance.GetCurrentBlockType != GameManager.BlockType.Block)
            GameManager.instance.SetCurrentBlockType(GameManager.BlockType.Block);
    }
    private void ClickWheelButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        if (GameManager.instance.GetCurrentBlockType != GameManager.BlockType.Wheel)
            GameManager.instance.SetCurrentBlockType(GameManager.BlockType.Wheel);
    }
    private void ClickRemoveButton(){
        GameManager.instance.SetCanCreate(false);
        GameManager.instance.SetCanDestroy(true);
    }
}
