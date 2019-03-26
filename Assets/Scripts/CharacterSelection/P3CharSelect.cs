using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3CharSelect : MonoBehaviour
{
    public GameObject PressAText;//initial text
    public List<GameObject> P3ChoiceImage;
    public List<GameObject> P3ChoiceText;
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
        bufferTime = .2f;//one second of buffer
        MCScript = MC.GetComponent<MasterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Selecting)
        {
            if (Input.GetButtonDown("A3"))//first player presses A
            {
                Selecting = true;
                PressAText.SetActive(false);
                MCScript.P3Ready = false;//selecting character therefore cannot be ready to start

                P3ChoiceImage[pick].SetActive(true);
                P3ChoiceText[pick].SetActive(true);
            }
        }
        else if (!IsReady)//Selecting Character but not ready
        {
            if (Input.GetButtonDown("A3"))//selects a character
            {
                IsReady = true;
                MCScript.P3Ready = true;//player chose a character therefore is ready to play

                for (int i = 0; i < P3ChoiceImage.Count; i++)//set character selections as false
                {
                    P3ChoiceImage[i].SetActive(false);
                    P3ChoiceText[i].SetActive(false);
                }
                //^^Set all our UI stuff false for Ready up

                ReadyText.SetActive(true);//Show that the player is ready
                MCScript.P3pick = pick;//tell master controller which character player 2 selected
                MCScript.P3Ready = true;
            }
            else if (Input.GetButtonDown("B3"))//player backs out
            {
                Selecting = false;
                MCScript.P3Ready = true;//player backed out and is not playing therefore ready up so other players can start
                for (int i = 0; i < P3ChoiceImage.Count; i++)//set character selections as false
                {
                    P3ChoiceImage[i].SetActive(false);
                    P3ChoiceText[i].SetActive(false);
                }
                //^^Set all our UI stuff false since player backed out
                PressAText.SetActive(true);
            }
            else if (Input.GetAxis("MoveJoy3X") != 0 && buffer <= 0)
            {
                for (int i = 0; i < P3ChoiceImage.Count; i++)//set character selections as false
                {
                    P3ChoiceImage[i].SetActive(false);
                    P3ChoiceText[i].SetActive(false);
                }

                if (Input.GetAxis("MoveJoy3X") < 0)//input is left
                {
                    if (pick == 0)//loop to end of array
                    {
                        pick = P3ChoiceImage.Count - 1;//set to the end of the array
                    }
                    else
                    {
                        pick--;
                    }
                }
                else//input is right
                {
                    if (pick == P3ChoiceImage.Count - 1)//at the end of the array loop back to beginning 
                    {
                        pick = 0;
                    }
                    else
                    {
                        pick++;
                    }
                }
                P3ChoiceImage[pick].SetActive(true);
                P3ChoiceText[pick].SetActive(true);

                buffer = bufferTime;
            }
            if (buffer > 0)
            {
                buffer -= Time.deltaTime;
            }
        }
        else//Player is currently readied up
        {
            if (Input.GetButtonDown("B3"))//if player decides to not play or change character
            {
                IsReady = false;
                ReadyText.SetActive(false);
                MCScript.P3pick = -1;//-1 means no character is selected
                MCScript.P3Ready = false;//player is no longer ready

                P3ChoiceImage[pick].SetActive(true);
                P3ChoiceText[pick].SetActive(true);
            }
        }
    }
}
