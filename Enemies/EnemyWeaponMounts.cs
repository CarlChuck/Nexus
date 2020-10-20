using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponMounts : MonoBehaviour
{
    public GameObject lWeaponMount;
    public GameObject rWeaponMount;

    private GameObject equippedRWeapon;
    private GameObject equippedLWeapon;

    public Weapon rWeapon;
    public Weapon lWeapon;

    private void Start()
    {
        if (rWeapon != null)
        {
            equippedRWeapon = Instantiate(rWeapon.mesh, rWeaponMount.transform);
        }
        if (lWeapon != null)
        {
            equippedLWeapon = Instantiate(lWeapon.mesh, lWeaponMount.transform);
        }

    }

    public void FireRWeapon()
    {
        if (equippedRWeapon != null)
        {
            if (equippedRWeapon.GetComponent<WeaponModel>())
            {
                equippedRWeapon.GetComponent<WeaponModel>().WeaponFlash();
            }
        }
        if (equippedLWeapon != null)
        {
            if (equippedLWeapon.GetComponent<WeaponModel>())
            {
                equippedLWeapon.GetComponent<WeaponModel>().WeaponFlash();
            }
        }
    }
}
