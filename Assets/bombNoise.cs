using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombNoise : MonoBehaviour
{
    public AudioSource source;
    //[Tooltip("0- Pistol 1- Assault")]
    public AudioClip shotSounds;

    // Start is called before the first frame update
    void Start()
    {
        source.clip = shotSounds;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
