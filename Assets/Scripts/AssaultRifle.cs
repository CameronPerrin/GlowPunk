using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : MonoBehaviour
{
    public float bulletSpeed, fireRate;
    public float inaccuracy;
    private float coolDown = 0;
    public GameObject bullet;
    private ProjectileMovementZec PMZ;
    private SpecialWeapon SW;

    public GameObject firePoint;
    public GameObject muzzleFlare;

    Vector3 target, rotate;

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
            if (Input.GetAxis("P1Fire2") != 0 && this.coolDown <= 0 && SW.bullets > 0)
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
                    bullet.tag = "User1";
                    Instantiate(bullet, transform.position, transform.rotation);

                    // muzzle flare
                    GameObject tempMuzzle;
                    tempMuzzle = Instantiate(muzzleFlare, firePoint.transform.position, firePoint.transform.rotation) as GameObject;
                    Debug.Log(firePoint.transform.position);
                    Destroy(tempMuzzle, 0.75f);

                    SW.bullets--;

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
            if (Input.GetAxis("P2Fire2") != 0 && this.coolDown <= 0 && SW.bullets > 0)
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
                    bullet.tag = "User2";
                    Instantiate(bullet, transform.position, transform.rotation);

                    SW.bullets--;
                    this.coolDown = 1 / fireRate;
                }
            }
            else
            {
                this.coolDown -= Time.deltaTime;
            }
        }

        else if (this.tag == "Player3")
        {
            if (Input.GetAxis("P3Fire2") != 0 && this.coolDown <= 0 && SW.bullets > 0)
            {
                if (Input.GetAxis("ShotJoy3X") != 0 || Input.GetAxis("ShotJoy3Y") != 0)
                {
                    target = new Vector3(Input.GetAxis("ShotJoy3X"), Input.GetAxis("ShotJoy3Y"), 0);
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
                    bullet.tag = "User3";
                    Instantiate(bullet, transform.position, transform.rotation);

                    SW.bullets--;
                    this.coolDown = 1 / fireRate;
                }
            }
            else
            {
                this.coolDown -= Time.deltaTime;
            }
        }

        else if (this.tag == "Player4")
        {
            if (Input.GetAxis("P4Fire2") != 0 && this.coolDown <= 0 && SW.bullets > 0)
            {
                if (Input.GetAxis("ShotJoy4X") != 0 || Input.GetAxis("ShotJoy4Y") != 0)
                {
                    target = new Vector3(Input.GetAxis("ShotJoy4X"), Input.GetAxis("ShotJoy4Y"), 0);
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
                    
                    PMZ.speed = bulletSpeed;
                    bullet.tag = "User4";
                    Instantiate(bullet, transform.position, transform.rotation);

                    SW.bullets--;
                    this.coolDown = 1 / fireRate;
                }
            }
            else
            {
                this.coolDown -= Time.deltaTime;
            }
        }
    }
}
