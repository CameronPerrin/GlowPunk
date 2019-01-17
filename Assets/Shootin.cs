using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootin : MonoBehaviour {

    RaycastHit hit;
    LayerMask layerMask = 1 << 8;
    public GameObject bullet;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Fire1") != 0)//Input.GetKeyDown(KeyCode.Mouse0))
            //Debug.Log("mouse clicked");
        {
            //if (Physics.Raycast(transform.position, transform.TransformDirection(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
            //{
            //Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            bullet.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, 0);
            Instantiate(bullet);
            
            //Debug.DrawRay(transform.position, mousePos * 10, Color.white, 10, false);
            //Debug.Log("Did Hit");
            //}
        }
    }
}
