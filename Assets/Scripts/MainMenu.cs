using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public List<GameObject> Images;
    private int selected;
    private float buffer, bufferTime;

    void Start() {
        selected = 0;
        Images[0].SetActive(true);
        bufferTime = .2f;
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("MoveJoy1Y") > 0 && buffer <= 0)//user presses upward
        {
            if(selected + 1 == Images.Count)//stay in the bounds of our options
            {
                selected = 0;
            }
            else
            {
                selected++;
            }
            buffer = bufferTime;
        }
        else if(Input.GetAxis("MoveJoy1Y") < 0 && buffer <= 0)//user inputs downwards
        {
            if(selected == 0)//stay in the bounds of our options
            {
                selected = Images.Count - 1;
            }
            else
            {
                selected--;
            }
            buffer = bufferTime;
        }
        
        for(int i = 0; i < Images.Count; i++)
        {
            Images[i].SetActive(false);
        }
        Images[selected].SetActive(true);
        //^^Show the current option we are hovering^^

        if(Input.GetButtonDown("A1"))//player selects an option
        {
            if(selected == 0)//play the game
            {
                PlayGame();
            }
            else//quit out
            {
                QuitGame();
            }
        }

        if(buffer > 0)
        {
            buffer -= Time.deltaTime;
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void QuitGame()
    {

        Application.Quit();
    }
	
}
