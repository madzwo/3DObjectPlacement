using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float bulletSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 vel = transform.forward * bulletSpeed - rb.velocity;
        rb.AddForce(vel, ForceMode.Force);
    }
}
