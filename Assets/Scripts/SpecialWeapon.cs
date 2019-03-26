using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{
    public int bullets, magSize;
    public float regenTime;
    public float regeneration;
    // Start is called before the first frame update
    void Start()
    {
        bullets = magSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bullets < magSize)//if we do not have max ammo regenerate ammo
        {
            regeneration += Time.deltaTime;
            if (regeneration > regenTime)//time to regenerate some ammo
            {
                bullets++;
                regeneration -= regenTime;
            }
        }
        else//if we are not setting the regenerating ammo set the regen to 0 so we start regeneration correctly
        {
            regeneration = 0;
        }
    }
}
