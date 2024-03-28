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
    public float shootingDistance;

    void Start()
    {
        timeTillFire = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        target = FindTarget();
        if(target != null)
        {
            Vector3 aimDirection = target.transform.position - transform.position;

            float angle = Mathf.Atan2(aimDirection.x, aimDirection.z) * Mathf.Rad2Deg;
            turretHolderTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            if(timeTillFire <= 0)
            {
                if (Vector2.Distance(this.transform.position, target.transform.position) < shootingDistance)
                {
                    Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                    timeTillFire = fireRate;
                }
            }
        }
        
        timeTillFire -= Time.deltaTime;
    }

    public GameObject FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for(int i = 0; i < enemies.Length; i++)
        {
            if (Vector2.Distance(this.transform.position, enemies[i].transform.position) < shootingDistance)
            {
                return enemies[i];
            }
        }
        return null;
    }

}
