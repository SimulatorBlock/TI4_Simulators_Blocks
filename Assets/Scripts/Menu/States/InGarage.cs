using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.States
{
    public class InGarage : IMenuState
    {
        private readonly Menu menu;

        public InGarage(Menu menu)
        {
            this.menu = menu;
            AudioManager.Instance.Stop("Motor");
            // AudioManager.Instance.StopAll();
        }
        
        public void Enter()
        {
            menu.inGarage.SetActive(true);
            menu.garageBlocks.SetActive(true);
            if (SceneManager.GetActiveScene().name != "SampleCarCreation")
            {
                SceneManager.LoadScene("SampleCarCreation");
                EditModeLevelController.BackToEditScene();
            }
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.C)) return;
            AudioManager.Instance.StopAll();
            SceneManager.LoadScene(EditModeLevelController.instance.currentScene);
            IMenuState newState = new InGame(menu);
            menu.SetState(newState);
        }

        public void Exit() {}
    }
}
