using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Weapon")]
public class Weapon : Item
{
    [Header("Weapon")]
    public Handed handedness;
    public WeaponType wType;
    public GameObject mesh;
    public int thermalMin;
    public int thermalMax;
    public int cryoMin;
    public int cryoMax;
    public int shockMin;
    public int shockMax;
    public int radMin;
    public int radMax;
    public int psiMin;
    public int psiMax;
    public int dimensionMin;
    public int dimensionMax;
    public int kineticMin;
    public int kineticMax;
    public int poisonMin;
    public int poisonMax;
    public int bioMin;
    public int bioMax;
    public int corruptionMin;
    public int corruptionMax;
    public bool melee;
    public float cooldown;
    
}
public enum Handed { OneHanded, TwoHanded, LeftOnly }
public enum WeaponType { Melee, Shield, HPistol, PPistol, Rifle, Carbine, Launcher, Wand, Staff, Foci, NanoGlove, GravGun }
public enum DamageType { Radiation, Shock, Physical, Fire}
