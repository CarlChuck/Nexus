using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public Handed handedness;
    public WeaponType wType;
    public GameObject mesh;
    public int damage;
    public bool melee;
    public float cooldown;

}
public enum Handed { OneHanded, TwoHanded, LeftOnly }
public enum WeaponType { Melee, Shield, HPistol, PPistol, Rifle, Carbine, Launcher, Wand, Staff, Foci, NanoGlove, GravGun }
public enum DamageType { Radiation, Shock, Physical, Fire}
