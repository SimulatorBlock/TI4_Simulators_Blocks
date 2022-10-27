using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class EditModeLevelController : MonoBehaviour
{
    public static EditModeLevelController instance;
    public string currentScene;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start() {
    }
    private void Update() {
        if (SceneManager.GetActiveScene().name != "SampleCarCreation" && currentScene != SceneManager.GetActiveScene().name)
        {
            currentScene = SceneManager.GetActiveScene().name;
        }
        if (Input.GetKeyDown(KeyCode.C) && SceneManager.GetActiveScene().name != "SampleCarCreation")
        {
            if (GameManager.instance)
            {
                GameManager.instance.GetVehicle.transform.position = new Vector3(0,0,0);
                GameManager.instance.SetIsEditing(true);
            }
            SceneManager.LoadScene("SampleCarCreation");
        }
    }
}
