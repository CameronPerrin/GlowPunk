using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2CharSelect : MonoBehaviour
{
    public GameObject PressAText;//initial text
    public GameObject P2Choice1Text;
    public GameObject P2Choice1Image;
    public GameObject P2Choice2Text;
    public GameObject P2Choice2Image;
    public GameObject ReadyText;
    public GameObject MC;//this is the master controller that will ultimately spawn the characters in the next scene

    private MasterController MCScript;//grabs the master controllers script so we can manipulate some of its values

    public bool Selecting, IsReady;
    private int pick;
    private int buffer, bufferTime;

    private bool isReady = false;//needed for ready up
    // Start is called before the first frame update
    void Start()
    {
        Selecting = false;
        IsReady = false;
        pick = 1;
        bufferTime = 10;//ten frames of buffer
        MCScript = MC.GetComponent<MasterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Selecting)
        {
            if (Input.GetButtonDown("A2"))//first player presses A
            {
                Selecting = true;
                PressAText.SetActive(false);
                MCScript.P2Ready = false;//selecting character therefore cannot be ready to start
                if (pick == 1)//first selection is active
                {
                    P2Choice1Text.SetActive(true);
                    P2Choice1Image.SetActive(true);
                }
                else if (pick == 2)
                {
                    P2Choice2Text.SetActive(true);
                    P2Choice2Image.SetActive(true);
                }
            }
        }
        else if (!IsReady)//Selecting Character but not ready
        {
            if (Input.GetButtonDown("A2"))//selects a character
            {
                IsReady = true;
                MCScript.P2Ready = true;//player chose a character therefore is ready to play
                P2Choice1Text.SetActive(false);
                P2Choice1Image.SetActive(false);
                P2Choice2Text.SetActive(false);
                P2Choice2Image.SetActive(false);
                //^^Set all our UI stuff false for Ready up

                ReadyText.SetActive(true);//Show that the player is ready
                MCScript.P2pick = pick;//tell master controller which character player 1 selected
                MCScript.P2Ready = true;
            }
            else if (Input.GetButtonDown("B2"))//player backs out
            {
                Selecting = false;
                MCScript.P2Ready = true;//player backed out and is not playing therefore ready up so other players can start
                P2Choice1Text.SetActive(false);
                P2Choice1Image.SetActive(false);
                P2Choice2Text.SetActive(false);
                P2Choice2Image.SetActive(false);
                //^^Set all our UI stuff false since player backed out
                PressAText.SetActive(true);
            }
            else if (Input.GetAxis("MoveJoy2X") != 0 && buffer <= 0)
            {
                if (pick == 1)
                {
                    pick = 2;
                    P2Choice1Text.SetActive(false);
                    P2Choice1Image.SetActive(false);
                    P2Choice2Text.SetActive(true);
                    P2Choice2Image.SetActive(true);
                }
                else
                {
                    pick = 1;
                    P2Choice1Text.SetActive(true);
                    P2Choice1Image.SetActive(true);
                    P2Choice2Text.SetActive(false);
                    P2Choice2Image.SetActive(false);
                }
                buffer = bufferTime;
            }
            if (buffer > 0)
            {
                buffer--;
            }
        }
        else//Player is currently readied up
        {
            if (Input.GetButtonDown("B2"))//if player decides to not play or change character
            {
                IsReady = false;
                ReadyText.SetActive(false);
                MCScript.P2pick = 0;//0 means no character is selected
                MCScript.P2Ready = false;//player is no longer ready

                if (pick == 1)//set the character selection object back up
                {
                    P2Choice1Text.SetActive(true);
                    P2Choice1Image.SetActive(true);
                }
                else if (pick == 2)
                {
                    P2Choice2Text.SetActive(true);
                    P2Choice2Image.SetActive(true);
                }
            }
        }
    }
}
