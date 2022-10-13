using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManagarEdit : MonoBehaviour
{
    [Header("Defaults")]
    [SerializeField] private Button standardButton;
    [SerializeField] private Button engineButton;
    [SerializeField] private Button wheelButton;
    [SerializeField] private Button removeButton;
    [SerializeField] private Button playButton;
    [Space(10)]

    [Header("Standard")]
    [SerializeField] private Button standardLevel1Button;
    [SerializeField] private Button standardLevel2Button;
    [SerializeField] private Button standardLevel3Button;
    [Space(10)]
    
    [Header("Engine")]
    [SerializeField] private Button engineLevel1Button;
    [SerializeField] private Button engineLevel2Button;
    [SerializeField] private Button engineLevel3Button;
    [Space(10)]
    
    [Header("Wheel")]
    [SerializeField] private Button wheelLevel1Button;
    [Space(10)]
    
    [Header("Empty's")]
    [SerializeField] private GameObject standard;
    [SerializeField] private GameObject engine;
    [SerializeField] private GameObject wheel;

    void Start()
    {
        #region  Standard
        standardButton.onClick.AddListener(ClickStandardButton);
        standardLevel1Button.onClick.AddListener(ClickStandardLevel1Button);
        standardLevel2Button.onClick.AddListener(ClickStandardLevel2Button);
        standardLevel3Button.onClick.AddListener(ClickStandardLevel3Button);
        #endregion

        #region Engine
        engineButton.onClick.AddListener(ClickEngineButton);
        engineLevel1Button.onClick.AddListener(ClickEngineLevel1Button);
        engineLevel2Button.onClick.AddListener(ClickEngineLevel2Button);
        engineLevel3Button.onClick.AddListener(ClickEngineLevel3Button);
        #endregion

        #region Wheel
        wheelButton.onClick.AddListener(ClickWheelButton);
        wheelLevel1Button.onClick.AddListener(ClickWheelLevel1Button);
        #endregion

        removeButton.onClick.AddListener(ClickRemoveButton);
        playButton.onClick.AddListener(ClickPlayButton);
    }
    private void ClickStandardButton(){
        engine.SetActive(false);
        wheel.SetActive(false);
        standard.SetActive(true);
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("StandardLevel1");
    }
    private void ClickStandardLevel1Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("StandardLevel1");
    }
    private void ClickStandardLevel2Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("StandardLevel2");
    }
    private void ClickStandardLevel3Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("StandardLevel3");
    }
    private void ClickEngineButton(){
        standard.SetActive(false);
        wheel.SetActive(false);
        engine.SetActive(true);
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel1");
    }
    private void ClickEngineLevel1Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel1");
    }
    private void ClickEngineLevel2Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel2");
    }
    private void ClickEngineLevel3Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel3");
    }
    private void ClickWheelButton(){
        standard.SetActive(false);
        engine.SetActive(false);
        wheel.SetActive(true);
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelLevel1");
    }
    private void ClickWheelLevel1Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelLevel1");
    }
    private void ClickRemoveButton(){
        GameManager.instance.SetCanCreate(false);
        GameManager.instance.SetCanDestroy(true);
    }

    private void ClickPlayButton(){
        // GameManager.instance.SetIsEditing(false);
        // GameManager.instance.SetCanCreate(false);
        // GameManager.instance.SetCanDestroy(false);
        SceneManager.LoadScene(1);
    }
    
}
