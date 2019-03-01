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
        if(moved >= distance)//BOOM TIME
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
