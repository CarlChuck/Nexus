using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public Handed handedness;
    public WeaponType wType;
    public GameObject mesh;
    public int fireDamageMin;
    public int fireDamageMax;
    public int ShockDamageMin;
    public int ShockDamageMax;
    public int RadDamageMin;
    public int RadDamageMax;
    public int PhysDamageMin;
    public int PhysDamageMax;
    public int finalFireDamageMin;
    public int finalFireDamageMax;
    public int finalShockDamageMin;
    public int finalShockDamageMax;
    public int finalRadDamageMin;
    public int finalRadDamageMax;
    public int finalPhysDamageMin;
    public int finalPhysDamageMax;
    public int totalDamageMin;
    public int totalDamageMax;
    public bool melee;
    public float cooldown;

    public void InitialiseWeapon()
    {
        finalFireDamageMin = fireDamageMin + ((fireDamageMin / 100) * damagePercent) + weaponFireDamageMin;
        finalFireDamageMax = fireDamageMax + ((fireDamageMax / 100) * damagePercent) + weaponFireDamageMax;
        finalShockDamageMin = ShockDamageMin + ((ShockDamageMin / 100) * damagePercent) + weaponShockDamageMin;
        finalShockDamageMax = ShockDamageMax + ((ShockDamageMax / 100) * damagePercent) + weaponShockDamageMax;
        finalRadDamageMin = RadDamageMin + ((RadDamageMin / 100) * damagePercent) + weaponRadDamageMin;
        finalRadDamageMax = RadDamageMax + ((RadDamageMax / 100) * damagePercent) + weaponRadDamageMax;
        finalPhysDamageMin = PhysDamageMin + ((PhysDamageMin / 100) * damagePercent) + weaponPhysDamageMin;
        finalPhysDamageMax = PhysDamageMax + ((PhysDamageMax / 100) * damagePercent) + weaponPhysDamageMax;
        totalDamageMin = finalFireDamageMin + finalShockDamageMin + finalRadDamageMin + finalPhysDamageMin;
        totalDamageMax = finalFireDamageMax + finalShockDamageMax + finalRadDamageMax + finalPhysDamageMax;
    }
}
public enum Handed { OneHanded, TwoHanded, LeftOnly }
public enum WeaponType { Melee, Shield, HPistol, PPistol, Rifle, Carbine, Launcher, Wand, Staff, Foci, NanoGlove, GravGun }
public enum DamageType { Radiation, Shock, Physical, Fire}
