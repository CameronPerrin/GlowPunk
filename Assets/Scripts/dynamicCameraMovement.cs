using UnityEngine;
using System.Collections;

public class dynamicCameraMovement : MonoBehaviour
{
    public Transform player1, player2;
    public GameObject player1GM, player2GM;

    public float minSizeY = 5f;

    void SetCameraPos()
    {
        //Debug.Log(GameObject.FindWithTag("Player1"));
        player1GM = GameObject.FindWithTag("Player1");
        player2GM = GameObject.FindWithTag("Player2");
        player1 = player1GM.transform;
        player2 = player2GM.transform;
        Vector3 middle = (player1.position + player2.position) * 0.5f;


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
        float width = Mathf.Abs(player1.position.x - player2.position.x) * 0.5f;
        float height = Mathf.Abs(player1.position.y - player2.position.y) * 0.5f + 5;

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