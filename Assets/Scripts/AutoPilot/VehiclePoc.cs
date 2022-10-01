using UnityEngine;

namespace AutoPilot
{
    [RequireComponent(typeof(Rigidbody))]
    public class VehiclePoc : MonoBehaviour
    {
        private Rigidbody rb;
        private bool isImpulse;
        [SerializeField] private int mass;
        [SerializeField] private int torque;

        // [SerializeField] private Block[] blocks;
        // [SerializeField] private Engine[] engines;
        [SerializeField] private WheelCollider[] wheels;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.drag = 0f;

            // mass = 0;
            // foreach (var block in blocks) mass += block.Mass;
            // rb.mass = mass;
            //
            // torque = 0;
            // foreach (var engine in engines) torque += engine.Torque;
            //
            // foreach (var wheel in wheels)
            // {
            //     wheel.mass = 20;
            //     wheel.brakeTorque = torque * 3;
            //     wheel.motorTorque = 0f;
            //
            //     float suspension = rb.mass * 6;
            //     wheel.suspensionSpring = new JointSpring
            //     {
            //         spring = suspension * 10,
            //         damper = suspension
            //     };
            // }
        }

        private void Update()
        {
            isImpulse = Input.GetKey(KeyCode.Space);
        }

        private void FixedUpdate()
        {
            float impulse = 0.25f * rb.mass;
            if (isImpulse)
            {
                rb.AddForce(Vector3.up * impulse, ForceMode.Impulse);
            }

            foreach (var wheel in wheels)
            {
                wheel.brakeTorque = 0f;
                wheel.motorTorque = torque;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name != "Water") return;

            Debug.Log("To NADANDO");
            rb.drag = 20f;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.name != "Water") return;

            var velocity = rb.velocity;
            rb.velocity = new Vector3(-4.0f , velocity.y, velocity.z);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.name != "Water") return;

            Debug.Log("SEQUINHO");
            rb.drag = 0f;
        }
    }
}
