using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Menu
{
    public class Main : MonoBehaviour
    {
        public void GoToLevels()
        {
            SceneManager.LoadScene("Levels");
        }

        public void GoToSettings()
        {
            SceneManager.LoadScene("Settings");
        }

        public void GoToCredits()
        {
            SceneManager.LoadScene("Credits");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
