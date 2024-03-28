using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f; // Desired constant speed
    public Rigidbody rb;
    

    void Start()
    {
    }

    void Update()
    {
        Vector3 vel = transform.forward * speed - rb.velocity;

        rb.AddForce(vel, ForceMode.Force);
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collide");
        if (collider.gameObject.tag == "turnDown")
        {
            Debug.Log("turnDown");
            Quaternion newRotation = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = newRotation;
        }
        if (collider.gameObject.tag == "turnLeft")
        {
            Quaternion newRotation = Quaternion.Euler(0f, -90f, 0f);
            transform.rotation = newRotation;
        }
        if (collider.gameObject.tag == "turnUp")
        {
            Quaternion newRotation = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = newRotation;
        }
    }
}
