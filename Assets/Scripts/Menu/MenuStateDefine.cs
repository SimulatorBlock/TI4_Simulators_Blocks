using Menu.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuStateDefine : MonoBehaviour
    {
        public static void SetInMainState()
        {
            IMenuState newState = new InMain(Menu.instance);
            Menu.instance.SetState(newState);
        }
        public static void SetInGameState()
        {
            IMenuState newState = new InGame(Menu.instance);
            Menu.instance.SetState(newState);
        }
        
        public static void SetInGarageState()
        {
            IMenuState newState = new InGarage(Menu.instance);
            Menu.instance.SetState(newState);
        }
        
        public static void SetOpenSettingsState()
        {
            IMenuState newState = new OpenSettings(Menu.instance);
            Menu.instance.SetState(newState);
        }
        
        public static void SetTooltipCreditsState()
        {
            IMenuState newState = Menu.instance.tooltipCredits.activeInHierarchy
                ? new OpenSettings(Menu.instance)
                : new TooltipCredits(Menu.instance);
            
            Menu.instance.SetState(newState);
        }
        
        public static void SetTooltipLevelListState()
        {
            IMenuState newState = Menu.instance.tooltipLevelList.activeInHierarchy
                ? new InGame(Menu.instance)
                : new TooltipLevelList(Menu.instance);
            
            Menu.instance.SetState(newState);
        }
        
        public static void SetModalExitGameState()
        {
            SceneManager.LoadScene(Constants.Menus.Levels.ToString());
            
            // TODO: Remover cena de selecionar level
            // IMenuState newState = new ModalExitGame(Menu.instance);
            // Menu.instance.SetState(newState);

            SetInGameState();
        }
        
        public static void ReloadLevel()
        {
            SetInGameState();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
