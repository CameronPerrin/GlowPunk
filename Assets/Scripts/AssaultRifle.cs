﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : MonoBehaviour
{
    public float bulletSpeed, fireRate, bulletRegen;
    public float inaccuracy;
    public int magSize;
    private int bullets;
    private float coolDown = 0, regeneration = 0;
    public GameObject bullet;
    public ProjectileMovementZec PMZ;

    Vector3 target, rotate;

    // Start is called before the first frame update
    void Start()
    {
        PMZ = bullet.GetComponent<ProjectileMovementZec>();
        bullets = magSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bullets < magSize)//if we do not have max ammo regenerate ammo
        {
            regeneration += Time.deltaTime;
            if (regeneration > bulletRegen)//time to regenerate some ammo
            {
                bullets++;
                regeneration -= bulletRegen;
            }
        }
        else//if we are not setting the regenerating ammo set the regen to 0 so we start regeneration correctly
        {
            regeneration = 0;
        }
        if (this.tag == "Player1")
        {
            if (Input.GetAxis("P1Fire2") != 0 && this.coolDown <= 0 && bullets > 0)
            {
                if (Input.GetAxis("ShotJoy1X") != 0 || Input.GetAxis("ShotJoy1Y") != 0)
                {
                    target = new Vector3(Input.GetAxis("ShotJoy1X"), Input.GetAxis("ShotJoy1Y"), 0);
                    target.Normalize();
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
                    //bullet.tag = "User1";
                    PMZ.speed = bulletSpeed;
                    Instantiate(bullet, transform.position, transform.rotation);

                    bullets--;

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
            if (Input.GetAxis("P2Fire2") != 0 && this.coolDown <= 0 && bullets > 0)
            {
                if (Input.GetAxis("ShotJoy2X") != 0 || Input.GetAxis("ShotJoy2Y") != 0)
                {
                    target = new Vector3(Input.GetAxis("ShotJoy2X"), Input.GetAxis("ShotJoy2Y"), 0);
                    target.Normalize();
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
                    //bullet.tag = "User2";
                    PMZ.speed = bulletSpeed;
                    Instantiate(bullet, transform.position, transform.rotation);

                    bullets--;
                    this.coolDown = 1 / fireRate;
                }
            }
            else
            {
                this.coolDown -= Time.deltaTime;
            }
        }
        else
        {

        }
    }
}
