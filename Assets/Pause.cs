using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool Paused = false;//variable that checks if game is paused
    public int player;//keeps track of who pauses the game
    private int select;//keeps track of what button the player is hovering over
    public int options = 2;//the max amount of options on pause menu here in case we add more buttons
    public int stop;//how long before we can change button again
    private int counter;

    public GameObject ResumeButton, QuitButton;

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("P1_Pause"))
        {
            if (Paused && player == 1)
            {
                Resume();
            }
            else if(!Paused)
            {
                player = 1;//sets the player who pauses so they have control
                PauseGame();
            }
        }
        else if (Input.GetButtonDown("P2_Pause"))
        {
            if (Paused && player == 2)
            {
                Resume();
            }
            else if(!Paused)
            {
                player = 2;//sets the player who pauses so they have control
                PauseGame();
            }
        }
        else if (Input.GetButtonDown("P3_Pause"))
        {
            if (Paused && player == 3)
            {
                Resume();
            }
            else if (!Paused)
            {
                player = 3;//sets the player who pauses so they have control
                PauseGame();
            }
        }
        else if (Input.GetButtonDown("P4_Pause"))
        {
            if (Paused && player == 4)
            {
                Resume();
            }
            else if (!Paused)
            {
                player = 4;//sets the player who pauses so they have control
                PauseGame();
            }
        }

        if (Paused)
        {
            if(counter > 0)//if we are on cooldown decrement the counter
            {
                counter --;
                Debug.Log(counter);//testing
            }
            PauseControl();
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        Paused = false;
    }

    public void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        ResumeButton.SetActive(true);
        QuitButton.SetActive(false);
        select = 1;//set our default button select to 1
        Time.timeScale = 0.0f;
        Paused = true;
    }

    public void Quit()
    {
        Time.timeScale = 1.0f;
        Paused = false;
        SceneManager.LoadScene(0);
    }

    public void ButtonController()
    {
        if(select == 1)//resume is selected
        {
            ResumeButton.SetActive(true);
            QuitButton.SetActive(false);
        }
        else if(select == 2)
        {
            ResumeButton.SetActive(false);
            QuitButton.SetActive(true);
        }
    }

    public void PauseControl()
    {
        if (player == 1)//Player1
        {
            if (Input.GetButtonDown("A1"))
            {
                if (select == 1)//Resume
                {
                    Resume();
                }
                else if (select == 2)//Quit
                {
                    Quit();
                }
            }
            else if (Input.GetAxis("MoveJoy1Y") > 0 && counter <= 0)
            {
                if (select == 1)//going up on last option
                {
                    select = options;
                }
                else
                {
                    select--;
                }
                ButtonController();//need to make sure the correct button is highlighted
                counter = stop;
            }
            else if (Input.GetAxis("MoveJoy1Y") < 0 && counter <= 0)
            {
                if (select == options)//going up on last option
                {
                    select = 1;
                }
                else
                {
                    select++;
                }
                ButtonController();//need to make sure the correct button is highlighted
                counter = stop;
            }
        }
        else if (player == 2)//Player2
        {
            if (Input.GetButtonDown("A2"))
            {
                if (select == 1)//Resume
                {
                    Resume();
                }
                else if (select == 2)//Quit
                {
                    Quit();
                }
            }
            else if (Input.GetAxis("MoveJoy2Y") > 0 && counter <= 0)
            {
                if (select == 1)//going up on last option
                {
                    select = options;
                }
                else
                {
                    select--;
                }
                ButtonController();//need to make sure the correct button is highlighted
                counter = stop;
            }
            else if (Input.GetAxis("MoveJoy2Y") < 0 && counter <= 0)
            {
                if (select == options)//going up on last option
                {
                    select = 1;
                }
                else
                {
                    select++;
                }
                ButtonController();//need to make sure the correct button is highlighted
                counter = stop;
            }
        }
        else if (player == 3)//Player3
        {
            if (Input.GetButtonDown("A3"))
            {
                if (select == 1)//Resume
                {
                    Resume();
                }
                else if (select == 2)//Quit
                {
                    Quit();
                }
            }
            else if (Input.GetAxis("MoveJoy3Y") > 0 && counter <= 0)
            {
                if (select == 1)//going up on last option
                {
                    select = options;
                }
                else
                {
                    select--;
                }
                ButtonController();//need to make sure the correct button is highlighted
                counter = stop;
            }
            else if (Input.GetAxis("MoveJoy3Y") < 0 && counter <= 0)
            {
                if (select == options)//going up on last option
                {
                    select = 1;
                }
                else
                {
                    select++;
                }
                ButtonController();//need to make sure the correct button is highlighted
                counter = stop;
            }
        }
        else if (player == 4)//Player4
        {
            if (Input.GetButtonDown("A4"))
            {
                if (select == 1)//Resume
                {
                    Resume();
                }
                else if (select == 2)//Quit
                {
                    Quit();
                }
            }
            else if (Input.GetAxis("MoveJoy4Y") > 0 && counter <= 0)
            {
                if (select == 1)//going up on last option
                {
                    select = options;
                }
                else
                {
                    select--;
                }
                ButtonController();//need to make sure the correct button is highlighted
                counter = stop;
            }
            else if (Input.GetAxis("MoveJoy4Y") < 0 && counter <= 0)
            {
                if (select == options)//going up on last option
                {
                    select = 1;
                }
                else
                {
                    select++;
                }
                ButtonController();//need to make sure the correct button is highlighted
                counter = stop;
            }
        }
    }
}
