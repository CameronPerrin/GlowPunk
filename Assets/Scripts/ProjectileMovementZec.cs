using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementZec : MonoBehaviour
{
    public float speed = 100f;
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
        if (this.tag == "User1" && (collision.tag == "Player2" || collision.tag == "Player3" || collision.tag == "Player4"))
            Destroy(this.gameObject);
        if (this.tag == "User2" && (collision.tag == "Player1" || collision.tag == "Player3" || collision.tag == "Player4"))
            Destroy(this.gameObject);
        if (this.tag == "User3" && (collision.tag == "Player1" || collision.tag == "Player2" || collision.tag == "Player4"))
            Destroy(this.gameObject);
        if (this.tag == "User4" && (collision.tag == "Player1" || collision.tag == "Player2" || collision.tag == "Player3"))
            Destroy(this.gameObject);
        if (collision.tag == "Border" || collision.tag == "Wall")
            Destroy(this.gameObject);
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }*/
}
