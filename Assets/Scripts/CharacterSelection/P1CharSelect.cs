using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1CharSelect : MonoBehaviour
{
    public GameObject PressAText;//initial text
    public List<GameObject> P1ChoiceImage;
    public List<GameObject> P1ChoiceText;
    public GameObject ReadyText;
    public GameObject MC;//this is the master controller that will ultimately spawn the characters in the next scene

    private MasterController MCScript;//grabs the master controllers script so we can manipulate some of its values

    public bool Selecting, IsReady;
    private int pick;
    private float buffer, bufferTime;

    private bool isReady = false;//needed for ready up
    // Start is called before the first frame update
    void Start()
    {
        Selecting = false;
        IsReady = false;
        pick = 0;
        bufferTime = 1;//1 second of buffer
        MCScript = MC.GetComponent<MasterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!Selecting)
        {
            if(Input.GetButtonDown("A1"))//first player presses A
            {
                Selecting = true;
                PressAText.SetActive(false);
                MCScript.P1Ready = false;//selecting character therefore cannot be ready to start

                P1ChoiceImage[pick].SetActive(true);
                P1ChoiceText[pick].SetActive(true);
            }
        }
        else if(!IsReady)//Selecting Character but not ready
        {
            if(Input.GetButtonDown("A1"))//selects a character
            {
                IsReady = true;
                MCScript.P1Ready = true;//player chose a character therefore is ready to play

                for (int i = 0; i < P1ChoiceImage.Count; i++)//set character selections as false
                {
                    P1ChoiceImage[i].SetActive(false);
                    P1ChoiceText[i].SetActive(false);
                }
                //^^Set all our UI stuff false for Ready up

                ReadyText.SetActive(true);//Show that the player is ready
                MCScript.P1pick = pick;//tell master controller which character player 1 selected
                MCScript.P1Ready = true;
            }
            else if(Input.GetButtonDown("B1"))//player backs out
            {
                Selecting = false;
                MCScript.P1Ready = true;//player backed out and is not playing therefore ready up so other players can start
                for(int i = 0; i < P1ChoiceImage.Count; i++)//set character selections as false
                {
                    P1ChoiceImage[i].SetActive(false);
                    P1ChoiceText[i].SetActive(false);
                }
                //^^Set all our UI stuff false since player backed out
                PressAText.SetActive(true);
            }
            else if(Input.GetAxis("MoveJoy1X") != 0 && buffer <= 0)
            {
                for (int i = 0; i < P1ChoiceImage.Count; i++)//set character selections as false
                {
                    P1ChoiceImage[i].SetActive(false);
                    P1ChoiceText[i].SetActive(false);
                }

                if (Input.GetAxis("MoveJoy1X") < 0)//input is left
                {
                    if(pick == 0)//loop to end of array
                    {
                        pick = P1ChoiceImage.Count - 1;//set to the end of the array
                    }
                    else
                    {
                        pick--;
                    }
                }
                else//input is right
                {
                    if(pick == P1ChoiceImage.Count - 1)//at the end of the array loop back to beginning 
                    {
                        pick = 0;
                    }
                    else
                    {
                        pick++;
                    }
                }
                P1ChoiceImage[pick].SetActive(true);
                P1ChoiceText[pick].SetActive(true);

                buffer = bufferTime;
            }
            if(buffer > 0)
            {
                buffer -= Time.deltaTime;
            }
        }
        else//Player is currently readied up
        {
            if(Input.GetButtonDown("B1"))//if player decides to not play or change character
            {
                IsReady = false;
                ReadyText.SetActive(false);
                MCScript.P1pick = -1;//-1 means no character is selected
                MCScript.P1Ready = false;//player is no longer ready

                P1ChoiceImage[pick].SetActive(true);
                P1ChoiceText[pick].SetActive(true);
            }
        }
    }
}
