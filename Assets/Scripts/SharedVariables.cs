using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedVariables : MonoBehaviour
{
    public int totalPlayers = 0;
    public float damageMulti = 1f;
    public float damageAdd = .5f;

    void Update()
    {
        if(totalPlayers == 2)
        {
            damageMulti = 2.0f;
        }
        else if(totalPlayers == 3)
        {
            damageMulti = 1.5f;
        }
        else//four players 
        {
            damageMulti = 1.0f;
        }
    }
}


