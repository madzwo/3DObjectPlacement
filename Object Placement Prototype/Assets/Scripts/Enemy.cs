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
        if (collider.gameObject.tag == "turnDown")
        {
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
        if (collider.gameObject.tag == "turnRight")
        {
            Quaternion newRotation = Quaternion.Euler(0f, 90f, 0f);
            transform.rotation = newRotation;
        }
    }

    // private void OnDestroy()
    // {
    //     if(gameObject.tag != "enemy1")
    //     {
    //         if(gameObject.tag == "enemy2")
    //         {
    //             Instantiate(enemy1Prefab, gameObject.transform.position, gameObject.transform.rotation);
    //         }
    //         else if(gameObject.tag == "enemy3")
    //         {
    //             Instantiate(enemy2Prefab, gameObject.transform.position, gameObject.transform.rotation);
    //         }
    //         else if(gameObject.tag == "enemy4")
    //         {
    //             Instantiate(enemy3Prefab, gameObject.transform.position, gameObject.transform.rotation);
    //         }
    //         else if(gameObject.tag == "enemy5")
    //         {
    //             Instantiate(enemy4Prefab, gameObject.transform.position, gameObject.transform.rotation);
    //         }

    //     }
    // }
}
