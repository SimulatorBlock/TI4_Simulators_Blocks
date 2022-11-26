using UnityEngine;

namespace Menu.States
{
    public class TooltipCarListSave : IMenuState
    {
        private readonly Menu menu;

        public TooltipCarListSave(Menu menu)
        {
            this.menu = menu;
        }
        
        public void Enter()
        {
            menu.inGarage.SetActive(true);
            menu.tooltipCarListSave.SetActive(true);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            IMenuState newState = new InGarage(menu);
            menu.SetState(newState);
        }

        public void Exit() {}
    }
}
