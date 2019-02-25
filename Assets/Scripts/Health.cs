using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public float health = 5f;
    public int currentPlayer;//which player is this script on
    public GameObject Player;
    private GameObject HealthGO, SpecialGO, Access;//Access Game Object is for the game object that tracks which players are left standing
    private Text healthText, specialText;
    private SharedVariables share;
    private SpecialWeapon SW;
    
    // Use this for initialization
    void Awake ()
    {
        if(currentPlayer == 1)
        {
            HealthGO = GameObject.Find("P1 Health");
            SpecialGO = GameObject.Find("P1 Special");

        }
        else if(currentPlayer == 2)
        {
            HealthGO = GameObject.Find("P2 Health");
            SpecialGO = GameObject.Find("P2 Special");
        }

        Access = GameObject.Find("HealthVariables");
        healthText = HealthGO.GetComponent<Text>();
        specialText = SpecialGO.GetComponent<Text>();
        share = Access.GetComponent<SharedVariables>();
        share.totalPlayers++;
        SW = Player.GetComponent<SpecialWeapon>();
	}

    // Update is called once per frame
    void Update() {
        if(share.totalPlayers < 2)
        {
            if (Player.name.Contains("P1Choice1"))//Player 1 wins
                {
                    SceneManager.LoadScene("EndingScreenP1Gunner");
                }
                else if (Player.name.Contains("P1Choice2"))
                {
                    SceneManager.LoadScene("EndingScreenP1Shotgunner");
                }
                else if (Player.name.Contains("P2Choice1"))
                {
                    SceneManager.LoadScene("EndingScreenP2Gunner");
                }
                else if (Player.name.Contains("P2Choice2"))
                {
                    SceneManager.LoadScene("EndingScreenP2Shotgunner");
                }
        }
        if (this.health <= 0)
        {
            share.totalPlayers--;
            Player.SetActive(false);
        }
        int temp = SW.bullets;
        specialText.text = "Special Ammo: " + temp.ToString();
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
