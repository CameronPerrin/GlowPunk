using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterController : MonoBehaviour
{
    public bool P1Ready, P2Ready, P3Ready, P4Ready;
    public int P1pick, P2pick, P3pick, P4pick;
    private int Players;//how many players are playing this game
    public Vector3 P1Spawn, P2Spawn, P3Spawn, P4Spawn;

    public GameObject BeginGameText;

    public List<GameObject> P1Choice, P2Choice, P3Choice, P4Choice;//lists to store all the prefabs

    // Start is called before the first frame update
    void Start()
    {
        P1Ready = true;//This is set to true because a player is ready when they either pick a character or havent began selecting (Currently haven't began selecting)
        P2Ready = true;
        P3Ready = true;
        P4Ready = true;

        P1pick = -1;
        P2pick = -1;
        P3pick = -1;
        P4pick = -1;

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

            if (P1pick >= 0 && P1pick < P1Choice.Count)//player 1 picks the assualt character
            {
                Instantiate(P1Choice[P1pick], P1Spawn, Quaternion.identity);
            }

            if (P2pick >= 0 && P2pick < P2Choice.Count)//player 1 picks the assualt character
            {
                Instantiate(P2Choice[P2pick], P2Spawn, Quaternion.identity);
            }

            if (P3pick >= 0 && P3pick < P3Choice.Count)//player 1 picks the assualt character
            {
                Instantiate(P3Choice[P3pick], P3Spawn, Quaternion.identity);
            }

            if (P4pick >= 0 && P4pick < P4Choice.Count)//player 1 picks the assualt character
            {
                Instantiate(P4Choice[P4pick], P4Spawn, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
        else if(P1Ready && P2Ready && P3Ready && P4Ready)//players are ready to play
        {
            Players = 0;
            if (P1pick >= 0 && P1pick < P1Choice.Count)//player 1 picks the assualt character
            {
                Players++;
            }

            if (P2pick >= 0 && P2pick < P2Choice.Count)//player 1 picks the assualt character
            {
                Players++;
            }

            if (P3pick >= 0 && P3pick < P3Choice.Count)//player 1 picks the assualt character
            {
                Players++;
            }

            if (P4pick >= 0 && P4pick < P4Choice.Count)//player 1 picks the assualt character
            {
                Players++;
            }

            if (Players > 1)//need at least 2 players to start the game
            {
                BeginGameText.SetActive(true);
                if(Input.GetButtonDown("P1_Pause") || Input.GetButtonDown("P2_Pause") || Input.GetButtonDown("P3_Pause") || Input.GetButtonDown("P4_Pause"))//Start the game
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
