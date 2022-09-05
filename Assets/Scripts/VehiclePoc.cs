using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehiclePoc : MonoBehaviour
{
    private Rigidbody rb;
    private bool isImpulse;
    private readonly Vector3 defaultVelocity = Vector3.forward;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0f;
        rb.velocity = defaultVelocity;
    }

    private void Update()
    {
        var velocity = rb.velocity;
        rb.velocity = new Vector3(velocity.x , velocity.y, 2.0f);

        isImpulse = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if (isImpulse)
        {
            rb.AddForce(Vector3.up * 0.25f, ForceMode.Impulse);
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
        rb.velocity = defaultVelocity;
    }
}
