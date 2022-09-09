using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyVehicleMovement : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction = Vector3.right;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.x > 20)
        {
            direction = Vector3.left;
        }

        if (transform.position.x < -20)
        {
            direction = Vector3.right;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Vector3 force = direction * 20f + Vector3.up * 20f;
        collision.rigidbody.velocity = force;
    }
}
