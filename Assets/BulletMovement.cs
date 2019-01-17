using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 shootDirection; 

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        shootDirection = new Vector2(Input.mousePosition.x - transform.position.x, Input.mousePosition.y - transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
