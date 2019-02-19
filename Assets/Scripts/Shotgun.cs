using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public float bulletSpeed, fireRate;
    public float spread;
    public int pellets;
    public float coolDown = 0;
    private Rigidbody2D rb;
    public GameObject bullet;
    public ProjectileMovementZec PMZ;
    //TESTING PURPOSES ONLY
    public bool useMouse;
    Vector3 target, rotate;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        PMZ = bullet.GetComponent<ProjectileMovementZec>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.tag == "Player1")
        {
            if (Input.GetAxis("P1Fire2") != 0 && this.coolDown <= 0)
            {
                if (Input.GetAxis("ShotJoy1X") != 0 || Input.GetAxis("ShotJoy1Y") != 0)
                {

                    int temp;


                    target = new Vector3(Input.GetAxis("ShotJoy1X"), Input.GetAxis("ShotJoy1Y"), 0);
                    target.Normalize();
                    float offset, convert;
                    for (int i = 0; i < pellets; i++)
                    {
                        int midpoint = (pellets - 1) / 2;
                        convert = i;

                        if (target.x > 0)
                        {
                            rotate = new Vector3(-1, 0, 0);
                            if (target.y == 0)//shot will be straight if there in no y input
                            {
                                rotate = new Vector3(0, 1, 0);
                            }
                            if (i <= midpoint)//rotate towards
                            {
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, spread * convert, 0.0f);
                            }
                            else//rotate away
                            {
                                offset = i - midpoint;
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, -spread * offset, 0.0f);
                            }
                        }
                        else if (target.x < 0)
                        {
                            rotate = new Vector3(1, 0, 0);
                            if (target.y == 0)//shot will be straight if there in no y input
                            {
                                rotate = new Vector3(0, 1, 0);
                            }
                            if (i <= midpoint)//rotate towards
                            {
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, spread * convert, 0.0f);
                            }
                            else//rotate away
                            {
                                offset = i - midpoint;
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, -spread * offset, 0.0f);
                            }
                        }
                        else//no x input
                        {
                            rotate = new Vector3(1, 0, 0);
                            if (i <= midpoint)//rotate towards
                            {
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, spread * convert, 0.0f);
                            }
                            else//rotate away
                            {
                                offset = i - midpoint;
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, -spread * offset, 0.0f);
                            }
                        }
                        //bullet.tag = "User1";
                        PMZ.speed = bulletSpeed;
                        Instantiate(bullet, transform.position, transform.rotation);
                    }

                    this.coolDown = 1 / fireRate;
                }
            }
            else
            {
                this.coolDown -= Time.deltaTime;
            }
        }
        else if (this.tag == "Player2")
        {
            if (Input.GetAxis("P2Fire2") != 0 && this.coolDown <= 0)
            {
                if (Input.GetAxis("ShotJoy2X") != 0 || Input.GetAxis("ShotJoy2Y") != 0)
                {
                    int temp;


                    target = new Vector3(Input.GetAxis("ShotJoy2X"), Input.GetAxis("ShotJoy2Y"), 0);
                    target.Normalize();
                    float offset, convert;
                    for (int i = 0; i < pellets; i++)
                    {
                        int midpoint = (pellets - 1) / 2;
                        convert = i;

                        if (target.x > 0)
                        {
                            rotate = new Vector3(-1, 0, 0);
                            if (target.y == 0)//shot will be straight if there in no y input
                            {
                                rotate = new Vector3(0, 1, 0);
                            }
                            if (i <= midpoint)//rotate towards
                            {
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, spread * convert, 0.0f);
                            }
                            else//rotate away
                            {
                                offset = i - midpoint;
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, -spread * offset, 0.0f);
                            }
                        }
                        else if (target.x < 0)
                        {
                            rotate = new Vector3(1, 0, 0);
                            if (target.y == 0)//shot will be straight if there in no y input
                            {
                                rotate = new Vector3(0, 1, 0);
                            }
                            if (i <= midpoint)//rotate towards
                            {
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, spread * convert, 0.0f);
                            }
                            else//rotate away
                            {
                                offset = i - midpoint;
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, -spread * offset, 0.0f);
                            }
                        }
                        else//no x input
                        {
                            rotate = new Vector3(1, 0, 0);
                            if (i <= midpoint)//rotate towards
                            {
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, spread * convert, 0.0f);
                            }
                            else//rotate away
                            {
                                offset = i - midpoint;
                                PMZ.velocity = Vector3.RotateTowards(target, rotate, -spread * offset, 0.0f);
                            }
                        }
                        //bullet.tag = "User2";
                        PMZ.speed = bulletSpeed;
                        Instantiate(bullet, transform.position, transform.rotation);
                    }


                }
                this.coolDown = 60;
            }
            this.coolDown -= 1;
        }
        else
        {

        }
    }
}
