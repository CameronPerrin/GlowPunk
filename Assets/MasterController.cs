using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterController : MonoBehaviour
{
    public bool P1Ready, P2Ready;
    public int P1pick, P2pick;
    private int Players;//how many players are playing this game
    public Vector3 P1Spawn, P2Spawn;

    public GameObject P1Choice1, P1Choice2, P2Choice1, P2Choice2, BeginGameText;//variables to store all the prefabs
    // Start is called before the first frame update
    void Start()
    {
        P1Ready = true;//This is set to true because a player is ready when they either pick a character or havent began selecting (Currently haven't began selecting)
        P2Ready = true;
        P1pick = 0;
        P2pick = 0;
        Players = 0;

        /*
        P1Spawn.position = new Vector3(-35, 0, 0);
        P1Spawn.rotation = new Quaternion(0,0,0,0);
        P2Spawn.position = new Vector3(35, 0, 0);
        P2Spawn.rotation = new Quaternion(0, 0, 0, 0);
        */
        //^^Variable initialization^^
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name != "CharacterSelection")
        {
            Debug.Log(SceneManager.GetActiveScene().name);

            if (P1pick == 1)//player 1 picks the assualt character
            {
                Instantiate(P1Choice1, P1Spawn, Quaternion.identity);
                Debug.Log("Player 1 is Assault");
            }
            else if (P1pick == 2)//player 1 picks shotgun class
            {
                Instantiate(P1Choice2, P1Spawn, Quaternion.identity);
                Debug.Log("Player 1 is Shotgun");
            }

            if (P2pick == 1)//player 2 picks the assualt character
            {
                Instantiate(P2Choice1, P2Spawn, Quaternion.identity);
                Debug.Log("Player 2 is Assault");
            }
            else if (P2pick == 2)//player 2 picks shotgun class
            {
                Instantiate(P2Choice2, P2Spawn, Quaternion.identity);
                Debug.Log("Player 2 is Shotgun");
            }

            Destroy(this.gameObject);
        }
        if(P1Ready && P2Ready)//players are ready to play
        {
            Players = 0;
            if(P1pick > 0)//has a character selected
            {
                Players++;
            }
            if(P2pick > 0)
            {
                Players++;
            }
            if(Players > 1)
            {
                BeginGameText.SetActive(true);
                if(Input.GetButtonDown("P1_Pause"))//Start the game
                {
                    LoadScene();
                }
            }
            else
            {
                BeginGameText.SetActive(false);
            }
        }
    }

    void LoadScene()
    {
        DontDestroyOnLoad(this.gameObject);//do not destroy this game object when we go to the next scene

        SceneManager.LoadScene("SampleScene");//testing change later

        
    }
}
