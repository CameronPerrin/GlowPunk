using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float throwSpeed, fireRate, throwDistance, projSpeed;
    private float coolDown = 0;
    public GameObject grenade;
    private BombMovement BM;
    private SpecialWeapon SW;

    public GameObject muzzleFlare;

    Vector3 target, rotate;

    // Start is called before the first frame update
    void Start()
    {
        BM = grenade.GetComponent<BombMovement>();
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

                    grenade.tag = "User1";
                    BM.speed = throwSpeed;
                    BM.projSpeed = projSpeed;
                    BM.distance = throwDistance;
                    BM.velocity = target;
                    Instantiate(grenade, transform.position, transform.rotation);

                    

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
                    grenade.tag = "User2";
                    BM.speed = throwSpeed;
                    BM.projSpeed = projSpeed;
                    BM.distance = throwDistance;
                    BM.velocity = target;
                    Instantiate(grenade, transform.position, transform.rotation);

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
                    grenade.tag = "User3";
                    BM.speed = throwSpeed;
                    BM.projSpeed = projSpeed;
                    BM.distance = throwDistance;
                    BM.velocity = target;
                    Instantiate(grenade, transform.position, transform.rotation);

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
                    grenade.tag = "User4";
                    BM.speed = throwSpeed;
                    BM.projSpeed = projSpeed;
                    BM.distance = throwDistance;
                    BM.velocity = target;
                    Instantiate(grenade, transform.position, transform.rotation);

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
