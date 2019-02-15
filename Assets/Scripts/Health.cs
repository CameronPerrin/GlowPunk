using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public float health = 5f;
    public int currentPlayer;//which player is this script on
    public GameObject Player;
    private GameObject TextGO, Access;//Access Game Object is for the game object that tracks which players are left standing
    private Text healthText;
    private SharedVariables share;
    
    // Use this for initialization
    void Awake ()
    {
        if(currentPlayer == 1)
        {
            TextGO = GameObject.Find("P1 Health");
        }
        else if(currentPlayer == 2)
        {
            TextGO = GameObject.Find("P2 Health");
        }

        Access = GameObject.Find("HealthVariables");
        healthText = TextGO.GetComponent<Text>();
        share = Access.GetComponent<SharedVariables>();
        share.totalPlayers++;
	}

    // Update is called once per frame
    void Update() {
        if(share.totalPlayers < 2)
        {
            if(currentPlayer == 1)//Player 1 wins
            {
                SceneManager.LoadScene("EndingScreen2");
            }
            else if(currentPlayer == 2)
            {
                SceneManager.LoadScene("EndingScreen1");
            }
        }
        if (this.health <= 0)
        {
            share.totalPlayers--;
            Player.SetActive(false);
        }
        //healthText.text = "Player 1 Health: " + P1Health.ToString();
        //healthText2.text = "Player 2 Health: " + P2Health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliding");
        if (collision.tag == "User2" && currentPlayer == 1)
        {
            health -= 1f;
        }
        if (collision.tag == "User1" && currentPlayer == 2)
        {
            health -= 1f;
        }
        if (currentPlayer == 1)
        {
            healthText.text = "Player 1 Health: " + health.ToString();
   
        }
        else if (currentPlayer == 2)
        {
            healthText.text = "Player 2 Health: " + health.ToString();
        }
    }
}
