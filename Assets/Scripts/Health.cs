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

    private GameObject HealthGO, SpecialGO, Access;//Access Game Object is for the game object that tracks which players are left standing
    private Text healthText, specialText;
    private SharedVariables share;
    private SpecialWeapon SW;

    private void OnEnable()
    {
        cHealth = health;
    }

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
        specialText.text = "Special Ammo: " + temp.ToString();
        
        //healthText.text = "Player 1 Health: " + P1Health.ToString();
        //healthText2.text = "Player 2 Health: " + P2Health.ToString();
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliding");
        if (collision.tag == "User2" && currentPlayer == 1)
        {
            modifyHealth(-8); // needed to use this for healthbars
        }
        if (collision.tag == "User1" && currentPlayer == 2)
        {
            modifyHealth(-8);
        }
        if (currentPlayer == 1)
        {
            healthText.text = "Player 1 Health: " + cHealth.ToString();
            
        }
        else if (currentPlayer == 2)
        {
            healthText.text = "Player 2 Health: " + cHealth.ToString();
        }
    }
}
