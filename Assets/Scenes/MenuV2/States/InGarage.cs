using UnityEngine;

namespace Scenes.MenuV2.States
{
    public class InGarage : IMenuState
    {
        private readonly Menu menu;

        public InGarage(Menu menu)
        {
            this.menu = menu;
        }
        public void Enter()
        {
            menu.HiddenAllPanels();
            menu.inGarage.SetActive(true);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.P)) return;
            
            IMenuState newState = new InGame(menu);
            menu.SetState(newState);
        }

        public void Exit() {}
    }
}
