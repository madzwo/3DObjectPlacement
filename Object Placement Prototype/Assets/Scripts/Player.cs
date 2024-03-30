using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject tower;
    public GameObject tower2;

    public Camera mainCamera;

    public TMP_Text scoreText;
    public TMP_Text pointsText;
    public TMP_Text priceText;

    public int score;
    public float scoreRate;
    public float timeTillScore;  

    public int points;
    public float pointRate;
    public float timeTillPoint;

    public int towerPrice;
    public int towerPriceIncrease;

    public int tower2Price;
    public int tower2PriceIncrease;

    public int livesCount;


    void Start()
    {
        timeTillPoint = pointRate;
        timeTillScore = scoreRate;
    }

    void Update()
    {
        if (livesCount > 0)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "towerSpot");
                    {
                        if ((points >= towerPrice) && (Input.GetKey(KeyCode.A)))
                        {    
                                points -= towerPrice;
                                towerPrice += towerPriceIncrease;
                                Vector3 instantiatePosition = hit.collider.gameObject.transform.position;
                                Instantiate(tower, instantiatePosition, Quaternion.identity);
                                pointsText.SetText("" + points.ToString());
                                priceText.SetText("" + towerPrice.ToString());
                            
                        }
                        else if ((points >= tower2Price) && (Input.GetKey(KeyCode.S)))
                        {
                            points -= tower2Price;
                            tower2Price += tower2PriceIncrease;
                            Vector3 instantiatePosition = hit.collider.gameObject.transform.position;
                            Instantiate(tower2, instantiatePosition, Quaternion.identity);
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
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "tower")
                    {
                        Destroy(hit.collider.gameObject);
                        points += towerPrice - towerPriceIncrease;
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

            if (timeTillScore <= 0)
            {
                score++;
                scoreText.SetText("" + score.ToString());
                timeTillScore = scoreRate;
            }
            timeTillScore -= Time.deltaTime;
        

        }  
    }

    public void OnTriggerEnter(Collider collider)
    {
        livesCount--;
    }
}

