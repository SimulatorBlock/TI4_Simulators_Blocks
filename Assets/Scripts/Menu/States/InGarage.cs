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
            SceneManager.LoadScene("SampleCarCreation");
        }
        
        public void Enter()
        {
            menu.inGarage.SetActive(true);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.C)) return;
            
            IMenuState newState = new InGame(menu);
            menu.SetState(newState);
        }

        public void Exit() {}
    }
}
