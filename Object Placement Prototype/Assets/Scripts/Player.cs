using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject tower;
    public Camera mainCamera;

    public int score;


    public TMP_Text pointsText;
    public TMP_Text priceText;

    public int points;
    public int towerPrice;
    public int towerPriceIncrease;

    public float pointRate;
    public float timeTillPoint;

    void Start()
    {
        timeTillPoint = pointRate;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "towerSpot");
                {
                    if(points >= towerPrice)
                    {
                        Debug.Log("points: " + points + "; towerPrice: " + towerPrice);
                        points -= towerPrice;
                        towerPrice += towerPriceIncrease;
                        Vector3 instantiatePosition = hit.collider.gameObject.transform.position;
                        Instantiate(tower, instantiatePosition, Quaternion.identity);
                        pointsText.SetText("" + points.ToString());
                        priceText.SetText("" + towerPrice.ToString());
                    }
                }
                if (hit.collider.gameObject.tag == "enemy")
                {
                    Destroy(hit.collider.gameObject);
                    score += 1;
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

        if (timeTillPoint <= 0)
        {
            points++;
            pointsText.SetText("" + points.ToString());
            timeTillPoint = pointRate;
        }

        timeTillPoint -= Time.deltaTime;
    }
}
