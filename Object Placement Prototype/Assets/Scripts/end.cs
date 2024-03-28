using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class end : MonoBehaviour
{
    public TMP_Text livesText;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(lives <= 0)
        {
            lives = 0;
            livesText.SetText("" + lives.ToString());
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            if (lives > 0)
            {
                lives -= 1;
            }
            Destroy(collision.gameObject);
            livesText.SetText("" + lives.ToString());
        }
    }
}
