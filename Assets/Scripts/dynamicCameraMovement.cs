using UnityEngine;
using System.Collections;

public class dynamicCameraMovement : MonoBehaviour
{
    public Transform player1, player2, player3, player4;
    public GameObject player1GM, player2GM, player3GM, player4GM;
    private SharedVariables share;
    private GameObject Access;
    public float minSizeY = 5f;
    
    void Awake()
    {
        Access = GameObject.Find("HealthVariables");
        share = Access.GetComponent<SharedVariables>();
    }
    void SetCameraPos()
    {
        Vector3 middle = new Vector3(0,0,0);
        //Debug.Log(GameObject.FindWithTag("Player1"));
        //Debug.Log(share.totalPlayers);
        if (share.totalPlayers == 2)
        {
            player1GM = GameObject.FindWithTag("Player1");
            player2GM = GameObject.FindWithTag("Player2");
            player1 = player1GM.transform;
            player2 = player2GM.transform;
            middle = (player1.position + player2.position) * 0.5f;
        }
        else if (share.totalPlayers == 3)
        {
            player1GM = GameObject.FindWithTag("Player1");
            player2GM = GameObject.FindWithTag("Player2");
            player1 = player1GM.transform;
            player2 = player2GM.transform;
            player3GM = GameObject.FindWithTag("Player3");
            player3 = player3GM.transform;
            middle = (player1.position + player2.position + player3.position) * 0.33f;
        }
        else if (share.totalPlayers == 4)
        {
            player1GM = GameObject.FindWithTag("Player1");
            player2GM = GameObject.FindWithTag("Player2");
            player1 = player1GM.transform;
            player2 = player2GM.transform;
            player3GM = GameObject.FindWithTag("Player3");
            player3 = player3GM.transform;
            player4GM = GameObject.FindWithTag("Player4");
            player4 = player4GM.transform;
            middle = (player1.position + player2.position + player3.position + player4.position) * 0.25f;
        }
  
        


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

        //multiplying by 0.5, because the ortographicSize is actually half the height
        float width = 0f;
        float height = 0f;
        if (share.totalPlayers == 2)
        {
            width = Mathf.Abs(player1.position.x - player2.position.x) * 0.5f;
            height = Mathf.Abs(player1.position.y - player2.position.y) * 0.5f + 5;
        }
        else if (share.totalPlayers == 3)
        {
            width = Mathf.Abs(player1.position.x - player2.position.x - player3.position.x) * 0.5f;
            height = Mathf.Abs(player1.position.y - player2.position.y - player3.position.x) * 0.5f + 5;
        }
        else if (share.totalPlayers == 4)
        {
            width = Mathf.Abs(player1.position.x - player2.position.x - player3.position.x - player4.position.x) * 0.5f;
            height = Mathf.Abs(player1.position.y - player2.position.y - player3.position.y - player4.position.y) * 0.5f + 5;
        }

        //computing the size
        float camSizeX = Mathf.Max(width, minSizeX) + 10;
        GetComponent<Camera>().orthographicSize = Mathf.Max(height,
            camSizeX * Screen.height / Screen.width, minSizeY);
    }

    void Update()
    {
        SetCameraPos();
        SetCameraSize();
    }
}