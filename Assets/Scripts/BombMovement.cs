using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    public float speed, distance, projSpeed;
    private float moved;
    public Vector3 velocity;
    public GameObject projectile;
    private ProjectileMovementZec PMZ;
    private Vector3 temp;//temporary vector we will use to help instantiate the bullets

    void Awake()
    {
        PMZ = projectile.GetComponent<ProjectileMovementZec>();
        moved = 0;
    }

    void FixedUpdate()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
        moved += speed * Time.deltaTime;

        LayerMask wall = LayerMask.GetMask("Player");
        RaycastHit2D upRay = Physics2D.Raycast(transform.position, Vector2.up, 100, wall);
        RaycastHit2D rightRay = Physics2D.Raycast(transform.position, Vector2.right, 100, wall);
        RaycastHit2D downRay = Physics2D.Raycast(transform.position, Vector2.down, 100, wall);
        RaycastHit2D leftRay = Physics2D.Raycast(transform.position, Vector2.left, 100, wall);

        if (upRay.distance <= 1 && (upRay.collider.gameObject.tag == "Wall" || upRay.collider.gameObject.tag == "Border"))
        { velocity = new Vector3(velocity.x, -velocity.y, 0); Debug.Log("UpRay Triggered"); }
        else if (downRay.distance <= 1 && (downRay.collider.gameObject.tag == "Wall" || downRay.collider.gameObject.tag == "Border"))
        { velocity = new Vector3(velocity.x, -velocity.y, 0); Debug.Log("DownRay Triggered"); }
        else if (rightRay.distance <= 1 && (rightRay.collider.gameObject.tag == "Wall" || rightRay.collider.gameObject.tag == "Border"))
        { velocity = new Vector3(-velocity.x, velocity.y, 0); Debug.Log("RightRay Triggered"); }
        else if (leftRay.distance <= 1 && (leftRay.collider.gameObject.tag == "Wall" || leftRay.collider.gameObject.tag == "Border"))
        { velocity = new Vector3(-velocity.x, velocity.y, 0); Debug.Log("LeftRay Triggered"); }

        if (moved >= distance)//BOOM TIME
        {
            projectile.tag = this.tag;//copy the tag of the bullet with the tag of the bomb
            temp = new Vector3(0,1,0);//upwards projectile
            PMZ.velocity = temp;
            PMZ.speed = projSpeed;
            Instantiate(projectile, transform.position, transform.rotation);

            temp = new Vector3(1, 1, 0);//up right
            temp.Normalize();
            PMZ.velocity = temp;
            Instantiate(projectile, transform.position, transform.rotation);

            temp = new Vector3(1, 0, 0);//right
            PMZ.velocity = temp;
            Instantiate(projectile, transform.position, transform.rotation);

            temp = new Vector3(1, -1, 0);//down right
            temp.Normalize();
            PMZ.velocity = temp;
            Instantiate(projectile, transform.position, transform.rotation);

            temp = new Vector3(0, -1, 0);//downwards
            PMZ.velocity = temp;
            Instantiate(projectile, transform.position, transform.rotation);

            temp = new Vector3(-1, -1, 0);//down left
            temp.Normalize();
            PMZ.velocity = temp;
            Instantiate(projectile, transform.position, transform.rotation);

            temp = new Vector3(-1, 0, 0);//left
            PMZ.velocity = temp;
            Instantiate(projectile, transform.position, transform.rotation);

            temp = new Vector3(-1, 1, 0);//up left
            temp.Normalize();
            PMZ.velocity = temp;
            Instantiate(projectile, transform.position, transform.rotation);

            Destroy(this.gameObject);//now that we have made all the projectiles destroy the object
        }
    }
}
