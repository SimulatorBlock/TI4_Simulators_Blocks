using Menu.States;
using UnityEngine;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
        private IMenuState state;
        public static Menu instance;
        
        [Header("Menu Panels")]
        [SerializeField] public GameObject inMain;
        [SerializeField] public GameObject inGame;
        [SerializeField] public GameObject inGarage;
        
        [Header("Settings Panels")]
        [SerializeField] public GameObject openSettings;
        [SerializeField] public GameObject tooltipCredits;
        [SerializeField] public GameObject tooltipLevelList;
        
        [Header("Modals Panels")]
        [SerializeField] public GameObject modalExistGame;

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
            IMenuState newState = new InMain(this);
            SetState(newState);
        }

        private void Update()
        {
            state?.Update();
        }

        public void SetState(IMenuState newState)
        {
            state?.Exit();
            HiddenAllPanels();
            
            state = newState;
            state?.Enter();
        }

        private void HiddenAllPanels()
        {
            inMain.SetActive(false);
            inGame.SetActive(false);
            inGarage.SetActive(false);
            
            openSettings.SetActive(false);
            tooltipCredits.SetActive(false);
            tooltipLevelList.SetActive(false);
            
            modalExistGame.SetActive(false);
        }
    }
}
