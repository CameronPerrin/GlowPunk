using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    //public GameObject player;
    private Rigidbody2D rb2d;
    public float speed;
    public float blink, coolDown;//distance of players blink ability
    private float recharge = 0;
    [HideInInspector]
    public float normalSpeed;//want variable so the outside objects and scripts and alter the speed of player and change it back

    // ## Movement animation and direction
    public Animator Anim;
    public bool facingRight = true;
    private Transform playerGraphics; // ## I need something to reference when changing direction (regarding graphics)
    public GameObject firePoint;

    // ## Not sure if I can move the information inside here into the Start() function
    private void Awake()
    {
        normalSpeed = speed;
        Anim = GetComponent<Animator>();
        this.playerGraphics = this.transform.Find("Graphics");
    }
        
    // Use this for initialization
    void Start ()
    {
        Rigidbody2D rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.angularVelocity = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        if (this.tag == "Player1")
        {
            // ## Animator change based off of movement
            // ## - THIS IS JUST FOR ANIMATION, LOOK UNDER THIS FOR ACTUAL MOVEMENT - ##
            
            if (Input.GetAxis("MoveJoy1Y") != 0 || Input.GetAxis("MoveJoy1X") != 0)
            {
                Anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("MoveJoy1X")));
                Anim.SetFloat("VertSpeed", Mathf.Abs(Input.GetAxis("MoveJoy1Y")));
            }
            else//not moving so set speeds to 0
            {
                Anim.SetFloat("Speed", 0.0f);
                Anim.SetFloat("VertSpeed", 0.0f);
            }

            if (Input.GetAxis("MoveJoy1Y") != 0 || Input.GetAxis("MoveJoy1X") != 0)
            {
                this.transform.position += new Vector3(Input.GetAxis("MoveJoy1X") * speed * Time.deltaTime, Input.GetAxis("MoveJoy1Y") * -speed * Time.deltaTime, 0);

                // ## Flip the sprite left or right
                if (Input.GetAxis("ShotJoy1X") == 0)
                {
                    if (Input.GetAxis("MoveJoy1X") > 0 && !facingRight)
                    {
                        Flip();
                        facingRight = true;
                    }
                    else if (Input.GetAxis("MoveJoy1X") < 0 && facingRight)
                    {
                        Flip();
                        facingRight = false;
                    }
                }
                else
                {
                    if (Input.GetAxis("ShotJoy1X") > 0 && !facingRight)
                    {
                        Flip();
                        facingRight = true;
                    }
                    else if (Input.GetAxis("ShotJoy1X") < 0 && facingRight)
                    {
                        Flip();
                        facingRight = false;
                    }
                }
            }
            if (Input.GetAxis("A1") != 0 && recharge <= 0)//player blink
            {
                Vector3 temp = new Vector3(Input.GetAxis("MoveJoy1X"), -Input.GetAxis("MoveJoy1Y"), 0);
                temp.Normalize();

                this.transform.position += temp * blink;
                recharge = coolDown;
            }
            
            if(recharge > 0)//recharge for blink
            {
                recharge -= Time.deltaTime;
            }
        }
        else if (this.tag == "Player2")
        {
            if (Input.GetAxis("MoveJoy2Y") != 0 || Input.GetAxis("MoveJoy2X") != 0)
            {
                Anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("MoveJoy2X")));
                Anim.SetFloat("VertSpeed", Mathf.Abs(Input.GetAxis("MoveJoy2Y")));
            }
            else//not moving so set speeds to 0
            {
                Anim.SetFloat("Speed", 0.0f);
                Anim.SetFloat("VertSpeed", 0.0f);
            }

            if (Input.GetAxis("MoveJoy2Y") != 0 || Input.GetAxis("MoveJoy2X") != 0)
            {
                this.transform.position += new Vector3(Input.GetAxis("MoveJoy2X") * speed * Time.deltaTime, Input.GetAxis("MoveJoy2Y") * -speed * Time.deltaTime, 0);

                // ## Flip the sprite left or right
                if (Input.GetAxis("ShotJoy2X") == 0)
                {
                    if (Input.GetAxis("MoveJoy2X") > 0 && !facingRight)
                    {
                        Flip();
                        facingRight = true;
                    }
                    else if (Input.GetAxis("MoveJoy2X") < 0 && facingRight)
                    {
                        Flip();
                        facingRight = false;
                    }
                }
                else
                {
                    if (Input.GetAxis("ShotJoy2X") > 0 && !facingRight)
                    {
                        Flip();
                        facingRight = true;
                    }
                    else if (Input.GetAxis("ShotJoy2X") < 0 && facingRight)
                    {
                        Flip();
                        facingRight = false;
                    }
                }
            }
            if (Input.GetAxis("A2") != 0 && recharge <= 0)
            {
                Vector3 temp = new Vector3(Input.GetAxis("MoveJoy2X"), -Input.GetAxis("MoveJoy2Y"), 0);
                temp.Normalize();

                this.transform.position += temp * blink;
                recharge = coolDown;
            }

            if (recharge > 0)
            {
                recharge -= Time.deltaTime;
            }
        }

        else if (this.tag == "Player3")
        {
            if (Input.GetAxis("MoveJoy3Y") != 0 || Input.GetAxis("MoveJoy3X") != 0)
            {
                Anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("MoveJoy3X")));
                Anim.SetFloat("VertSpeed", Mathf.Abs(Input.GetAxis("MoveJoy3Y")));
            }
            else//not moving so set speeds to 0
            {
                Anim.SetFloat("Speed", 0.0f);
                Anim.SetFloat("VertSpeed", 0.0f);
            }

            if (Input.GetAxis("MoveJoy3Y") != 0 || Input.GetAxis("MoveJoy3X") != 0)
            {
                this.transform.position += new Vector3(Input.GetAxis("MoveJoy3X") * speed * Time.deltaTime, Input.GetAxis("MoveJoy3Y") * -speed * Time.deltaTime, 0);

                // ## Flip the sprite left or right
                if (Input.GetAxis("ShotJoy3X") == 0)
                {
                    if (Input.GetAxis("MoveJoy3X") > 0 && !facingRight)
                    {
                        Flip();
                        facingRight = true;
                    }
                    else if (Input.GetAxis("MoveJoy3X") < 0 && facingRight)
                    {
                        Flip();
                        facingRight = false;
                    }
                }
                else
                {
                    if (Input.GetAxis("ShotJoy3X") > 0 && !facingRight)
                    {
                        Flip();
                        facingRight = true;
                    }
                    else if (Input.GetAxis("ShotJoy3X") < 0 && facingRight)
                    {
                        Flip();
                        facingRight = false;
                    }
                }
            }
            if (Input.GetAxis("A3") != 0 && recharge <= 0)
            {
                Vector3 temp = new Vector3(Input.GetAxis("MoveJoy3X"), -Input.GetAxis("MoveJoy3Y"), 0);
                temp.Normalize();

                this.transform.position += temp * blink;
                recharge = coolDown;
            }

            if (recharge > 0)
            {
                recharge -= Time.deltaTime;
            }
        }

        else if (this.tag == "Player4")
        {
            if (Input.GetAxis("MoveJoy4Y") != 0 || Input.GetAxis("MoveJoy4X") != 0)
            {
                Anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("MoveJoy4X")));
                Anim.SetFloat("VertSpeed", Mathf.Abs(Input.GetAxis("MoveJoy4Y")));
            }
            else//not moving so set speeds to 0
            {
                Anim.SetFloat("Speed", 0.0f);
                Anim.SetFloat("VertSpeed", 0.0f);
            }

            if (Input.GetAxis("MoveJoy4Y") != 0 || Input.GetAxis("MoveJoy4X") != 0)
            {
                this.transform.position += new Vector3(Input.GetAxis("MoveJoy4X") * speed * Time.deltaTime, Input.GetAxis("MoveJoy4Y") * -speed * Time.deltaTime, 0);

                // ## Flip the sprite left or right
                if (Input.GetAxis("ShotJoy4X") == 0)
                {
                    if (Input.GetAxis("MoveJoy4X") > 0 && !facingRight)
                    {
                        Flip();
                        facingRight = true;
                    }
                    else if (Input.GetAxis("MoveJoy4X") < 0 && facingRight)
                    {
                        Flip();
                        facingRight = false;
                    }
                }
                else
                {
                    if (Input.GetAxis("ShotJoy4X") > 0 && !facingRight)
                    {
                        Flip();
                        facingRight = true;
                    }
                    else if (Input.GetAxis("ShotJoy4X") < 0 && facingRight)
                    {
                        Flip();
                        facingRight = false;
                    }
                }
            }
            if (Input.GetAxis("A4") != 0 && recharge <= 0)
            {
                Vector3 temp = new Vector3(Input.GetAxis("MoveJoy4X"), -Input.GetAxis("MoveJoy4Y"), 0);
                temp.Normalize();

                this.transform.position += temp * blink;
                recharge = coolDown;
            }

            if (recharge > 0)
            {
                recharge -= Time.deltaTime;
            }
        }
    }
    // ## Flip function
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;
        this.firePoint.transform.Rotate(0f, 180f, 0f);
        // Multiply the player's x local scale by -1.

        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
