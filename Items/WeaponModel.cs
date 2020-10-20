using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    public GameObject weaponFlash;

    public void WeaponFlash()
    {
        if (weaponFlash != null)
        {
            weaponFlash.SetActive(true);
            StartCoroutine(WFlash(0.04f));
        }
    }

    IEnumerator WFlash(float wTime)
    {
        yield return new WaitForSeconds(wTime);
        weaponFlash.SetActive(false);
    }
}
