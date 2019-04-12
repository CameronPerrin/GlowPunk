using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{

    public float health = 100;
    public int currentPlayer;//which player is this script on
    public GameObject Player;
    public event Action<float> OnHealthPctChanged = delegate { };
    private float delay = 4.0f;
    private float wait = 0.0f;//variable will count up to delay before it goes to the next scene
    public GameObject FloatingTextPrefab_Normal;
    public GameObject FloatingTextPrefab_Sniper;
    public GameObject FloatingTextPrefab_SMG;

    public float cHealth;

    private GameObject Access;//Access Game Object is for the game object that tracks which players are left standing
    private SharedVariables share;
    private SpecialWeapon SW;
    private TextMeshProUGUI textMesh;

    private float bulletDamage;
    private float sniperDamage;
    private int startingPlayers;
    //private float damageAdd;
    //private float damageMulti;
    private bool swtich = false, win = false;

    private void OnEnable()
    {
        cHealth = health;
        bulletDamage = -12;
        sniperDamage = -25;
    }

    // Use this for initialization

    void Awake()
    {
        Access = GameObject.Find("HealthVariables");
        share = Access.GetComponent<SharedVariables>();
        share.totalPlayers++;
        SW = Player.GetComponent<SpecialWeapon>();
        Debug.Log(share.totalPlayers);
        
    }

    public void modifyHealth(float amount)
    {
        cHealth += amount;
        float currentHealthPct = (float)cHealth / (float)health;
        OnHealthPctChanged(currentHealthPct);
    }

    // Update is called once per frame
    void Update()
    {
        if (!swtich)
            { startingPlayers = share.totalPlayers; swtich = true; Debug.Log(startingPlayers); }
        if (share.totalPlayers < 2)
        {
            if(!win)//run through this once when we win
            {
                DestroyProjectiles();
                win = true;
                wait = 0;
                ///POST PROCESSING EFFECT AT END OF GAME CODE SHOULD GO HERE
            }
            
            if (wait >= delay)//goto next scene
            {
                NextScene();
            }
            else
                wait += Time.deltaTime;
        }
        if (this.cHealth <= 0)
        {
            share.totalPlayers--;
            /*if(share.totalPlayers == 3 && startingPlayers == 4)//currently unneccessary with new build
            {
                //Debug.Log("Entered if");
                share.damageMulti += share.damageAdd;
            }
            else if (share.totalPlayers == 2 && startingPlayers == 4)
            {
                share.damageMulti += share.damageAdd;
            }
            else if (share.totalPlayers == 2 && startingPlayers == 3)
            {
                share.damageMulti += 2*share.damageAdd;
            }*/
            //Player.SetActive(false);
            Destroy(this.Player.gameObject);
        }
        //int temp = SW.bullets;

        //healthText.text = "Player 1 Health: " + P1Health.ToString();
        //healthText2.text = "Player 2 Health: " + P2Health.ToString();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliding");
        if (collision.name == "BULLET(Clone)" || collision.name == "BULLET2(Clone)" || collision.name == "BULLET3(Clone)")
        {
            if (collision.name == "BULLET3(Clone)")
            {
                if (currentPlayer == 1 && (collision.tag == "User2" || collision.tag == "User3" || collision.tag == "User4"))
                {
                    //ShowFloatingText_SMG(bulletDamage * share.damageMulti);
                    modifyHealth(bulletDamage * share.damageMulti); // needed to use this for healthbars
                }
                else if (currentPlayer == 2 && (collision.tag == "User1" || collision.tag == "User3" || collision.tag == "User4"))
                {
                    //ShowFloatingText_SMG(bulletDamage * share.damageMulti);
                    modifyHealth(bulletDamage * share.damageMulti);
                }
                else if (currentPlayer == 3 && (collision.tag == "User1" || collision.tag == "User2" || collision.tag == "User4"))
                {
                    //ShowFloatingText_SMG(bulletDamage * share.damageMulti);
                    modifyHealth(bulletDamage * share.damageMulti);
                }
                else if (currentPlayer == 4 && (collision.tag == "User1" || collision.tag == "User2" || collision.tag == "User3"))
                {
                    //ShowFloatingText_SMG(bulletDamage * share.damageMulti);
                    modifyHealth(bulletDamage * share.damageMulti);
                }
            }
            else
            {
                if (currentPlayer == 1 && (collision.tag == "User2" || collision.tag == "User3" || collision.tag == "User4"))
                {
                    //ShowFloatingText_Normal(bulletDamage * share.damageMulti);
                    modifyHealth(bulletDamage * share.damageMulti); // needed to use this for healthbars
                }
                else if (currentPlayer == 2 && (collision.tag == "User1" || collision.tag == "User3" || collision.tag == "User4"))
                {
                    //ShowFloatingText_Normal(bulletDamage * share.damageMulti);
                    modifyHealth(bulletDamage * share.damageMulti);
                }
                else if (currentPlayer == 3 && (collision.tag == "User1" || collision.tag == "User2" || collision.tag == "User4"))
                {
                    //ShowFloatingText_Normal(bulletDamage * share.damageMulti);
                    modifyHealth(bulletDamage * share.damageMulti);
                }
                else if (currentPlayer == 4 && (collision.tag == "User1" || collision.tag == "User2" || collision.tag == "User3"))
                {
                    //ShowFloatingText_Normal(bulletDamage * share.damageMulti);
                    modifyHealth(bulletDamage * share.damageMulti);
                }
            }
        }
        if (collision.name == "SNIPERBULLET(Clone)")
        {
            if (currentPlayer == 1 && (collision.tag == "User2" || collision.tag == "User3" || collision.tag == "User4"))
            {
                //ShowFloatingText_Sniper(sniperDamage * share.damageMulti);
                modifyHealth(sniperDamage); // needed to use this for healthbars
            }
            else if (currentPlayer == 2 && (collision.tag == "User1" || collision.tag == "User3" || collision.tag == "User4"))
            {
                //ShowFloatingText_Sniper(sniperDamage * share.damageMulti);
                modifyHealth(sniperDamage);
            }
            else if (currentPlayer == 3 && (collision.tag == "User1" || collision.tag == "User2" || collision.tag == "User4"))
            {
                //ShowFloatingText_Sniper(sniperDamage * share.damageMulti);
                modifyHealth(sniperDamage);
            }
            else if (currentPlayer == 4 && (collision.tag == "User1" || collision.tag == "User2" || collision.tag == "User3"))
            {
                //ShowFloatingText_Sniper(sniperDamage * share.damageMulti);
                modifyHealth(sniperDamage);
            }
        }
    }
    
    void ShowFloatingText_Normal(float damage)
    {
       damage *= -1; // to display a positive number instead of a negative one.
       var go = Instantiate(FloatingTextPrefab_Normal, transform.position, Quaternion.identity, transform);
       go.GetComponent<TextMeshPro>().text = damage.ToString();
    }

    void ShowFloatingText_Sniper(float damage)
    {
        damage *= -1; // to display a positive number instead of a negative one.
        var go = Instantiate(FloatingTextPrefab_Sniper, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = damage.ToString();
    }

    void ShowFloatingText_SMG(float damage)
    {
        damage *= -1; // to display a positive number instead of a negative one.
        var go = Instantiate(FloatingTextPrefab_SMG, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = damage.ToString();
    }

    void NextScene()
    {
        if (Player.name.Contains("P1Choice1"))//Player 1 wins
        {
            SceneManager.LoadScene("EndingScreenP1Gunner");
        }
        else if (Player.name.Contains("P1Choice2"))
        {
            SceneManager.LoadScene("EndingScreenP1Shotgunner");
        }
        else if (Player.name.Contains("P1Choice3"))
        {
            SceneManager.LoadScene("EndingScreenP1Bomber");
        }
        else if (Player.name.Contains("P1Choice4"))
        {
            SceneManager.LoadScene("EndingScreenP1Sniper");
        }
        else if (Player.name.Contains("P2Choice1"))//Player 1 wins
        {
            SceneManager.LoadScene("EndingScreenP2Gunner");
        }
        else if (Player.name.Contains("P2Choice2"))
        {
            SceneManager.LoadScene("EndingScreenP2Shotgunner");
        }
        else if (Player.name.Contains("P2Choice3"))
        {
            SceneManager.LoadScene("EndingScreenP2Bomber");
        }
        else if (Player.name.Contains("P2Choice4"))
        {
            SceneManager.LoadScene("EndingScreenP2Sniper");
        }
        else if (Player.name.Contains("P3Choice1"))//Player 1 wins
        {
            SceneManager.LoadScene("EndingScreenP3Gunner");
        }
        else if (Player.name.Contains("P3Choice2"))
        {
            SceneManager.LoadScene("EndingScreenP3Shotgunner");
        }
        else if (Player.name.Contains("P3Choice3"))
        {
            SceneManager.LoadScene("EndingScreenP3Bomber");
        }
        else if (Player.name.Contains("P3Choice4"))
        {
            SceneManager.LoadScene("EndingScreenP3Sniper");
        }
        else if (Player.name.Contains("P4Choice1"))//Player 1 wins
        {
            SceneManager.LoadScene("EndingScreenP4Gunner");
        }
        else if (Player.name.Contains("P4Choice2"))
        {
            SceneManager.LoadScene("EndingScreenP4Shotgunner");
        }
        else if (Player.name.Contains("P4Choice3"))
        {
            SceneManager.LoadScene("EndingScreenP4Bomber");
        }
        else if (Player.name.Contains("P4Choice4"))
        {
            SceneManager.LoadScene("EndingScreenP4Sniper");
        }
    }

    void DestroyProjectiles()
    {
        GameObject[] projectiles;//create list of projectiles

        projectiles = GameObject.FindGameObjectsWithTag("User1");//grab all player 1's projectiles and store them into list

        foreach (GameObject shot in projectiles)//loop to destroy all projectiles
        {
            Destroy(shot);
        }

        projectiles = GameObject.FindGameObjectsWithTag("User2");//grab all player 2's projectiles and store them into list

        foreach (GameObject shot in projectiles)//loop to destroy all projectiles
        {
            Destroy(shot);
        }

        projectiles = GameObject.FindGameObjectsWithTag("User3");//grab all player 3's projectiles and store them into list

        foreach (GameObject shot in projectiles)//loop to destroy all projectiles
        {
            Destroy(shot);
        }

        projectiles = GameObject.FindGameObjectsWithTag("User4");//grab all player 4's projectiles and store them into list

        foreach (GameObject shot in projectiles)//loop to destroy all projectiles
        {
            Destroy(shot);
        }
    }
}
