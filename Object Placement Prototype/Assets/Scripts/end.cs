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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            lives -= 1;
            livesText.SetText("" + lives.ToString());
        }
    }
}
