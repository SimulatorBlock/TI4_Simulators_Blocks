using System.Collections;
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

        private void Start()
        {
            positionOrigin = model.position;
            positionDisplacement = new Vector3
            {
                x = positionOrigin.x,
                y = positionOrigin.y + Displacement,
                z = positionOrigin.z
            };
        }

        private void Update()
        {
            /*timePassed += Time.deltaTime;

            float timeInterpolation = Mathf.PingPong(timePassed, 1f);
            model.position = Vector3.Lerp(positionOrigin, positionDisplacement, timeInterpolation);*/
        }

        private void FixedUpdate()
        {
            model.Rotate(Vector3.up, RotateSpeed * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            Status.Instance.UnlockLevel(levelToUnlock);
            StartCoroutine(GoToNextLevel());
        }

        IEnumerator GoToNextLevel()
        {
            yield return new WaitForSeconds(SecondsToNextLevel);
            SceneManager.LoadScene(levelToUnlock.ToString());
        }
    }
}
