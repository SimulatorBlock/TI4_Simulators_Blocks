using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private Constants.Levels level;

        private MeshRenderer mesh;
        [Header("Material Status")]
        [SerializeField] private Material materialDefault;
        [SerializeField] private Material materialHover;

        private void Start()
        {
            mesh = gameObject.GetComponent<MeshRenderer>();
            mesh.material = materialDefault;
        }

        private void OnMouseDown()
        {
            SceneManager.LoadScene(level.ToString());
        }

        private void OnMouseOver()
        {
            mesh.material = materialHover;
        }

        private void OnMouseExit()
        {
            mesh.material = materialDefault;
        }
    }
}
