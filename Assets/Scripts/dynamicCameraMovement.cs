using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class dynamicCameraMovement : MonoBehaviour
{
    public Transform player1, player2, player3, player4;
    public GameObject player1GM, player2GM, player3GM, player4GM;
    public List<GameObject> playerGM;
    private SharedVariables share;
    private GameObject Access;
    public float minSizeY = 20f;
    
    void Awake()
    {
        Access = GameObject.Find("HealthVariables");
        share = Access.GetComponent<SharedVariables>();
    }
    void SetCameraPos()
    {
        Vector3 middle = new Vector3(0, 0, 0);
        //Debug.Log(GameObject.FindWithTag("Player1"));
        //Debug.Log(share.totalPlayers);
        /*
        if (share.totalPlayers == 2)
        {
            if (GameObject.FindWithTag("Player1"))
                player1GM = GameObject.FindWithTag("Player1");
            else if (GameObject.FindWithTag("Player2"))
                player1GM = GameObject.FindWithTag("Player2");
            else if (GameObject.FindWithTag("Player3"))
                player1GM = GameObject.FindWithTag("Player3");
            else if (GameObject.FindWithTag("Player4"))
                player1GM = GameObject.FindWithTag("Player4");
            if (GameObject.FindWithTag("Player2"))
                player2GM = GameObject.FindWithTag("Player2");
            else if (GameObject.FindWithTag("Player3"))
                player2GM = GameObject.FindWithTag("Player3");
            else if (GameObject.FindWithTag("Player4"))
                player2GM = GameObject.FindWithTag("Player4");
            player1 = player1GM.transform;
            player2 = player2GM.transform;
            middle = (player1.position + player2.position) * 0.5f;
        }
        else if (share.totalPlayers == 3)
        {
            if (GameObject.FindWithTag("Player1"))
                player1GM = GameObject.FindWithTag("Player1");
            else if (GameObject.FindWithTag("Player2"))
                player1GM = GameObject.FindWithTag("Player2");
            else if (GameObject.FindWithTag("Player3"))
                player1GM = GameObject.FindWithTag("Player3");
            else if (GameObject.FindWithTag("Player4"))
                player1GM = GameObject.FindWithTag("Player4");
            if (GameObject.FindWithTag("Player2"))
                player2GM = GameObject.FindWithTag("Player2");
            else if (GameObject.FindWithTag("Player3"))
                player2GM = GameObject.FindWithTag("Player3");
            else if (GameObject.FindWithTag("Player4"))
                player2GM = GameObject.FindWithTag("Player4");
            if (GameObject.FindWithTag("Player3"))
                player3GM = GameObject.FindWithTag("Player3");
            else if (GameObject.FindWithTag("Player4"))
                player3GM = GameObject.FindWithTag("Player4");
            player1 = player1GM.transform;
            player2 = player2GM.transform;
            player3 = player3GM.transform;
            middle = (player1.position + player2.position + player3.position) * 0.33f;
        }
        else if (share.totalPlayers == 4)
        {
            player1GM = GameObject.FindWithTag("Player1");
            player2GM = GameObject.FindWithTag("Player2");
            player3GM = GameObject.FindWithTag("Player3");
            player4GM = GameObject.FindWithTag("Player4");
            player1 = player1GM.transform;
            player2 = player2GM.transform;
            player3 = player3GM.transform;
            player4 = player4GM.transform;
            middle = (player1.position + player2.position + player3.position + player4.position) * 0.25f;
        }*/

        

        for(int i = 0; i < playerGM.Count; i++)
        {
            middle += playerGM[i].transform.position;
        }

        middle /= playerGM.Count;
        Debug.Log(middle);
        GetComponent<Camera>().transform.position = new Vector3(
            middle.x,
            middle.y,
            GetComponent<Camera>().transform.position.z
        );
    }

    void SetCameraSize()
    {
        //horizontal size is based on actual screen ratio
        float minSizeX = minSizeY * Screen.width / Screen.height;
        float lowestX = 0;
        float highestX = 0;
        float lowestY = 0;
        float highestY = 0;
        //multiplying by 0.5, because the ortographicSize is actually half the height
        float width = 0f;
        float height = 0f;
        /*
        if (share.totalPlayers == 2)
        {
            width = Mathf.Abs(player1.position.x - player2.position.x) * 0.5f;
            height = Mathf.Abs(player1.position.y - player2.position.y) * 0.5f + 5;
        }
        else if (share.totalPlayers == 3)
        {
            if (player1.position.x < lowestX)
                lowestX = player1.position.x;
            else if (player2.position.x < lowestX)
                lowestX = player2.position.x;
            else if (player3.position.x < lowestX)
                lowestX = player3.position.x;

            if (player1.position.x > highestX)
                highestX = player1.position.x;
            else if (player2.position.x > highestX)
                highestX = player2.position.x;
            else if (player3.position.x > highestX)
                highestX = player3.position.x;

            if (player1.position.y < lowestY)
                lowestY = player1.position.y;
            else if (player2.position.y < lowestY)
                lowestY = player2.position.y;
            else if (player3.position.y < lowestY)
                lowestY = player3.position.y;

            if (player1.position.y > highestY)
                highestY = player1.position.y;
            else if (player2.position.y > highestY)
                highestY = player2.position.y;
            else if (player3.position.y > highestY)
                highestY = player3.position.y;
            width = Mathf.Abs(lowestX - highestX) * 0.5f;
            height = Mathf.Abs(lowestY - highestY) * 0.5f + 5;
        }
        else if (share.totalPlayers == 4)
        {
            if (player1.position.x < lowestX)
                lowestX = player1.position.x;
            else if (player2.position.x < lowestX)
                lowestX = player2.position.x;
            else if (player3.position.x < lowestX)
                lowestX = player3.position.x;
            else if (player4.position.x < lowestX)
                lowestX = player4.position.x;

            if (player1.position.x > highestX)
                highestX = player1.position.x;
            else if (player2.position.x > highestX)
                highestX = player2.position.x;
            else if (player3.position.x > highestX)
                highestX = player3.position.x;
            else if (player4.position.x > highestX)
                highestX = player4.position.x;

            if (player1.position.y < lowestY)
                lowestY = player1.position.y;
            else if (player2.position.y < lowestY)
                lowestY = player2.position.y;
            else if (player3.position.y < lowestY)
                lowestY = player3.position.y;
            else if (player4.position.y < lowestY)
                lowestY = player4.position.y;

            if (player1.position.y > highestY)
                highestY = player1.position.y;
            else if (player2.position.y > highestY)
                highestY = player2.position.y;
            else if (player3.position.y > highestY)
                highestY = player3.position.y;
            else if (player4.position.y > highestY)
                highestY = player4.position.y;
            width = Mathf.Abs(lowestX - highestX) * 0.5f;
            height = Mathf.Abs(lowestY - highestY) * 0.5f + 5;
        }
        */
        lowestX = playerGM[0].transform.position.x;
        highestX = playerGM[0].transform.position.x;
        lowestY = playerGM[0].transform.position.y;
        highestY = playerGM[0].transform.position.y;
        //^^Variable intitialization^^
        for(int i = 1; i < playerGM.Count; i++)
        {
            if (lowestX > playerGM[i].transform.position.x)
                lowestX = playerGM[i].transform.position.x;
            if (highestX < playerGM[i].transform.position.x)
                highestX = playerGM[i].transform.position.x;
            if (lowestY > playerGM[i].transform.position.y)
                lowestY = playerGM[i].transform.position.y;
            if (highestY > playerGM[i].transform.position.y)
                highestY = playerGM[i].transform.position.y;
        }

        width = Mathf.Abs(lowestX - highestX) * 0.6f;
        height = Mathf.Abs(lowestY - highestY) * 0.5f + 5;
        //computing the size
        float camSizeX = Mathf.Max(width, minSizeX) + 10;
        GetComponent<Camera>().orthographicSize = Mathf.Max(height,
            camSizeX * Screen.height / Screen.width, minSizeY);
    }

    void Update()
    {
        playerGM.Clear();
        if (GameObject.FindWithTag("Player1"))
            playerGM.Add(GameObject.FindWithTag("Player1"));
        if (GameObject.FindWithTag("Player2"))
            playerGM.Add(GameObject.FindWithTag("Player2"));
        if (GameObject.FindWithTag("Player3"))
            playerGM.Add(GameObject.FindWithTag("Player3"));
        if (GameObject.FindWithTag("Player4"))
            playerGM.Add(GameObject.FindWithTag("Player4"));
        SetCameraPos();
        SetCameraSize();
    }
}