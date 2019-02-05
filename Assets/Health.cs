using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public float P1Health = 5f;
    public float P2Health = 5f;
    public GameObject P1;
    public GameObject P2;
    public Text healthText;
    public Text healthText2;
    public GameObject Player1Wins;
    private bool P1Won = false;
    private bool P2Won = false;
    public GameObject Player2Wins;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (P1Health <= 0)
        {
            P1.SetActive(false);
        }
        if (P2Health <= 0)
        {
            P2.SetActive(false);
        }

        //healthText.text = "Player 1 Health: " + P1Health.ToString();
        //healthText2.text = "Player 2 Health: " + P2Health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "User2" && this.tag == "Player1")
        {
            P1Health -= 1f;
        }
        if (collision.tag == "User1" && this.tag == "Player2")
        {
            P2Health -= 1f;
        }
        if (this.tag == "Player1")
        {
            healthText.text = "Player 1 Health: " + P1Health.ToString();
            if (P1Health <= 0 && P1Won == false)
            {
                P1Won = true;
                SceneManager.LoadScene(2);
            }
        }
        if (this.tag == "Player2")
        {
            healthText2.text = "Player 2 Health: " + P2Health.ToString();
            if (P2Health <= 0 && P2Won == false)
            {
                P2Won = true;
                SceneManager.LoadScene(3);
            }
        }
    }
}
