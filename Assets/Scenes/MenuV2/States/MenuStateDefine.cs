using UnityEngine;

namespace Scenes.MenuV2.States
{
    public class MenuStateDefine : MonoBehaviour
    {
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
    }
}
