using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public List<TextMeshProUGUI> align;
    private int selected;
    public int small, big;
    private float buffer, bufferTime;
    public TMP_ColorGradient on, off;

    void Start() {
        selected = 0;
        align[0].alignment = TMPro.TextAlignmentOptions.Right;//show the first button as selected
        for(int i = 1; i < align.Count; i++)//loop that will ensure that all other option are not selected
        {
            align[i].alignment = TMPro.TextAlignmentOptions.Left;
            align[i].colorGradientPreset = off;
            align[i].fontSize = small;
        }
        bufferTime = .2f;
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("MoveJoy1Y") > 0 && buffer <= 0)//user presses upward
        {
            if(selected + 1 == align.Count)//stay in the bounds of our options
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
                selected = align.Count - 1;
            }
            else
            {
                selected--;
            }
            buffer = bufferTime;
        }
        
        for(int i = 0; i < align.Count; i++)
        {
            align[i].alignment = TMPro.TextAlignmentOptions.Left;
            align[i].colorGradientPreset = off;
            align[i].fontSize = small;
        }
        align[selected].alignment = TMPro.TextAlignmentOptions.Right;
        align[selected].colorGradientPreset = on;
        align[selected].fontSize = big;
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
