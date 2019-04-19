﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : MonoBehaviour
{
    public float bulletSpeed, fireRate;
    public float inaccuracy;
    public GameObject bullet;
    private ProjectileMovementZec PMZ;
    private SpecialWeapon SW;
    public int burst;

    public GameObject firePoint;
    public GameObject muzzleFlare;

    Vector3 target, rotate;
    private string theTag;

    // Start is called before the first frame update
    void Start()
    {
        PMZ = bullet.GetComponent<ProjectileMovementZec>();
        SW = this.GetComponent<SpecialWeapon>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.tag == "Player1")
        {
            if (Input.GetAxis("P1Fire2") != 0 && SW.isReady)
            {
                
                // Set a number 1 or 0 to represent the amount of energy left in the ammo bar
                if (Input.GetAxis("ShotJoy1X") != 0 || Input.GetAxis("ShotJoy1Y") != 0)
                {
                    target = new Vector3(Input.GetAxis("ShotJoy1X"), Input.GetAxis("ShotJoy1Y"), 0);
                    target.Normalize();
                    SW.isReady = false;

                    theTag = "User1";

                    for(int i = 0; i < burst; i++)//for loop will set up the time to instantiate bullets for burst
                    {
                        Invoke("ShootAMan", fireRate * i);//do the thing at different time
                    }
                }
            }
        }
        else if (this.tag == "Player2")
        {
            if (Input.GetAxis("P2Fire2") != 0  && SW.isReady)
            {
                if (Input.GetAxis("ShotJoy2X") != 0 || Input.GetAxis("ShotJoy2Y") != 0)
                {
                    target = new Vector3(Input.GetAxis("ShotJoy2X"), Input.GetAxis("ShotJoy2Y"), 0);
                    target.Normalize();
                    SW.isReady = false;

                    theTag = "User2";
                    for (int i = 0; i < burst; i++)//for loop will set up the time to instantiate bullets for burst
                    {
                        Invoke("ShootAMan", fireRate * i);//do the thing at different time
                    }
                }
            }
        }

        else if (this.tag == "Player3")
        {
            if (Input.GetAxis("P3Fire2") != 0 && SW.isReady)
            {
                if (Input.GetAxis("ShotJoy3X") != 0 || Input.GetAxis("ShotJoy3Y") != 0)
                {
                    target = new Vector3(Input.GetAxis("ShotJoy3X"), Input.GetAxis("ShotJoy3Y"), 0);
                    target.Normalize();
                    SW.isReady = false;

                    theTag = "User3";
                    for (int i = 0; i < burst; i++)//for loop will set up the time to instantiate bullets for burst
                    {
                        Invoke("ShootAMan", fireRate * i);//do the thing at different time
                    }
                }
            }
        }

        else if (this.tag == "Player4")
        {
            if (Input.GetAxis("P4Fire2") != 0 && SW.isReady)
            {
                if (Input.GetAxis("ShotJoy4X") != 0 || Input.GetAxis("ShotJoy4Y") != 0)
                {
                    target = new Vector3(Input.GetAxis("ShotJoy4X"), Input.GetAxis("ShotJoy4Y"), 0);
                    target.Normalize();
                    SW.isReady = false;

                    theTag = "User4";
                    for (int i = 0; i < burst; i++)//for loop will set up the time to instantiate bullets for burst
                    {
                        Invoke("ShootAMan", fireRate * i);//do the thing at different time
                    }
                }
            }
        }
    }

    void ShootAMan ()
    {
        if(theTag == "User1")//player 1 is firing
        {
            if(Input.GetAxis("ShotJoy1X") != 0 || Input.GetAxis("ShotJoy1Y") != 0)//do they have an input
            {
                target = new Vector3(Input.GetAxis("ShotJoy1X"), Input.GetAxis("ShotJoy1Y"), 0);
                target.Normalize();
            }
        }
        else if (theTag == "User2")//player 1 is firing
        {
            if (Input.GetAxis("ShotJoy2X") != 0 || Input.GetAxis("ShotJoy2Y") != 0)//do they have an input
            {
                target = new Vector3(Input.GetAxis("ShotJoy2X"), Input.GetAxis("ShotJoy2Y"), 0);
                target.Normalize();
            }
        }
        else if (theTag == "User3")//player 1 is firing
        {
            if (Input.GetAxis("ShotJoy3X") != 0 || Input.GetAxis("ShotJoy3Y") != 0)//do they have an input
            {
                target = new Vector3(Input.GetAxis("ShotJoy3X"), Input.GetAxis("ShotJoy3Y"), 0);
                target.Normalize();
            }
        }
        else if (theTag == "User4")//player 1 is firing
        {
            if (Input.GetAxis("ShotJoy4X") != 0 || Input.GetAxis("ShotJoy4Y") != 0)//do they have an input
            {
                target = new Vector3(Input.GetAxis("ShotJoy4X"), Input.GetAxis("ShotJoy4Y"), 0);
                target.Normalize();
            }
        }

        if (target.x > 0)
        {
            rotate = new Vector3(-1, 0, 0);
            if (target.y == 0)//need to change vector if y = 0 or no rotation will occur
            {
                rotate = new Vector3(0, 1, 0);
            }
            PMZ.velocity = Vector3.RotateTowards(target, rotate, Random.Range(-inaccuracy, inaccuracy), 0.0f);//sets bullets velocity with inaccuracy
        }
        else if (target.x < 0)
        {
            rotate = new Vector3(1, 0, 0);
            if (target.y == 0)//need to change vector if y = 0 or no rotation will occur
            {
                rotate = new Vector3(0, 1, 0);
            }
            PMZ.velocity = Vector3.RotateTowards(target, rotate, Random.Range(-inaccuracy, inaccuracy), 0.0f);//sets bullets velocity with inaccuracy
        }
        else//no x input
        {
            rotate = new Vector3(1, 0, 0);
            PMZ.velocity = Vector3.RotateTowards(target, rotate, Random.Range(-inaccuracy, inaccuracy), 0.0f);//sets bullets velocity with inaccuracy
        }

        PMZ.speed = bulletSpeed;
        bullet.tag = theTag;
        Instantiate(bullet, transform.position, transform.rotation);

        // muzzle flare
        GameObject tempMuzzle;
        tempMuzzle = Instantiate(muzzleFlare, firePoint.transform.position, firePoint.transform.rotation) as GameObject;
        Debug.Log(firePoint.transform.position);
        Destroy(tempMuzzle, 0.75f);
    }
}
