using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{
    public float regenTime;
    public float regeneration;
    public bool isReady;
    // Start is called before the first frame update
    void Start()
    {
        isReady = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isReady)//if we are on cooldown
        {
            regeneration += Time.deltaTime;
            if (regeneration >= regenTime)//time to regenerate some ammo
            {
                isReady = true;
                regeneration = 0;
            }
        }
        else//if our ability is ready
        {
            regeneration = 0;
        }
    }
}
