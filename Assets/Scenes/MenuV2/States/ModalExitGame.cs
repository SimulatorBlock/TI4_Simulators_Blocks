using UnityEngine;

namespace Scenes.MenuV2.States
{
    public class ModalExitGame : IMenuState
    {
        private readonly Menu menu;

        public ModalExitGame(Menu menu)
        {
            this.menu = menu;
        }

        public void Enter()
        {
            menu.modalExistGame.SetActive(true);
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
