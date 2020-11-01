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
    public int finalThermalMin;
    public int finalThermalMax;
    public int finalCryoMin;
    public int finalCryoMax;
    public int finalShockMin;
    public int finalShockMax;
    public int finalRadMin;
    public int finalRadMax;
    public int finalPsiMin;
    public int finalPsiMax;
    public int finalDimensionMin;
    public int finalDimensionMax;
    public int finalKineticMin;
    public int finalKineticMax;
    public int finalPoisonMin;
    public int finalPoisonMax;
    public int finalBioMin;
    public int finalBioMax;
    public int finalCorruptionMin;
    public int finalCorruptionMax;
    public int totalDamageMin;
    public int totalDamageMax;
    public bool melee;
    public float cooldown;

    public void InitialiseWeapon()
    {
        finalThermalMin = thermalMin + ((thermalMin / 100) * damagePercent) + weaponThermalDamageMin;
        finalThermalMax = thermalMax + ((thermalMax / 100) * damagePercent) + weaponThermalDamageMax;
        finalCryoMin = cryoMin + ((cryoMin / 100) * damagePercent) + weaponCryoDamageMin;
        finalCryoMax = cryoMax + ((cryoMax / 100) * damagePercent) + weaponCryoDamageMax;
        finalShockMin = shockMin + ((shockMin / 100) * damagePercent) + weaponShockDamageMin;
        finalShockMax = shockMax + ((shockMax / 100) * damagePercent) + weaponShockDamageMax;
        finalRadMin = radMin + ((radMin / 100) * damagePercent) + weaponRadDamageMin;
        finalRadMax = radMax + ((radMax / 100) * damagePercent) + weaponRadDamageMin;
        finalPsiMin = psiMin + ((psiMin / 100) * damagePercent) + weaponPsiDamageMin;
        finalPsiMax = psiMax + ((psiMax / 100) * damagePercent) + weaponPsiDamageMax;
        finalDimensionMin = dimensionMin + ((dimensionMin / 100) * damagePercent) + weaponDimensionDamageMin;
        finalDimensionMax = dimensionMax + ((dimensionMax / 100) * damagePercent) + weaponDimensionDamageMax;
        finalKineticMin = kineticMin + ((kineticMin / 100) * damagePercent) + weaponKineticDamageMin;
        finalKineticMax = kineticMax + ((kineticMax / 100) * damagePercent) + weaponKineticDamageMax;
        finalPoisonMin = poisonMin + ((poisonMin / 100) * damagePercent) + weaponPoisonDamageMin;
        finalPoisonMax = poisonMax + ((poisonMax / 100) * damagePercent) + weaponPoisonDamageMax;
        finalBioMin = bioMin + ((bioMin / 100) * damagePercent) + weaponBioDamageMin;
        finalBioMax = bioMax + ((bioMax / 100) * damagePercent) + weaponBioDamageMax;
        finalCorruptionMin = corruptionMin + ((corruptionMin / 100) * damagePercent) + weaponCorruptionDamageMin;
        finalCorruptionMax = corruptionMin + ((corruptionMin / 100) * damagePercent) + weaponCorruptionDamageMin;
        totalDamageMin = 0;//ALL
        totalDamageMax = 0;
    }
}
public enum Handed { OneHanded, TwoHanded, LeftOnly }
public enum WeaponType { Melee, Shield, HPistol, PPistol, Rifle, Carbine, Launcher, Wand, Staff, Foci, NanoGlove, GravGun }
public enum DamageType { Radiation, Shock, Physical, Fire}
