using UnityEngine;

namespace Scenes.MenuV2.States
{
    public class MenuStateDefine : MonoBehaviour
    {
        public void SetInMainState()
        {
            IMenuState newState = new InMain(Menu.instance);
            Menu.instance.SetState(newState);
        }
        public void SetInGameState()
        {
            IMenuState newState = new InGame(Menu.instance);
            Menu.instance.SetState(newState);
        }
        
        public void SetInGarageState()
        {
            IMenuState newState = new InGarage(Menu.instance);
            Menu.instance.SetState(newState);
        }
        
        public void SetOpenSettingsState()
        {
            IMenuState newState = new OpenSettings(Menu.instance);
            Menu.instance.SetState(newState);
        }
        
        public void SetTooltipCreditsState()
        {
            IMenuState newState = new TooltipCredits(Menu.instance);
            Menu.instance.SetState(newState);
        }
        
        public void SetTooltipLevelListState()
        {
            IMenuState newState = new TooltipLevelList(Menu.instance);
            Menu.instance.SetState(newState);
        }
        
        public void SetModalExitGameState()
        {
            IMenuState newState = new ModalExitGame(Menu.instance);
            Menu.instance.SetState(newState);
        }
    }
}
