using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.States
{
    public class InMain : IMenuState
    {
        private readonly Menu menu;

        public InMain(Menu menu)
        {
            this.menu = menu;
        }

        public void Enter()
        {
            menu.inMain.SetActive(true);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.KeypadEnter)) return;
            
            IMenuState newState = new InGame(menu);
            menu.SetState(newState);
            
            SceneManager.LoadScene(Constants.Levels.Forest_01.ToString());
        }

        public void Exit() {}
    }
}
