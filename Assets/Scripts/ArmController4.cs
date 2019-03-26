using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("ShotJoy4X");
        float vertical = Input.GetAxis("ShotJoy4Y");
        float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;


        if (gameObject.transform.root.GetComponent<PlayerMovement>().facingRight)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        if (!gameObject.transform.root.GetComponent<PlayerMovement>().facingRight)
        {
            if (Input.GetAxis("ShotJoy4X") == 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, (angle - 180)));
            }
        }
    }
}
