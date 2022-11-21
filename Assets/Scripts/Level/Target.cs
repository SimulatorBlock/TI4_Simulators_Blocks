using System.Collections;
using Audio;
using Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private Constants.Levels levelToUnlock;
        [SerializeField] private Transform model;

        private const float RotateSpeed = 90f;
        private const float Displacement = 1f;

        private const float SecondsToNextLevel = 1.5f;

        private Vector3 positionOrigin;
        private Vector3 positionDisplacement;
        private float timePassed;

        private bool trigger = false;
        private VFXManager vfxManager;
        private void Start()
        {
            vfxManager = GetComponent<VFXManager>();
            trigger = false;
            positionOrigin = model.position;
            positionDisplacement = new Vector3
            {
                x = positionOrigin.x,
                y = positionOrigin.y + Displacement,
                z = positionOrigin.z
            };

            StartCoroutine(WaitBlocks());
        }

        IEnumerator WaitBlocks()
        {
            yield return new WaitForSeconds(1.5f);
            vfxManager.EnableVFX("CFX3_MagicAura_B_Runic");
        }
        private void FixedUpdate()
        {
            model.Rotate(Vector3.up, RotateSpeed * Time.fixedDeltaTime);
        }

      
        private void OnTriggerEnter(Collider other)
        {
            if(trigger) return;
            trigger = true;
            Status.Instance.UnlockLevel(levelToUnlock);
            StartCoroutine(GoToNextLevel());
        }

        private IEnumerator GoToNextLevel()
        {
            //Transitions.Instance.ChooseeTransition(Random.Range(0, 4));
            vfxManager.EnableVFX("CFX2_PickupDiamond2");
            vfxManager.DisableVFX("CFX3_MagicAura_B_Runic");
            AudioManager.Instance.Play("Victory" , false);
            AudioManager.Instance.Stop("Motor");
            yield return new WaitForSeconds(SecondsToNextLevel);
            SceneManager.LoadScene(levelToUnlock.ToString());
            MenuStateDefine.SetInGameState();
            //Transitions.Instance.DestroyTransitions();
        }
        
    }
}
