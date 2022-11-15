using UnityEngine;
using Scenes.MenuV2.States;

namespace Scenes.MenuV2
{
    public class Menu : MonoBehaviour
    {
        private IMenuState state;
        public static Menu instance;

        [Header("Menu Panels")]
        [SerializeField] public GameObject inGame;
        [SerializeField] public GameObject inGarage;

        private void Awake()
        {
            if (instance) Destroy(gameObject);
            else
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
        }

        private void Start()
        {
            IMenuState newState = new InGame(this);
            SetState(newState);
        }

        private void Update()
        {
            state?.Update();
        }

        public void SetState(IMenuState newState)
        {
            state?.Exit();
            state = newState;
            state?.Enter();
        }

        public void HiddenAllPanels()
        {
            inGame.SetActive(false);
            inGarage.SetActive(false);
        }
    }
}
