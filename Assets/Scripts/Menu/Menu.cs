using Audio;
using Menu.States;
using UnityEngine;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
        private IMenuState state;
        public static Menu Instance;

        public MenuDefaultState defaultState = MenuDefaultState.InGame; 
        
        [Header("Menu Panels")]
        [SerializeField] public GameObject inMain;
        [SerializeField] public GameObject inGame;
        [SerializeField] public GameObject inGarage;
        
        [Header("Settings Panels")]
        [SerializeField] public GameObject openSettings;
        [SerializeField] public GameObject tooltipCredits;
        [SerializeField] public GameObject tooltipCarList;
        [SerializeField] public GameObject tooltipLevelList;
        
        [Header("Modals Panels")]
        [SerializeField] public GameObject modalExistGame;
        
        [Header("Garage Panels")]
        [SerializeField] public GameObject garageBlocks;
        [SerializeField] public GameObject garageEngines;
        [SerializeField] public GameObject garageWheels;

        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
        }

        private void Start()
        {
            IMenuState newState;
            switch (defaultState)
            {
                case MenuDefaultState.InMain:
                {
                    newState = new InMain(this);
                    break;
                }
                case MenuDefaultState.InGarage:
                {
                    newState = new InGarage(this);
                    break;
                }
                case MenuDefaultState.InGame:
                default:
                    newState = new InGame(this);
                    break;
            }
            
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
            tooltipCarList.SetActive(false);
            tooltipLevelList.SetActive(false);
            
            modalExistGame.SetActive(false);
            
            garageBlocks.SetActive(false);
            garageEngines.SetActive(false);
            garageWheels.SetActive(false);
        }
    }
}
