using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 shootDirection;
    private float xMag;
    private float yMag;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        
	}
   
    
    void Awake ()
    {
        xMag = (Mathf.Sqrt(Mathf.Pow(Input.mousePosition.x, 2) + Mathf.Pow(transform.position.x, 2)));
        yMag = (Mathf.Sqrt(Mathf.Pow(Input.mousePosition.y, 2) + Mathf.Pow(transform.position.y, 2)));
        shootDirection = new Vector2((Input.mousePosition.x - transform.position.x)/xMag, (Input.mousePosition.y - transform.position.y)/yMag);
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = shootDirection * 2; //* new Vector2 (.02f,.02f);
	}
}
