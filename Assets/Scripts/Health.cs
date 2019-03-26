using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    private int health = 100;
    public int currentPlayer;//which player is this script on
    public GameObject Player;
    public event Action<float> OnHealthPctChanged = delegate { };

    private int cHealth;

    private GameObject Access;//Access Game Object is for the game object that tracks which players are left standing
    private SharedVariables share;
    private SpecialWeapon SW;

    private void OnEnable()
    {
        cHealth = health;
    }

    // Use this for initialization

    void Awake ()
    {
        Access = GameObject.Find("HealthVariables");
        share = Access.GetComponent<SharedVariables>();
        share.totalPlayers++;
        SW = Player.GetComponent<SpecialWeapon>();
	}

    public void modifyHealth(int amount)
    {
        cHealth += amount;
        float currentHealthPct = (float)cHealth / (float)health;
        OnHealthPctChanged(currentHealthPct);
    }

    // Update is called once per frame
    void Update() {
        if (share.totalPlayers < 2)
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
        if (this.cHealth <= 0)
        {
            share.totalPlayers--;
            Player.SetActive(false);
        }
        int temp = SW.bullets;
        
        //healthText.text = "Player 1 Health: " + P1Health.ToString();
        //healthText2.text = "Player 2 Health: " + P2Health.ToString();
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliding");
        if (collision.name == "BULLET(Clone)" || collision.name == "BULLET2(Clone)")
        {
            if (currentPlayer == 1 && (collision.tag == "User2" || collision.tag == "User3" || collision.tag == "User4"))
            {
                modifyHealth(-12); // needed to use this for healthbars
            }
            else if (currentPlayer == 2 && (collision.tag == "User1" || collision.tag == "User3" || collision.tag == "User4"))
            {
                modifyHealth(-12);
            }
            else if (currentPlayer == 3 && (collision.tag == "User1" || collision.tag == "User2" || collision.tag == "User4"))
            {
                modifyHealth(-12);
            }
            else if (currentPlayer == 4 && (collision.tag == "User1" || collision.tag == "User2" || collision.tag == "User3"))
            {
                modifyHealth(-12);
            }
        }
        if (collision.name == "SNIPERBULLET(Clone)")
        {
            if (currentPlayer == 1 && (collision.tag == "User2" || collision.tag == "User3" || collision.tag == "User4"))
            {
                modifyHealth(-25); // needed to use this for healthbars
            }
            else if (currentPlayer == 2 && (collision.tag == "User1" || collision.tag == "User3" || collision.tag == "User4"))
            {
                modifyHealth(-25);
            }
            else if (currentPlayer == 3 && (collision.tag == "User1" || collision.tag == "User2" || collision.tag == "User4"))
            {
                modifyHealth(-25);
            }
            else if (currentPlayer == 4 && (collision.tag == "User1" || collision.tag == "User2" || collision.tag == "User3"))
            {
                modifyHealth(-25);
            }
        }
    }
}
