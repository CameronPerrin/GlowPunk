using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootin : MonoBehaviour {

    RaycastHit hit;
    LayerMask layerMask = 1 << 8;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            //Debug.Log("mouse clicked");
        {
            //if (Physics.Raycast(transform.position, transform.TransformDirection(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
            //{
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            //Debug.DrawRay(transform.position, mousePos * 10, Color.white, 10, false);
            //Debug.Log("Did Hit");
            //}
        }
    }
}
