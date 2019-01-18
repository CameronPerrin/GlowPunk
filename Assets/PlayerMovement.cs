using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //public GameObject player;
    private Rigidbody2D rb2d;
    public float move;
        
    // Use this for initialization
    void Start () {
        Rigidbody2D rb2d = this.GetComponent<Rigidbody2D>();
        move = 0.25f;
        rb2d.angularVelocity = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (this.tag == "Player1")
        {
            if (Input.GetAxis("MoveJoy1Y") != 0 || Input.GetAxis("MoveJoy1X") != 0)
            {
                this.transform.position += new Vector3(Input.GetAxis("MoveJoy1X") * move, Input.GetAxis("MoveJoy1Y") * -move, 0);
            }
        }
        else if (this.tag == "Player2")
        {
            if (Input.GetAxis("MoveJoy2Y") != 0 || Input.GetAxis("MoveJoy2X") != 0)
            {
                this.transform.position += new Vector3(Input.GetAxis("MoveJoy2X") * move, Input.GetAxis("MoveJoy2Y") * -move, 0);
            }
        }
        else { }
    }
}
