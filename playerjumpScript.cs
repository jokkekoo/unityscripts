using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerjumpScript : MonoBehaviour
{
    public float timePressed;
    public Rigidbody2D rb;

    private kunkkuScript kunkku;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        keyPressedTimer();
    }
    void keyPressedTimer()
    {
        if(Input.GetKeyDown("space"))
        {
            timePressed = Time.time;
        }

        if(Input.GetKeyUp("space"))
        {
            timePressed = Time.time - timePressed;
            if(timePressed < 1.0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 15);
            }
            Debug.Log("Pressed For : " + timePressed + " Seconds" + Time.time);
        }
    }
}
