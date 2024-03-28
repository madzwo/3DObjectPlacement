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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //score++;
        }
    }
}
