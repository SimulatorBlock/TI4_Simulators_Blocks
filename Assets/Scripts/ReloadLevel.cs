using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    private const string LevelName = "FirstMission";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Reload();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Vehicle") Reload();
    }

    private static void Reload()
    {
        var scene = SceneManager.GetSceneByName(LevelName);
        SceneManager.LoadScene(scene.buildIndex);
    }
}
