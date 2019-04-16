using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    //public GameObject player;
    private Rigidbody2D rb2d;
    public float speed;
    public float sprintSpeed, coolDown, duration, timer;//distance of players sprintSpeed ability
    private float recharge = 0;
    [HideInInspector]
    public float normalSpeed;//want variable so the outside objects and scripts and alter the speed of player and change it back
    public float healingFactor = 1;

    // ## Movement animation and direction
    public Animator Anim;
    public bool facingRight = true;
    private Transform playerGraphics; // ## I need something to reference when changing direction (regarding graphics)
    public GameObject firePoint;
    public GameObject child;

    private Health hp;
    private GameObject Access;



    // ## Not sure if I can move the information inside here into the Start() function
    private void Awake()
    {
        normalSpeed = 10;
        Anim = GetComponent<Animator>();
        this.playerGraphics = this.transform.Find("Graphics");
        Access = this.transform.GetChild(0).gameObject;
        hp = Access.GetComponent<Health>();
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
        hp = Access.GetComponent<Health>();
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        if (this.tag == "Player1")
        {
            // ## Animator change based off of movement
            // ## - THIS IS JUST FOR ANIMATION, LOOK UNDER THIS FOR ACTUAL MOVEMENT - ##
            
            if (Input.GetAxis("MoveJoy1Y") != 0 || Input.GetAxis("MoveJoy1X") != 0)
            {
                Anim.SetBool("Moving", true);
            }
            else//not moving so set speeds to 0
            {
                Anim.SetBool("Moving", false);
            }
            Anim.SetFloat("VertSpeed", Input.GetAxis("MoveJoy1Y"));
            Anim.SetFloat("Aim", Input.GetAxis("ShotJoy1Y"));

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
            if (Input.GetAxis("Dash1") != 0 && recharge <= 0)//player sprintSpeed
            {
                this.speed = sprintSpeed;
                recharge = coolDown;
                timer = duration;
                
            }
            
            if(recharge > 0)//recharge for sprintSpeed
            {
                recharge -= Time.deltaTime;
            }
            if(timer > 0)
            {
                timer -= Time.deltaTime;
                if (this.hp.cHealth < 50)
                {
                    this.hp.modifyHealth(healingFactor * Time.deltaTime);
                }

            }
            else if(timer <= 0)
            {
                this.speed = normalSpeed;
                timer = 0;
            }
        }
        else if (this.tag == "Player2")
        {
            if (Input.GetAxis("MoveJoy2Y") != 0 || Input.GetAxis("MoveJoy2X") != 0)
            {
                Anim.SetBool("Moving", true);
            }
            else//not moving so set speeds to 0
            {
                Anim.SetBool("Moving", false);
            }
            Anim.SetFloat("VertSpeed", Input.GetAxis("MoveJoy2Y"));
            Anim.SetFloat("Aim", Input.GetAxis("ShotJoy2Y"));

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
            if (Input.GetAxis("Dash2") != 0 && recharge <= 0)
            {
                this.speed = sprintSpeed;
                recharge = coolDown;
                timer = duration;
            }

            if (recharge > 0)//recharge for sprintSpeed
            {
                recharge -= Time.deltaTime;
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (this.hp.cHealth < 50)
                {
                    this.hp.modifyHealth(healingFactor * Time.deltaTime);
                }
            }
            else if (timer <= 0)
            {
                this.speed = normalSpeed;
                timer = 0;
            }
        }

        else if (this.tag == "Player3")
        {
            if (Input.GetAxis("MoveJoy3Y") != 0 || Input.GetAxis("MoveJoy3X") != 0)
            {
                Anim.SetBool("Moving", true);
            }
            else//not moving so set speeds to 0
            {
                Anim.SetBool("Moving", false);
            }
            Anim.SetFloat("VertSpeed", Input.GetAxis("MoveJoy3Y"));
            Anim.SetFloat("Aim", Input.GetAxis("ShotJoy3Y"));

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
            if (Input.GetAxis("Dash3") != 0 && recharge <= 0)
            {
                this.speed = sprintSpeed;
                recharge = coolDown;
                timer = duration;
            }

            if (recharge > 0)//recharge for sprintSpeed
            {
                recharge -= Time.deltaTime;
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (this.hp.cHealth < 50)
                {
                    this.hp.modifyHealth(healingFactor * Time.deltaTime);
                }
            }
            else if (timer <= 0)
            {
                this.speed = normalSpeed;
                timer = 0;
            }
        }

        else if (this.tag == "Player4")
        {
            if (Input.GetAxis("MoveJoy4Y") != 0 || Input.GetAxis("MoveJoy4X") != 0)
            {
                Anim.SetBool("Moving", true);
            }
            else//not moving so set speeds to 0
            {
                Anim.SetBool("Moving", false);
            }
            Anim.SetFloat("VertSpeed", Input.GetAxis("MoveJoy4Y"));
            Anim.SetFloat("Aim", Input.GetAxis("ShotJoy4Y"));

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
            if (Input.GetAxis("Dash4") != 0 && recharge <= 0)
            {
                this.speed = sprintSpeed;
                recharge = coolDown;
                timer = duration;
            }

            if (recharge > 0)//recharge for sprintSpeed
            {
                recharge -= Time.deltaTime;
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (this.hp.cHealth < 50)
                {
                    this.hp.modifyHealth(healingFactor * Time.deltaTime);
                }
            }
            else if (timer <= 0)
            {
                this.speed = normalSpeed;
                timer = 0;
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

        //child = GameObject.Find ("SpriteRotate");
 
        // flip the child. lol
        Vector3 childScale = child.transform.localScale;
        childScale.x *= -1;
        child.transform.localScale = childScale;
    }
}
