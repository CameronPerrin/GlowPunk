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
    public float smoothSpeed = .125f;
    public float sizeChange = .4f;
    private float previousSize;
    
    void Awake()
    {
        Access = GameObject.Find("HealthVariables");
        share = Access.GetComponent<SharedVariables>();
    }
    void SetCameraPos()
    {
        Vector3 middle = new Vector3(0, 0, 0);
        
        for(int i = 0; i < playerGM.Count; i++)
        {
            middle += playerGM[i].transform.position;
        }

        middle /= playerGM.Count;
        //Debug.Log(middle);
        Vector3 targetPos = new Vector3(
            middle.x,
            middle.y,
            GetComponent<Camera>().transform.position.z
        );
        Vector3 smoothedPos = Vector3.Lerp(GetComponent<Camera>().transform.position, targetPos, smoothSpeed);
        GetComponent<Camera>().transform.position = smoothedPos;
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
            if (highestY < playerGM[i].transform.position.y)
                highestY = playerGM[i].transform.position.y;
        }

        width = Mathf.Abs(lowestX - highestX) * 0.6f;
        height = Mathf.Abs(lowestY - highestY) * 0.5f + 5;
        //computing the size
        float camSizeX = Mathf.Max(width, minSizeX) + 10;
        float desiredSize = Mathf.Max(height,
            camSizeX * Screen.height / Screen.width, minSizeY);

        if(Mathf.Abs(GetComponent<Camera>().orthographicSize - desiredSize) > sizeChange)//if we are changing the camera size to drastically stop
        {
            if(Mathf.Sign(GetComponent<Camera>().orthographicSize - desiredSize) > 0)//size decrease
            {
                GetComponent<Camera>().orthographicSize -= sizeChange;
            }
            else//camera size increase
            {
                GetComponent<Camera>().orthographicSize += sizeChange;
            }
        }
        else//not changing the size to drastically so just set size normally
        {
            GetComponent<Camera>().orthographicSize = desiredSize;
        }
    }

    void FixedUpdate()
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