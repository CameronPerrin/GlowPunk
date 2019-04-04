using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperProjectileMovement2 : MonoBehaviour
{
    public float speed = 100f;
    public Vector3 velocity;
    public LayerMask layerToDetect;
    //public bool reflected;
    private int reflected;
    public int ReflectionAmount = 0;
    public GameObject impact;
    // Update is called once per frame
    void Awake()
    {
        //reflected = false;
        reflected = 0;
        //ReflectionAmount = 2;
        Debug.Log("Projectile Away");

    }

    void FixedUpdate()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
        //that gives you local axis movement
        //transform.position += Vector3.right * speed * Time.deltaTime;
        /*
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 100, layerToDetect);
        if (hit.collider.gameObject.tag == "Wall")
        {
            float currentDistance = Vector2.Distance(transform.position, hit.collider.transform.position);
            print(currentDistance + "  " + hit.collider.name);
        }
        */
        LayerMask wall = LayerMask.GetMask("Player");
        RaycastHit2D upRay = Physics2D.Raycast(transform.position, Vector2.up, 100, wall);
        RaycastHit2D rightRay = Physics2D.Raycast(transform.position, Vector2.right, 100, wall);
        RaycastHit2D downRay = Physics2D.Raycast(transform.position, Vector2.down, 100, wall);
        RaycastHit2D leftRay = Physics2D.Raycast(transform.position, Vector2.left, 100, wall);

        if (upRay.distance <= 1 && reflected < ReflectionAmount && (upRay.collider.gameObject.tag == "Wall" || upRay.collider.gameObject.tag == "Border"))
        { velocity = new Vector3(velocity.x, -velocity.y, 0); reflected++; Debug.Log("UpRay Triggered");
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
        }

        else if (downRay.distance <= 1 && reflected < ReflectionAmount && (downRay.collider.gameObject.tag == "Wall" || downRay.collider.gameObject.tag == "Border"))
        { velocity = new Vector3(velocity.x, -velocity.y, 0); reflected++; Debug.Log("DownRay Triggered");
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
        }

        else if (rightRay.distance <= 1 && reflected < ReflectionAmount && (rightRay.collider.gameObject.tag == "Wall" || rightRay.collider.gameObject.tag == "Border"))
        { velocity = new Vector3(-velocity.x, velocity.y, 0); reflected++; Debug.Log("RightRay Triggered");
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
        }

        else if (leftRay.distance <= 1 && reflected < ReflectionAmount && (leftRay.collider.gameObject.tag == "Wall" || leftRay.collider.gameObject.tag == "Border"))
        { velocity = new Vector3(-velocity.x, velocity.y, 0); reflected++; Debug.Log("LeftRay Triggered");
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
        }
        else { };
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Wall" || collision.tag == "Border") && reflected == ReflectionAmount)
        {
            Destroy(this.gameObject);
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
        }
        if (this.tag == "User1" && (collision.tag == "Player2" || collision.tag == "Player3" || collision.tag == "Player4"))
        {
            Destroy(this.gameObject);
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
        }
        if (this.tag == "User2" && (collision.tag == "Player1" || collision.tag == "Player3" || collision.tag == "Player4"))
        {
            Destroy(this.gameObject);
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
        }
        if (this.tag == "User3" && (collision.tag == "Player1" || collision.tag == "Player2" || collision.tag == "Player4"))
        {
            Destroy(this.gameObject);
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
        }
        if (this.tag == "User4" && (collision.tag == "Player1" || collision.tag == "Player2" || collision.tag == "Player3"))
        {
            Destroy(this.gameObject);
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
        }

        
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }*/
}


/*if ((collision.tag == "Wall" || collision.tag == "Border") && reflected == false)
        {
            LayerMask wall = LayerMask.GetMask("PlayerProjectile");
            float closest = 0f;
            RaycastHit2D upRay = Physics2D.Raycast(transform.position, Vector2.up, 100, wall);
            RaycastHit2D rightRay = Physics2D.Raycast(transform.position, Vector2.right, 100, wall);
            RaycastHit2D downRay = Physics2D.Raycast(transform.position, Vector2.down, 100, wall);
            RaycastHit2D leftRay = Physics2D.Raycast(transform.position, Vector2.left, 100, wall);

            //closest = upRay.distance;
            string closestWall = "";
            /*if (rightRay.distance <= closest)
            { closest = rightRay.distance; closestWall = "rightRay"; }
            else if (downRay.distance <= closest)
            { closest = downRay.distance; closestWall = "downRay"; }
            else if (leftRay.distance <= closest)
            { closest = leftRay.distance; closestWall = "leftRay"; }
            else { }
            if (upRay.distance != 0)
            { closest = upRay.distance; closestWall = "upRay";}
            else if (rightRay.distance != 0)
            { closest = rightRay.distance; closestWall = "rightRay"; }
            else if (leftRay.distance != 0)
            { closest = leftRay.distance; closestWall = "leftRay"; }
            else if (downRay.distance != 0)
            { closest = downRay.distance; closestWall = "downRay"; }
            
            Debug.Log(upRay.distance);
            Debug.Log(rightRay.distance);
            Debug.Log(leftRay.distance);
            Debug.Log(downRay.distance);
            Debug.Log(closestWall);

            if (closestWall == "rightRay" || closestWall == "leftRay")
            {
                velocity = new Vector3(-velocity.x, velocity.y, 0);
                reflected = true;
            }
            else if (closestWall == "upRay" || closestWall == "downRay")
            {
                velocity = new Vector3(velocity.x, -velocity.y, 0);
                reflected = true;
            }
        }
    */
