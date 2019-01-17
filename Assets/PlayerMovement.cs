using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

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
	void Update () {
        if (this.tag == "Player1")
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
               this.transform.position += new Vector3(Input.GetAxis("Horizontal") * move, Input.GetAxis("Vertical") * -move, 0);
            }
           /* if (Input.GetAxis("Horizontal") == -1)
                transform.position += new Vector3(-move, 0, 0);
            if (Input.GetAxis("Vertical") == -1)
                transform.position += new Vector3(0, -move, 0);
            if (Input.GetAxis("Horizontal") == 1)
                transform.position += new Vector3(move, 0, 0);*/
        }
        else if (this.tag == "Player2")
        {
            if (Input.GetKey("w"))
                this.transform.position += new Vector3(0, move, 0);
            if (Input.GetKey("a"))
                this.transform.position += new Vector3(-move, 0, 0);
            if (Input.GetKey("s"))
                this.transform.position += new Vector3(0, -move, 0);
            if (Input.GetKey("d"))
                this.transform.position += new Vector3(move, 0, 0);
        }
    }
}
