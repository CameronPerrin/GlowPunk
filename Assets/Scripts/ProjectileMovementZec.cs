using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileMovementZec : MonoBehaviour
{
    public float speed = 100f;
    public Vector3 velocity;
    public GameObject impact;
    public GameObject FloatingText;
    public float bulletDamage = 12;

    private GameObject Access;
    private SharedVariables share;


    // Update is called once per frame
    void Awake()
    {
        //Debug.Log("Projectile Away");
        Access = GameObject.Find("HealthVariables");
        share = Access.GetComponent<SharedVariables>();
        FloatingText.GetComponent<TextMeshPro>().text = (bulletDamage * share.damageMulti).ToString();
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
        {
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
            FloatingText.GetComponent<TextMeshPro>().text = (bulletDamage * share.damageMulti).ToString();//needed in case damage scales and changes the value of the damage
            Instantiate(FloatingText, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (this.tag == "User2" && (collision.tag == "Player1" || collision.tag == "Player3" || collision.tag == "Player4"))
        {
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
            FloatingText.GetComponent<TextMeshPro>().text = (bulletDamage * share.damageMulti).ToString();//needed in case damage scales and changes the value of the damage
            Instantiate(FloatingText, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (this.tag == "User3" && (collision.tag == "Player1" || collision.tag == "Player2" || collision.tag == "Player4"))
        {
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
            FloatingText.GetComponent<TextMeshPro>().text = (bulletDamage * share.damageMulti).ToString();//needed in case damage scales and changes the value of the damage
            Instantiate(FloatingText, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (this.tag == "User4" && (collision.tag == "Player1" || collision.tag == "Player2" || collision.tag == "Player3"))
        {
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
            FloatingText.GetComponent<TextMeshPro>().text = (bulletDamage * share.damageMulti).ToString();//needed in case damage scales and changes the value of the damage
            Instantiate(FloatingText, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.tag == "Border" || collision.tag == "Wall")
        {
            Destroy(this.gameObject);
            // Spawn impact vfx
            GameObject impactTemp;
            impactTemp = Instantiate(impact, transform.position, transform.rotation) as GameObject;
            Destroy(impactTemp, 0.75f);
        } 
    }
}
