using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    public Transform turretHolderTransform;

    public GameObject target;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float timeTillFire;
    public float fireRate;
    public float bulletSpeed;

    void Start()
    {
        timeTillFire = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("enemy");
        if(target != null)
        {
            Vector3 aimDirection = target.transform.position - transform.position;

            float angle = Mathf.Atan2(aimDirection.x, aimDirection.z) * Mathf.Rad2Deg;
            turretHolderTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            if(timeTillFire <= 0)
            {
                Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                timeTillFire = fireRate;
            }
        }
        timeTillFire -= Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Debug.Log("hitEnemy");
        }
    }
}
