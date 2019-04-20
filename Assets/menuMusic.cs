using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuMusic : MonoBehaviour
{
    public AudioSource source;
    //[Tooltip("0- Pistol 1- Assault")]
    public AudioClip shotSounds;
    private bool stwitch;
    // Start is called before the first frame update

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        source.clip = shotSounds;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "CharacterSelection" && SceneManager.GetActiveScene().name != "Menu")
        {
            source.Stop();
            stwitch = false;
            //Destroy(this.gameObject);
        }
        else if (stwitch == false && (SceneManager.GetActiveScene().name == "CharacterSelection" || SceneManager.GetActiveScene().name == "Menu"))
        {
            source.Play();
            stwitch = true;
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
