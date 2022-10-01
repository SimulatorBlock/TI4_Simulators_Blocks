using System.Collections.Generic;
using BlockSystem;
using UnityEngine;

namespace AutoPilot
{
    [RequireComponent(typeof(Rigidbody))]
    public class Vehicle : MonoBehaviour
    {
        private Rigidbody rb;
        [SerializeField] private int mass;
        [SerializeField] private int torque;
        [SerializeField] private List<BlockBehavior> blockBehavior = new();

        private void Start()
        {
            GetAllBlockBehavior();
            ConfigRigidbody();

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

        private void ConfigRigidbody()
        {
            rb = GetComponent<Rigidbody>();
            rb.drag = 0f;

            CalcMass();
        }

        private void GetAllBlockBehavior()
        {
            foreach (Transform child in transform)
            {
                BlockBehavior block = child.GetComponent<BlockBehavior>();
                if (block) blockBehavior.Add(block);
            }
        }

        private void CalcMass()
        {
            mass = 0;
            foreach (var block in blockBehavior) mass += block.settings.mass;
            rb.mass = mass;
        }
    }
}
