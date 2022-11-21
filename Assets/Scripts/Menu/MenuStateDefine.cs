using Audio;
using Menu.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuStateDefine : MonoBehaviour
    {
        public static void SetInMainState()
        {
            IMenuState newState = new InMain(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        public static void SetInGameState()
        {
            IMenuState newState = new InGame(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetInGarageState()
        {
            IMenuState newState = new InGarage(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetGarageBlocksState()
        {
            IMenuState newState = new GarageBlocks(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetGarageEnginesState()
        {
            IMenuState newState = new GarageEngines(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetGarageWheelsState()
        {
            IMenuState newState = new GarageWheels(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetOpenSettingsState()
        {
            IMenuState newState = new OpenSettings(Menu.Instance);
            Menu.Instance.SetState(newState);
        }
        
        public static void SetTooltipCreditsState()
        {
            IMenuState newState = Menu.Instance.tooltipCredits.activeInHierarchy
                ? new OpenSettings(Menu.Instance)
                : new TooltipCredits(Menu.Instance);
            
            Menu.Instance.SetState(newState);
        }
        
        public static void SetTooltipLevelListState()
        {
            IMenuState newState = Menu.Instance.tooltipLevelList.activeInHierarchy
                ? new InGame(Menu.Instance)
                : new TooltipLevelList(Menu.Instance);
            
            Menu.Instance.SetState(newState);
        }
        
        public static void SetModalExitGameState()
        {
            Application.Quit();
            
            // TODO: Remover cena de selecionar level
            // IMenuState newState = new ModalExitGame(Menu.instance);
            // Menu.instance.SetState(newState);

            // SetInGameState();
        }
        
        public static void ReloadLevel()
        {
            SetInGameState();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            AudioManager.Instance.Stop("Motor");
        }
    }
}
