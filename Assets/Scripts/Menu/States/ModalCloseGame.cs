using UnityEngine;

namespace Menu.States
{
    public class ModalCloseGame : IMenuState
    {
        private readonly Menu menu;
        
        public ModalCloseGame(Menu menu)
        {
            this.menu = menu;
        }

        public void Enter()
        {
            menu.modalCloseGame.SetActive(true);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            IMenuState newState = new InGame(menu);
            menu.SetState(newState);
        }

        public void Exit() {}
    }
}
