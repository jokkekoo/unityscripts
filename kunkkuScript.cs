using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisäyksiä:
// Jos törmää hypyn aikana niin pitäisi kimmota
// Törmäyksestä pitäisi kuulua ääni ja kun on pudonnut tietyn matkan niin ei voi enää tehdä mitään sen jälkeen

public class kunkkuScript : MonoBehaviour
{
    [Header ("Ground Checking")]
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    [Header ("Movement Related")]
    float horizontalMove = 0f;

    public float kunkkuSpeed = 0.1f;
    float nerfSpeed = 0.3f;

    float timePressed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public float downTime, upTime, pressTime = 0;
    public float countDown = 2.0f;
    public bool ready = false;
    
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        keyPressedTimer(horizontalMove);

        if (horizontalMove == 1 && onGround == true && Input.GetKey(KeyCode.Space) == false) 
        {
            //rb.AddForce(Vector2.right * kunkkuSpeed * nerfSpeed, ForceMode2D.Impulse);
            rb.velocity = new Vector2(3, rb.velocity.y);
        }
        else if (horizontalMove == -1 && onGround == true && Input.GetKey(KeyCode.Space) == false)
        {
            //rb.AddForce(Vector2.left * kunkkuSpeed * nerfSpeed, ForceMode2D.Impulse);
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }
        else
        {
            if(onGround == true)
            {    
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }
        }
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void keyPressedTimer(float direction)
    {
        if(Input.GetKeyDown("space"))
        {
            rb.velocity = Vector2.zero;
            timePressed = Time.time;
        }

        if(Input.GetKeyUp("space"))
        {
            // Kauanko pelaaja on painanut välilyöntiä ( space )
            timePressed = Time.time - timePressed;
            // 1 = oikea, -1 = vasen, 0 = paikallaan

            // Jos pelaaja haluaa hypätä oikealle
            if(direction == 1){
                if(timePressed < 0.3 && onGround)
                {   
                    rb.AddForce(Vector2.right * 75, ForceMode2D.Force);
                    rb.velocity = new Vector2(rb.velocity.x, 3);
                }
                if(timePressed > 0.3 && timePressed < 0.6 && onGround)
                {
                    rb.AddForce(Vector2.right * 150, ForceMode2D.Force);
                    rb.velocity = new Vector2(rb.velocity.x, 6);
                }
                if(timePressed > 0.6 && timePressed < 1.0 && onGround)
                {
                    rb.AddForce(Vector2.right * 250, ForceMode2D.Force);
                    rb.velocity = new Vector2(rb.velocity.x, 12);
                }
            }

            // Jos pelaaja haluaa vasemmalle
            if(direction == -1)
            {
                if(timePressed < 0.3 && onGround)
                {   
                    rb.AddForce(Vector2.left * 75, ForceMode2D.Force);
                    rb.velocity = new Vector2(rb.velocity.x, 3);
                }
                if(timePressed > 0.3 && timePressed < 0.6 && onGround)
                {
                    rb.AddForce(Vector2.left * 150, ForceMode2D.Force);
                    rb.velocity = new Vector2(rb.velocity.x, 6);
                }
                if(timePressed > 0.6 && timePressed < 1.0 && onGround)
                {
                    rb.AddForce(Vector2.left * 250, ForceMode2D.Force);
                    rb.velocity = new Vector2(rb.velocity.x, 12);
                }
            }

            // Jos ei ole suuntaa niin pelaaja hyppää suoraan ylöspäin
            if(direction == 0){
                if(timePressed < 0.3 && onGround)
                {   
                    rb.velocity = new Vector2(rb.velocity.x, 3);
                }
                if(timePressed > 0.3 && timePressed < 0.6 && onGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 6);
                }
                if(timePressed > 0.6 && timePressed < 1.0 && onGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 12);
                }
            }
            Debug.Log("Pressed For : " + timePressed + " Seconds" + Time.time);
        }
    }
}
