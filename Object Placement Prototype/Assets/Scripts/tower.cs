using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    public Transform turretHolderTransform;

    public GameObject target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("enemy");

        Vector3 aimDirection = target.transform.position - transform.position;

        float angle = Mathf.Atan2(aimDirection.x, aimDirection.z) * Mathf.Rad2Deg;
        turretHolderTransform.rotation = Quaternion.Euler(0f, angle, 0f);        
    }
}
