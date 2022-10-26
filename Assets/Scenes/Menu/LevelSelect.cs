using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Menu
{
    public class LevelSelect : MonoBehaviour
    {
        private enum Status
        {
            WorldList,
            WorldSelected
        }

        [SerializeField] private Status status = Status.WorldList;

        [SerializeField] private GameObject worldList;
        [SerializeField] private GameObject buttonBackToMenu;
        [SerializeField] private GameObject world01;
        [SerializeField] private GameObject world02;

        private void Start()
        {
            SetStateToWorldList();
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;

            if (status == Status.WorldList) SceneManager.LoadScene("Main");
            else SetStateToWorldList();
        }

        public void GoToWorld01()
        {
            SetStateToWorldSelected();
            world01.SetActive(true);
        }

        public void GoToWorld02()
        {
            SetStateToWorldSelected();
            world02.SetActive(true);
        }

        private void DisableAllWorlds()
        {
            world01.SetActive(false);
            world02.SetActive(false);
        }

        private void SetStateToWorldList()
        {
            status = Status.WorldList;

            DisableAllWorlds();
            worldList.SetActive(true);
            buttonBackToMenu.SetActive(true);
        }

        private void SetStateToWorldSelected()
        {
            status = Status.WorldSelected;

            DisableAllWorlds();
            worldList.SetActive(false);
            buttonBackToMenu.SetActive(false);
        }
    }
}
