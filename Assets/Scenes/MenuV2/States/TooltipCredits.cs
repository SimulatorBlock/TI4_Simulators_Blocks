using UnityEngine;

namespace Scenes.MenuV2.States
{
    public class TooltipCredits : IMenuState
    {
        private readonly Menu menu;

        public TooltipCredits(Menu menu)
        {
            this.menu = menu;
        }
        
        public void Enter()
        {
            menu.openSettings.SetActive(true);
            menu.tooltipCredits.SetActive(true);
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
