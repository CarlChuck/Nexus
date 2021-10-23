using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Weapon")]
public class Weapon : Item
{
    [Header("Weapon")]
    public Handed handedness;
    public WeaponType wType;
    public GameObject mesh;
    //Weapon additional
    public Animator anim;
    public int weaponThermalDamageMin;
    public int weaponThermalDamageMax;
    public int weaponCryoDamageMin;
    public int weaponCryoDamageMax;
    public int weaponShockDamageMin;
    public int weaponShockDamageMax;
    public int weaponRadDamageMin;
    public int weaponRadDamageMax;
    public int weaponPsiDamageMin;
    public int weaponPsiDamageMax;
    public int weaponDimensionDamageMin;
    public int weaponDimensionDamageMax;
    public int weaponKineticDamageMin;
    public int weaponKineticDamageMax;
    public int weaponPoisonDamageMin;
    public int weaponPoisonDamageMax;
    public int weaponBioDamageMin;
    public int weaponBioDamageMax;
    public int weaponCorruptionDamageMin;
    public int weaponCorruptionDamageMax;
    public bool melee;
    public float cooldown;
    
}
public enum Handed { OneHanded, TwoHanded, LeftOnly }
public enum WeaponType { Melee, Shield, HPistol, PPistol, Rifle, Carbine, Launcher, Wand, Staff, Foci, NanoGlove, GravGun }
public enum DamageType { Radiation, Shock, Physical, Fire}
