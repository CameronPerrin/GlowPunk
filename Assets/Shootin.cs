using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootin : MonoBehaviour {

    RaycastHit hit;
    //LayerMask layerMask = 1 << 8;
    public GameObject bullet;
    private Rigidbody2D rb;
    public int timer;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (this.tag == "Player1")
        {
            if (Input.GetAxis("P1Fire1") != 0 && this.timer <= 0)
            {
                if (Input.GetAxis("ShotJoy1X") != 0 || Input.GetAxis("ShotJoy1Y") != 0)
                {
                    bullet.transform.position = new Vector3(this.rb.transform.position.x, this.rb.transform.position.y, 0);
                    bullet.tag = "User1";
                    Instantiate(bullet);
                    this.timer = 25;
                }
            }
            else
            {
                this.timer--;
            }
        }
        else if (this.tag == "Player2")
        {
            if (Input.GetAxis("P2Fire1") != 0 && this.timer <= 0)
            {
                if (Input.GetAxis("ShotJoy2X") != 0 || Input.GetAxis("ShotJoy2Y") != 0)
                {
                    bullet.transform.position = new Vector3(this.rb.transform.position.x, this.rb.transform.position.y, 0);
                    bullet.tag = "User2";
                    Instantiate(bullet);
                    this.timer = 25;
                }
            }
            else
            {
                this.timer--;
            }
        }
        else {}
    }
}
