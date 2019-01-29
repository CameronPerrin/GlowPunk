using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //public GameObject player;
    private Rigidbody2D rb2d;
    public float P1move;
    public float P2move;
    public float P1DashTimer;
    public float P2DashTimer;
        
    // Use this for initialization
    void Start () {
        Rigidbody2D rb2d = this.GetComponent<Rigidbody2D>();
        P1move = 0.25f;
        P2move = 0.25f;
        P1DashTimer = 0;
        P2DashTimer = 0;
        rb2d.angularVelocity = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        if (this.tag == "Player1")
        {
            if (Input.GetAxis("P1Dash") != 0 && P1DashTimer <= 0)
            {
                P1move = 3;
                P1DashTimer = 60;
            }
            if (Input.GetAxis("MoveJoy1Y") != 0 || Input.GetAxis("MoveJoy1X") != 0)
            {
                this.transform.position += new Vector3(Input.GetAxis("MoveJoy1X") * P1move, Input.GetAxis("MoveJoy1Y") * -P1move, 0);
            }
            P1move = .25f;
            P1DashTimer -= 1;
            
        }
        else if (this.tag == "Player2")
        {
            if (Input.GetAxis("P2Dash") != 0 && P2DashTimer <= 0)
            {
                P2move = 3;
                P2DashTimer = 60;
            }
            if (Input.GetAxis("MoveJoy2Y") != 0 || Input.GetAxis("MoveJoy2X") != 0)
            {
                this.transform.position += new Vector3(Input.GetAxis("MoveJoy2X") * P2move, Input.GetAxis("MoveJoy2Y") * -P2move, 0);
            }
            P2move = .25f;
            P2DashTimer -= 1;
        }
        else { }
    }
}
