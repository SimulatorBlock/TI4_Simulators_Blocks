using UnityEngine;

namespace Scenes.MenuV2.States
{
    public class OpenSettings : IMenuState
    {
        private readonly Menu menu;

        public OpenSettings(Menu menu)
        {
            this.menu = menu;
        }
        
        public void Enter()
        {
            menu.openSettings.SetActive(true);
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
