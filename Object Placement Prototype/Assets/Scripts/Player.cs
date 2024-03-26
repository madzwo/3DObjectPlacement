using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject tower;
    public Camera mainCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "towerSpot")
                {
                    Vector3 instantiatePosition = hit.collider.gameObject.transform.position;
                    Instantiate(tower, instantiatePosition, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            Debug.Log("right click");
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("hit");
            
                if (hit.collider.gameObject.tag == "tower")
                {
                    Debug.Log("hit tower");
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
