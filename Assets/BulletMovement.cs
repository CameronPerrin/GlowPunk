using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    //private Rigidbody2D rb;
    //private Vector3 shootDirection;
    //private float xMag;
    //private float yMag;
    public Vector3 target;
    public float speed = 100.0f;

    // Use this for initialization
    void OnStart () {
        // rb = this.GetComponent<Rigidbody2D>();
        //xMag = (Mathf.Sqrt(Mathf.Pow(Input.mousePosition.x, 2) + Mathf.Pow(transform.position.x, 2)));
        //yMag = (Mathf.Sqrt(Mathf.Pow(Input.mousePosition.y, 2) + Mathf.Pow(transform.position.y, 2)));
        //shootDirection = new Vector2((Input.mousePosition.x - transform.position.x) / xMag, (Input.mousePosition.y - transform.position.y) / yMag);
        /*shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;*/
        
        
    }
    /*Camera.main.ScreenToWorldPoint(Input.mousePosition)*/

    void Awake ()
    {
        target = new Vector3(Input.GetAxis("ShotDirectionHori"), Input.GetAxis("ShotDirectionVerti"), 0); //+ transform.position;
        //target.z = 0.0f;
        target.Normalize();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //rb.velocity = shootDirection * 2; //* new Vector2 (.02f,.02f);
        float step = speed * Time.deltaTime;
        transform.position += target; //Vector2.MoveTowards(transform.position, target, 1);

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BUllet des");
        Destroy(this.gameObject);
        
    }
}
