using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AutoPilot;

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
    [SerializeField] private Button wheelSimpleButton;
    [SerializeField] private Button wheelSimpleBackButton;
    [SerializeField] private Button wheelSimpleFrontButton;
    [SerializeField] private Button wheelTopButton;
    [SerializeField] private Button wheelTopBackButton;
    [SerializeField] private Button wheelTopFrontButton;
    [Space(10)]
    
    [Header("Empty's")]
    [SerializeField] private GameObject standard;
    [SerializeField] private GameObject engine;
    [SerializeField] private GameObject wheel;


    private void Update() {
        if (Input.GetMouseButtonDown(1))//Cancels create and destroy
        {
            GameManager.instance.SetCanCreate(false);
            GameManager.instance.SetCanDestroy(false);
            engine.SetActive(false);
            wheel.SetActive(false);
            standard.SetActive(false);
        }
    }

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
        wheelSimpleButton.onClick.AddListener(ClickWheelSimpleButton);
        wheelSimpleBackButton.onClick.AddListener(ClickWheelSimpleBackButton);
        wheelSimpleFrontButton.onClick.AddListener(ClickWheelSimpleFrontButton);
        wheelTopButton.onClick.AddListener(ClickWheelTopButton);
        wheelTopBackButton.onClick.AddListener(ClickWheelTopBackButton);
        wheelTopFrontButton.onClick.AddListener(ClickWheelTopFrontButton);
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
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    private void ClickStandardLevel1Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("StandardLevel1");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    private void ClickStandardLevel2Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("StandardLevel2");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    private void ClickStandardLevel3Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("StandardLevel3");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    private void ClickEngineButton(){
        standard.SetActive(false);
        wheel.SetActive(false);
        engine.SetActive(true);
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel1");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    private void ClickEngineLevel1Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel1");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    private void ClickEngineLevel2Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel2");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    private void ClickEngineLevel3Button(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("EngineLevel3");
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
    }
    private void ClickWheelButton(){
        standard.SetActive(false);
        engine.SetActive(false);
        wheel.SetActive(true);
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelSimple");
        GameManager.instance.SetPlaceHolder("WheelSimple");
    }
    private void ClickWheelSimpleButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelSimple");
        GameManager.instance.SetPlaceHolder("WheelSimple");
    }
    private void ClickWheelSimpleBackButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelSimpleBack");
        GameManager.instance.SetPlaceHolder("WheelSimpleBack");
    }
    private void ClickWheelSimpleFrontButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelSimpleFront");
        GameManager.instance.SetPlaceHolder("WheelSimpleFront");
    }
    private void ClickWheelTopButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelTop");
        GameManager.instance.SetPlaceHolder("WheelTop");
    }
    private void ClickWheelTopBackButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelTopBack");
        GameManager.instance.SetPlaceHolder("WheelTopBack");
    }
    private void ClickWheelTopFrontButton(){
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.SetCanCreate(true);
        GameManager.instance.SetPieceToCreate("WheelTopFront");
        GameManager.instance.SetPlaceHolder("WheelTopFront");
    }
    private void ClickRemoveButton(){
        GameManager.instance.SetCanCreate(false);
        GameManager.instance.SetCanDestroy(true);
    }

    private void ClickPlayButton(){
        SceneManager.LoadScene(EditModeLevelController.instance.currentScene);
        GameManager.instance.SetIsEditing(false);
        GameManager.instance.SetCanCreate(false);
        GameManager.instance.SetCanDestroy(false);
        GameManager.instance.GetVehicle.GetComponent<Vehicle>().Start();
        GameManager.instance.GetVehicle.transform.position = new Vector3(1000,1000,1000);
        // FindObjectOfType<VehicleChanger>().VehicleObject = GameManager.instance.GetVehicle;
    }
}
