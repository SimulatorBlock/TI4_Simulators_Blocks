using UnityEngine;

namespace Menu.States
{
    public class GarageWheels : IMenuState
    {
        private readonly Menu menu;

        public GarageWheels(Menu menu)
        {
            this.menu = menu;
        }
        
        public void Enter()
        {
            menu.inGarage.SetActive(true);
            menu.garageWheels.SetActive(true);
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
