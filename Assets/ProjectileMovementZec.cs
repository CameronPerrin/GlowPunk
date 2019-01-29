using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementZec : MonoBehaviour
{
    public float speed;
    public Vector3 velocity;

    // Update is called once per frame
    void Awake()
    {
        //Debug.Log("Projectile Away");
        
    }

    void FixedUpdate()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
        //that gives you local axis movement
        //transform.position += Vector3.right * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
