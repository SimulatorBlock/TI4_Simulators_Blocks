using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.States
{
    public class InMain : IMenuState
    {
        private readonly Menu menu;
        public InMain(Menu menu)
        {
            this.menu = menu;
        }

        public void Enter()
        {
            AudioManager.Instance.Play("Music 2", true);

            AudioManager.Instance.Stop("Motor");
            menu.inMain.SetActive(true);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.KeypadEnter)) return;
            
            //Transitions.Instance.ChooseeTransition(Random.Range(0,4));
            IMenuState newState = new Empty(menu);
            menu.SetState(newState);
            
            SceneManager.LoadScene(Constants.Levels.Forest_01.ToString());
            //Transitions.Instance.DestroyTransitions();
        }

        public void Exit() {}
    }
}
