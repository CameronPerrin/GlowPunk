using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameMusic : MonoBehaviour
{
    public AudioSource source;
    //[Tooltip("0- Pistol 1- Assault")]
    public AudioClip shotSounds;

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
        //Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "CharacterSelection" || SceneManager.GetActiveScene().name == "Menu")
        {
            source.Stop();
            Destroy(this.gameObject);
        }
    }
}
