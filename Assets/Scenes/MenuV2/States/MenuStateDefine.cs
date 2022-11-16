using UnityEngine;
using UnityEngine.SceneManagement;

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
            IMenuState newState = Menu.instance.tooltipCredits.activeInHierarchy
                ? new OpenSettings(Menu.instance)
                : new TooltipCredits(Menu.instance);
            
            Menu.instance.SetState(newState);
        }
        
        public void SetTooltipLevelListState()
        {
            IMenuState newState = Menu.instance.tooltipLevelList.activeInHierarchy
                ? new InGame(Menu.instance)
                : new TooltipLevelList(Menu.instance);
            
            Menu.instance.SetState(newState);
        }
        
        public void SetModalExitGameState()
        {
            SceneManager.LoadScene(Constants.Menus.Levels.ToString());
            
            // TODO: Remover cena de selecionar level
            // IMenuState newState = new ModalExitGame(Menu.instance);
            // Menu.instance.SetState(newState);

            SetInGameState();
        }
        
        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
