using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Menu
{
    public class BackToMenu : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoToMainMenu();
            }
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("Main");
        }
    }
}
