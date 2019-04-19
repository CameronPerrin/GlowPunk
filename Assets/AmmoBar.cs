using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage_2;
    private float updateSpeedSeconds = 0.1f;

    private void Awake()
    {
        bool rdy = GetComponentInParent<SpecialWeapon>().isReady;
    }

    private void HandleAmmoChange(float pct)
    {
       // StartCoroutine(ChangeToPct(pct));
    }

    private void FixedUpdate()
    {
        float preChangePct = foregroundImage_2.fillAmount;
        float elapsed = 0f;
        float temp;

        
            if (GetComponentInParent<SpecialWeapon>().isReady)
                foregroundImage_2.fillAmount = 1;
            else
            {
                temp = GetComponentInParent<SpecialWeapon>().regeneration / GetComponentInParent<SpecialWeapon>().regenTime;
            foregroundImage_2.fillAmount = Mathf.Lerp(temp, foregroundImage_2.fillAmount, elapsed / updateSpeedSeconds);
                //yield return null;
            }
            
        
        /*
        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage_2.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }
        

        foregroundImage_2.fillAmount = pct;
        */
    }
}
