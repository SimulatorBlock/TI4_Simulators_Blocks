using System.Collections;
using Audio;
using AutoPilot;
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
        private const float TimeToCompleteLevel = 10f;

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
            StartCoroutine(CountToRestartGame());
        }
        private void FixedUpdate()
        {
            model.Rotate(Vector3.up, RotateSpeed * Time.fixedDeltaTime);
        }

        IEnumerator CountToRestartGame()
        {
            yield return new WaitForSeconds(TimeToCompleteLevel);
            StartCoroutine(Explosion(false, 0.5f));
        }
      
        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Block"))return;
            
            if(trigger) return;
            trigger = true;
            Status.Instance.UnlockLevel(levelToUnlock);
            GoToNextLevel(true);
        }

        private void GoToNextLevel(bool next)
        {
            vfxManager.EnableVFX("CFX2_PickupDiamond2");
            vfxManager.DisableVFX("CFX3_MagicAura_B_Runic");
            AudioManager.Instance.Play("Victory" , false);
            AudioManager.Instance.Stop("Motor");

            StartCoroutine(Explosion(next, 1.5f));
        }

        public void ExplosionCall(bool next, float time)
        {
            StartCoroutine(Explosion(next, time));
        }
        IEnumerator Explosion(bool next, float time)
        {
            yield return new WaitForSeconds(time);
            GameObject obj = null;
            try
            {
                obj = FindObjectOfType<Vehicle2>().gameObject;
            }
            catch { }
            
            if (!obj)
                obj = FindObjectOfType<Vehicle>().gameObject;
            
            vfxManager.ChangePos(obj.transform.position, "Explosion");
            vfxManager.EnableVFX("Explosion");
            AudioManager.Instance.Play("Explosion", false);
            Destroy(obj);
            yield return new WaitForSeconds(SecondsToNextLevel);
            
            if(next)
                NextLevel();
            else
                MenuStateDefine.ReloadLevel();
        }

        void NextLevel()
        {
            SceneManager.LoadScene(levelToUnlock.ToString());
            MenuStateDefine.SetInGameStateWithDelay();
        }
        
    }
}
