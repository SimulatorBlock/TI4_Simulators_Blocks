using UnityEngine;

namespace Fx
{
    public class BirdFlockFx : MonoBehaviour
    {
        private float _timePassed;

        [Space]
        [Header("Movement")]
        [SerializeField] [Range(0f, 2f)] private float speed = .6f;

        [Header("Displacement")]
        [SerializeField] [Range(2f, 1f)] private float displacement = 1.5f;
        [SerializeField] [Range(0f, 1f)] private float speedDisplacement = .1f;

        private void Start()
        {
            ResetPosition();
        }

        private void Update()
        {
            _timePassed += Time.deltaTime * speedDisplacement;

            float timeInterpolation = Mathf.PingPong(_timePassed, 1f);
            Vector3 direction = Vector3.Lerp(Vector3.left / displacement, Vector3.right / displacement, timeInterpolation) + Vector3.forward;
            transform.position += direction * speed * Time.deltaTime;

            if (transform.position.z >= 4f) ResetPosition();
        }

        private void ResetPosition()
        {
            transform.position = new Vector3(0, 0, -3f);
        }
    }
}
