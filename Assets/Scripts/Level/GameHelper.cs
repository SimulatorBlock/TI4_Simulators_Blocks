using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHelper : MonoBehaviour
{
    [SerializeField] private Constants.Levels level;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) GoToLevelSelector();
        if (Input.GetKeyDown(KeyCode.R)) ReloadCurrentLevel();
    }

    private static void GoToLevelSelector()
    {
        SceneManager.LoadScene(Constants.Menus.Levels.ToString());
    }

    private void ReloadCurrentLevel()
    {
        var scene = SceneManager.GetSceneByName(level.ToString());
        SceneManager.LoadScene(scene.buildIndex);
    }
}
