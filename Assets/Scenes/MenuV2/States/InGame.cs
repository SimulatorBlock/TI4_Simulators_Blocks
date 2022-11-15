using UnityEngine;

namespace Scenes.MenuV2.States
{
    public class InGame : IMenuState
    {
        private readonly Menu menu;

        public InGame(Menu menu)
        {
            this.menu = menu;
        }
        
        public void Enter()
        {
            menu.HiddenAllPanels();
            menu.inGame.SetActive(true);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.C)) return;
            
            IMenuState newState = new InGarage(menu);
            menu.SetState(newState);
        }

        public void Exit() {}
    }
}
