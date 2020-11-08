using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [Header("Main")]
    public Sprite icon = null; //Set in Inspector
    public ItemType itemType; //Set in Inspector
    public Quality quality;
    public string description; //Set in Inspector
    public GameObject lootDropGraphic; //Set in Inspector
    private List<Prefix> prefixes;
    private List<Suffix> suffixes;

    [Header("Requirements")]
    public int requiredLevel = 0;
    public int requiredStrength = 0;
    public int requiredMarksmanship = 0;
    public int requiredArcana = 0;

    #region StatModifiers
    [Header("Stat Mods")]
    //Stats
    public int vitality;
    public int strength;
    public int marksmanship;
    public int arcana;

    //Resistances
    public int thermalResistance;
    public int cryoResistance;
    public int shockResistance;
    public int radiationResistance;
    public int psiResistance;
    public int dimensionResistance;
    public int kineticResistance;
    public int poisonResistance;
    public int bioResistance;
    public int corruptionResistance;

    //Secondary Skills
    public int healthRegen;
    public int armour;
    public int block;
    public int armourPercent; //TODO
    public int damagePercent; //TODO
    public int movement;
    public int speed;
    public int ferocity;
    public int devastation;
    public int affliction;
    public int persistence;
    public int luck;
    public int xpGain;
    public int leechHealth;

    [Header("OnHit/Struck")]
    //Item On Hit/Struck Abilities
    public int onStruckResistance;
    public int onStruckPrecision;
    public int onStruckReflection;
    public int onStruckDefence;
    public int onStruckFeedback;
    public int onHitVulnerability;
    public int onHitSlow;
    public int onHitSnare;
    public int onHitWeaken;
    public int onHitFear;
    public int onHitIntimidate;
    public int onHitTaunt;
    public int onHitBurn;
    public int onHitBleed;
    public int onHitShock;

    [Header("Weapons Only")]
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

    [Header("Armour Only")]
    //Armour Additionals
    public int armourMin;
    public int armourMax;

    [Header("Mods Only")]
    //Hidden Skills
    public int thermalDamage;
    public int cryoDamage;
    public int shockDamage;
    public int radiationDamage;
    public int psiDamage;
    public int dimensionDamage;
    public int kineticDamage;
    public int poisonDamage;
    public int bioDamage;
    public int corruptionDamage;
    #endregion

    #region Create Item
    //AddPrefix/Suffix (maybe never need remove)
    public void AddPrefix(Prefix pFix)
    {
        prefixes.Add(pFix);
    }
    public void RemovePrefix(Prefix pFix)
    {
        prefixes.Remove(pFix);
    }
    public void AddSuffix(Suffix sFix)
    {
        suffixes.Add(sFix);
    }
    public void RemoveSuffix(Suffix sFix)
    {
        suffixes.Remove(sFix);
    }
    public string GetPrefixName()
    {
        if (prefixes.Count > 0)
        {
            return prefixes[0].name + " ";
        }
        else
        {
            return "";
        }
    }
    public string GetSuffixName()
    {
        if (suffixes.Count > 0)
        {

            if (suffixes[0].the == true)
            {
                return " of the " + suffixes[0].name;
            }
            else
            {
                return " of " + suffixes[0].name;
            }

        }
        else
        {
            return "";
        }
    }

    public void GenerateArmour()
    {
        if (armourMin > 0)
        {
            armour = Random.Range(armourMin, armourMax +1);
        }
    }

    //Add Stats from Prefix/Suffix to Item
    public void AddPreSuf()
    {
        foreach (Prefix pfix in prefixes)
        {
            int rValue = Random.Range(pfix.min, pfix.max +1);
            switch (pfix.pName)
            {
                case PrefixName.Rugged:
                    strength += rValue;
                    break;
                case PrefixName.Brawny:
                    strength += rValue;
                    break;
                case PrefixName.Strong:
                    strength += rValue;
                    break;
                case PrefixName.Mighty:
                    strength += rValue;
                    break;
                case PrefixName.Titan:
                    strength += rValue;
                    break;
                case PrefixName.Herculean:
                    strength += rValue;
                    break;
                case PrefixName.Accurate:
                    marksmanship += rValue;
                    break;
                case PrefixName.Sharpshooter:
                    marksmanship += rValue;
                    break;
                case PrefixName.Sniper:
                    marksmanship += rValue;
                    break;
                case PrefixName.Hawkeye:
                    marksmanship += rValue;
                    break;
                case PrefixName.Deadeye:
                    marksmanship += rValue;
                    break;
                case PrefixName.Assassin:
                    marksmanship += rValue;
                    break;
                case PrefixName.Mysterious:
                    arcana += rValue;
                    break;
                case PrefixName.Spirit:
                    arcana += rValue;
                    break;
                case PrefixName.Psy:
                    arcana += rValue;
                    break;
                case PrefixName.Mystic:
                    arcana += rValue;
                    break;
                case PrefixName.Mythic:
                    arcana += rValue;
                    break;
                case PrefixName.Fae:
                    arcana += rValue;
                    break;
                case PrefixName.Stout:
                    armourPercent += rValue;
                    break;
                case PrefixName.Durable:
                    armourPercent += rValue;
                    break;
                case PrefixName.Tough:
                    armourPercent += rValue;
                    break;
                case PrefixName.Stalwart:
                    armourPercent += rValue;
                    break;
                case PrefixName.Fortified:
                    armourPercent += rValue;
                    break;
                case PrefixName.Invincible:
                    armourPercent += rValue;
                    break;
                case PrefixName.Carnelian:
                    thermalResistance += rValue;
                    break;
                case PrefixName.Spinel:
                    thermalResistance += rValue;
                    break;
                case PrefixName.Russet:
                    thermalResistance += rValue;
                    break;
                case PrefixName.Jasper:
                    thermalResistance += rValue;
                    break;
                case PrefixName.Garnet:
                    thermalResistance += rValue;
                    break;
                case PrefixName.Ruby:
                    thermalResistance += rValue;
                    break;
                case PrefixName.Cryo1:
                    cryoResistance += rValue;
                    break;
                case PrefixName.Cryo2:
                    cryoResistance += rValue;
                    break;
                case PrefixName.Cryo3:
                    cryoResistance += rValue;
                    break;
                case PrefixName.Cryo4:
                    cryoResistance += rValue;
                    break;
                case PrefixName.Cryo5:
                    cryoResistance += rValue;
                    break;
                case PrefixName.Cryo6:
                    cryoResistance += rValue;
                    break;
                case PrefixName.Citrine:
                    shockResistance += rValue;
                    break;
                case PrefixName.Chrysoberyl:
                    shockResistance += rValue;
                    break;
                case PrefixName.Ocher:
                    shockResistance += rValue;
                    break;
                case PrefixName.Zircon:
                    shockResistance += rValue;
                    break;
                case PrefixName.Amber:
                    shockResistance += rValue;
                    break;
                case PrefixName.Topaz:
                    shockResistance += rValue;
                    break;
                case PrefixName.AllEle1:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    break;
                case PrefixName.AllEle2:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    break;
                case PrefixName.AllEle3:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    break;
                case PrefixName.AllEle4:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    break;
                case PrefixName.AllEle5:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    break;
                case PrefixName.AllEle6:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    break;
                case PrefixName.Peridot:
                    radiationResistance += rValue;
                    break;
                case PrefixName.Verdelite:
                    radiationResistance += rValue;
                    break;
                case PrefixName.Beryl:
                    radiationResistance += rValue;
                    break;
                case PrefixName.Viridian:
                    radiationResistance += rValue;
                    break;
                case PrefixName.Jade:
                    radiationResistance += rValue;
                    break;
                case PrefixName.Emerald:
                    radiationResistance += rValue;
                    break;
                case PrefixName.Psi1:
                    psiResistance += rValue;
                    break;
                case PrefixName.Psi2:
                    psiResistance += rValue;
                    break;
                case PrefixName.Psi3:
                    psiResistance += rValue;
                    break;
                case PrefixName.Psi4:
                    psiResistance += rValue;
                    break;
                case PrefixName.Psi5:
                    psiResistance += rValue;
                    break;
                case PrefixName.Psi6:
                    psiResistance += rValue;
                    break;
                case PrefixName.Dimension1:
                    dimensionResistance += rValue;
                    break;
                case PrefixName.Dimension2:
                    dimensionResistance += rValue;
                    break;
                case PrefixName.Dimension3:
                    dimensionResistance += rValue;
                    break;
                case PrefixName.Dimension4:
                    dimensionResistance += rValue;
                    break;
                case PrefixName.Dimension5:
                    dimensionResistance += rValue;
                    break;
                case PrefixName.Dimension6:
                    dimensionResistance += rValue;
                    break;
                case PrefixName.AllCyber1:
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    break;
                case PrefixName.AllCyber2:
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    break;
                case PrefixName.AllCyber3:
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    break;
                case PrefixName.AllCyber4:
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    break;
                case PrefixName.AllCyber5:
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    break;
                case PrefixName.AllCyber6:
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    break;
                case PrefixName.Flourite:
                    kineticResistance += rValue;
                    break;
                case PrefixName.Charoite:
                    kineticResistance += rValue;
                    break;
                case PrefixName.Sugilite:
                    kineticResistance += rValue;
                    break;
                case PrefixName.Kunzite:
                    kineticResistance += rValue;
                    break;
                case PrefixName.Iolite:
                    kineticResistance += rValue;
                    break;
                case PrefixName.Amethyst:
                    kineticResistance += rValue;
                    break;
                case PrefixName.Poison1:
                    poisonResistance += rValue;
                    break;
                case PrefixName.Poison2:
                    poisonResistance += rValue;
                    break;
                case PrefixName.Poison3:
                    poisonResistance += rValue;
                    break;
                case PrefixName.Poison4:
                    poisonResistance += rValue;
                    break;
                case PrefixName.Poison5:
                    poisonResistance += rValue;
                    break;
                case PrefixName.Poison6:
                    poisonResistance += rValue;
                    break;
                case PrefixName.Bio1:
                    bioResistance += rValue;
                    break;
                case PrefixName.Bio2:
                    bioResistance += rValue;
                    break;
                case PrefixName.Bio3:
                    bioResistance += rValue;
                    break;
                case PrefixName.Bio4:
                    bioResistance += rValue;
                    break;
                case PrefixName.Bio5:
                    bioResistance += rValue;
                    break;
                case PrefixName.Bio6:
                    bioResistance += rValue;
                    break;
                case PrefixName.AllMundane1:
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    break;
                case PrefixName.AllMundane2:
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    break;
                case PrefixName.AllMundane3:
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    break;
                case PrefixName.AllMundane4:
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    break;
                case PrefixName.AllMundane5:
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    break;
                case PrefixName.AllMundane6:
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    break;
                case PrefixName.Quartz:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    corruptionResistance += rValue;
                    break;
                case PrefixName.Coral:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    corruptionResistance += rValue;
                    break;
                case PrefixName.Moonstone:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    corruptionResistance += rValue;
                    break;
                case PrefixName.Opal:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    corruptionResistance += rValue;
                    break;
                case PrefixName.Pearl:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    corruptionResistance += rValue;
                    break;
                case PrefixName.Diamond:
                    thermalResistance += rValue;
                    cryoResistance += rValue;
                    shockResistance += rValue;
                    radiationResistance += rValue;
                    psiResistance += rValue;
                    dimensionResistance += rValue;
                    kineticResistance += rValue;
                    poisonResistance += rValue;
                    bioResistance += rValue;
                    corruptionResistance += rValue;
                    break;
                case PrefixName.Favoured:
                    luck += rValue;
                    break;
                case PrefixName.Successful:
                    luck += rValue;
                    break;
                case PrefixName.Fortunate:
                    luck += rValue;
                    break;
                case PrefixName.Wealthy:
                    luck += rValue;
                    break;
                case PrefixName.Prosperous:
                    luck += rValue;
                    break;
                case PrefixName.Lucky:
                    luck += rValue;
                    break;
                case PrefixName.Reinforced:
                    armour += rValue;
                    break;
                case PrefixName.Preserving:
                    armour += rValue;
                    break;
                case PrefixName.Shielding:
                    armour += rValue;
                    break;
                case PrefixName.Defending:
                    armour += rValue;
                    break;
                case PrefixName.Protecting:
                    armour += rValue;
                    break;
                case PrefixName.Guarding:
                    armour += rValue;
                    break;
                case PrefixName.Disrupting:
                    block += rValue;
                    break;
                case PrefixName.Obstructing:
                    block += rValue;
                    break;
                case PrefixName.Deflecting:
                    block += rValue;
                    break;
                case PrefixName.Repelling:
                    block += rValue;
                    break;
                case PrefixName.Parrying:
                    block += rValue;
                    break;
                case PrefixName.Warding:
                    block += rValue;
                    break;
                case PrefixName.Brisk:
                    speed += rValue;
                    break;
                case PrefixName.Quick:
                    speed += rValue;
                    break;
                case PrefixName.Swift:
                    speed += rValue;
                    break;
                case PrefixName.Fast:
                    speed += rValue;
                    break;
                case PrefixName.Accelerating:
                    speed += rValue;
                    break;
                case PrefixName.Rapid:
                    speed += rValue;
                    break;
                case PrefixName.Peppy:
                    damagePercent += rValue;
                    break;
                case PrefixName.Cruel:
                    damagePercent += rValue;
                    break;
                case PrefixName.Ferocious:
                    damagePercent += rValue;
                    break;
                case PrefixName.Brutal:
                    damagePercent += rValue;
                    break;
                case PrefixName.Savage:
                    damagePercent += rValue;
                    break;
                case PrefixName.Deadly:
                    damagePercent += rValue;
                    break;
            }
        }

        foreach (Suffix sfix in suffixes)
        {
            int rValue = Random.Range(sfix.min, sfix.max + 1);
            switch (sfix.sName)
            {
                case SuffixName.Vigour:
                    vitality += rValue;
                    break;
                case SuffixName.Verdure:
                    vitality += rValue;
                    break;
                case SuffixName.Robustness:
                    vitality += rValue;
                    break;
                case SuffixName.Hardiness:
                    vitality += rValue;
                    break;
                case SuffixName.Endurance:
                    vitality += rValue;
                    break;
                case SuffixName.Vitality:
                    vitality += rValue;
                    break;
                case SuffixName.Aegis:
                    armour += rValue;
                    break;
                case SuffixName.Fortified:
                    armour += rValue;
                    break;
                case SuffixName.Bulwark:
                    armour += rValue;
                    break;
                case SuffixName.Barricade:
                    armour += rValue;
                    break;
                case SuffixName.Bastion:
                    armour += rValue;
                    break;
                case SuffixName.Citadel:
                    armour += rValue;
                    break;
                case SuffixName.Briskness:
                    movement += rValue;
                    break;
                case SuffixName.Pacing:
                    movement += rValue;
                    break;
                case SuffixName.Dashing:
                    movement += rValue;
                    break;
                case SuffixName.Fleet:
                    movement += rValue;
                    break;
                case SuffixName.Swiftness:
                    movement += rValue;
                    break;
                case SuffixName.Haste:
                    movement += rValue;
                    break;
                case SuffixName.Nimble:
                    speed += rValue;
                    break;
                case SuffixName.Tenacity:
                    speed += rValue;
                    break;
                case SuffixName.Quickness:
                    speed += rValue;
                    break;
                case SuffixName.Alacrity:
                    speed += rValue;
                    break;
                case SuffixName.Celerity:
                    speed += rValue;
                    break;
                case SuffixName.Speed:
                    speed += rValue;
                    break;
                case SuffixName.Force:
                    ferocity += rValue;
                    break;
                case SuffixName.Fervor:
                    ferocity += rValue;
                    break;
                case SuffixName.Mayhem:
                    ferocity += rValue;
                    break;
                case SuffixName.Ravaging:
                    ferocity += rValue;
                    break;
                case SuffixName.Fury:
                    ferocity += rValue;
                    break;
                case SuffixName.Ferocious:
                    ferocity += rValue;
                    break;
                case SuffixName.Potence:
                    devastation += rValue;
                    break;
                case SuffixName.Ruin:
                    devastation += rValue;
                    break;
                case SuffixName.Desolation:
                    devastation += rValue;
                    break;
                case SuffixName.Power:
                    devastation += rValue;
                    break;
                case SuffixName.Murder:
                    devastation += rValue;
                    break;
                case SuffixName.Devastation:
                    devastation += rValue;
                    break;
                case SuffixName.Sorrow:
                    affliction += rValue;
                    break;
                case SuffixName.Misery:
                    affliction += rValue;
                    break;
                case SuffixName.Sickness:
                    affliction += rValue;
                    break;
                case SuffixName.Scourge:
                    affliction += rValue;
                    break;
                case SuffixName.Anguish:
                    affliction += rValue;
                    break;
                case SuffixName.Pain:
                    affliction += rValue;
                    break;
                case SuffixName.Resolution:
                    persistence += rValue;
                    break;
                case SuffixName.Perseverance:
                    persistence += rValue;
                    break;
                case SuffixName.Duration:
                    persistence += rValue;
                    break;
                case SuffixName.Constancy:
                    persistence += rValue;
                    break;
                case SuffixName.Continuum:
                    persistence += rValue;
                    break;
                case SuffixName.Persistence:
                    persistence += rValue;
                    break;
                case SuffixName.Advantage:
                    luck += rValue;
                    break;
                case SuffixName.Opportunity:
                    luck += rValue;
                    break;
                case SuffixName.Occasion:
                    luck += rValue;
                    break;
                case SuffixName.Kismet:
                    luck += rValue;
                    break;
                case SuffixName.Karma:
                    luck += rValue;
                    break;
                case SuffixName.Serendipity:
                    luck += rValue;
                    break;
                case SuffixName.Revivication:
                    healthRegen += rValue;
                    break;
                case SuffixName.Regrowth:
                    healthRegen += rValue;
                    break;
                case SuffixName.Regeneration:
                    healthRegen += rValue;
                    break;
                case SuffixName.Intensity:
                    onStruckResistance += rValue;
                    break;
                case SuffixName.Defiance:
                    onStruckResistance += rValue;
                    break;
                case SuffixName.Resistance:
                    onStruckResistance += rValue;
                    break;
                case SuffixName.Attention:
                    onStruckPrecision += rValue;
                    break;
                case SuffixName.Concentration:
                    onStruckPrecision += rValue;
                    break;
                case SuffixName.Precision:
                    onStruckPrecision += rValue;
                    break;
                case SuffixName.Rebounding:
                    onStruckReflection += rValue;
                    break;
                case SuffixName.Mirroring:
                    onStruckReflection += rValue;
                    break;
                case SuffixName.Reflection:
                    onStruckReflection += rValue;
                    break;
                case SuffixName.Sturdiness:
                    onStruckDefence += rValue;
                    break;
                case SuffixName.Stability:
                    onStruckDefence += rValue;
                    break;
                case SuffixName.Defence:
                    onStruckDefence += rValue;
                    break;
                case SuffixName.Thorns:
                    onStruckFeedback += rValue;
                    break;
                case SuffixName.Spines:
                    onStruckFeedback += rValue;
                    break;
                case SuffixName.Torment:
                    onStruckFeedback += rValue;
                    break;
                case SuffixName.Proficiency:
                    xpGain += rValue;
                    break;
                case SuffixName.Expertise:
                    xpGain += rValue;
                    break;
                case SuffixName.Mastery:
                    xpGain += rValue;
                    break;
                case SuffixName.Blistering:
                    weaponThermalDamageMin += sfix.min;
                    weaponThermalDamageMax += sfix.max;
                    break;
                case SuffixName.Smouldering:
                    weaponThermalDamageMin += sfix.min;
                    weaponThermalDamageMax += sfix.max;
                    break;
                case SuffixName.Scorching:
                    weaponThermalDamageMin += sfix.min;
                    weaponThermalDamageMax += sfix.max;
                    break;
                case SuffixName.Searing:
                    weaponThermalDamageMin += sfix.min;
                    weaponThermalDamageMax += sfix.max;
                    break;
                case SuffixName.Blazing:
                    weaponThermalDamageMin += sfix.min;
                    weaponThermalDamageMax += sfix.max;
                    break;
                case SuffixName.Flame:
                    weaponThermalDamageMin += sfix.min;
                    weaponThermalDamageMax += sfix.max;
                    break;
                case SuffixName.Cryo1:
                    weaponCryoDamageMin += sfix.min;
                    weaponCryoDamageMax += sfix.max;
                    break;
                case SuffixName.Cryo2:
                    weaponCryoDamageMin += sfix.min;
                    weaponCryoDamageMax += sfix.max;
                    break;
                case SuffixName.Cryo3:
                    weaponCryoDamageMin += sfix.min;
                    weaponCryoDamageMax += sfix.max;
                    break;
                case SuffixName.Cryo4:
                    weaponCryoDamageMin += sfix.min;
                    weaponCryoDamageMax += sfix.max;
                    break;
                case SuffixName.Cryo5:
                    weaponCryoDamageMin += sfix.min;
                    weaponCryoDamageMax += sfix.max;
                    break;
                case SuffixName.Cryo6:
                    weaponCryoDamageMin += sfix.min;
                    weaponCryoDamageMax += sfix.max;
                    break;
                case SuffixName.Glowing:
                    weaponShockDamageMin += sfix.min;
                    weaponShockDamageMax += sfix.max;
                    break;
                case SuffixName.Static:
                    weaponShockDamageMin += sfix.min;
                    weaponShockDamageMax += sfix.max;
                    break;
                case SuffixName.Arcing:
                    weaponShockDamageMin += sfix.min;
                    weaponShockDamageMax += sfix.max;
                    break;
                case SuffixName.Thunder:
                    weaponShockDamageMin += sfix.min;
                    weaponShockDamageMax += sfix.max;
                    break;
                case SuffixName.Lightning:
                    weaponShockDamageMin += sfix.min;
                    weaponShockDamageMax += sfix.max;
                    break;
                case SuffixName.Storm:
                    weaponShockDamageMin += sfix.min;
                    weaponShockDamageMax += sfix.max;
                    break;
                case SuffixName.Corrosion:
                    weaponRadDamageMin += sfix.min;
                    weaponRadDamageMax += sfix.max;
                    break;
                case SuffixName.Contaminating:
                    weaponRadDamageMin += sfix.min;
                    weaponRadDamageMax += sfix.max;
                    break;
                case SuffixName.Toxicity:
                    weaponRadDamageMin += sfix.min;
                    weaponRadDamageMax += sfix.max;
                    break;
                case SuffixName.Suffering:
                    weaponRadDamageMin += sfix.min;
                    weaponRadDamageMax += sfix.max;
                    break;
                case SuffixName.Rupturing:
                    weaponRadDamageMin += sfix.min;
                    weaponRadDamageMax += sfix.max;
                    break;
                case SuffixName.Irradiating:
                    weaponRadDamageMin += sfix.min;
                    weaponRadDamageMax += sfix.max;
                    break;
                case SuffixName.Psi1:
                    weaponPsiDamageMin += sfix.min;
                    weaponPsiDamageMax += sfix.max;
                    break;
                case SuffixName.Psi2:
                    weaponPsiDamageMin += sfix.min;
                    weaponPsiDamageMax += sfix.max;
                    break;
                case SuffixName.Psi3:
                    weaponPsiDamageMin += sfix.min;
                    weaponPsiDamageMax += sfix.max;
                    break;
                case SuffixName.Psi4:
                    weaponPsiDamageMin += sfix.min;
                    weaponPsiDamageMax += sfix.max;
                    break;
                case SuffixName.Psi5:
                    weaponPsiDamageMin += sfix.min;
                    weaponPsiDamageMax += sfix.max;
                    break;
                case SuffixName.Psi6:
                    weaponPsiDamageMin += sfix.min;
                    weaponPsiDamageMax += sfix.max;
                    break;
                case SuffixName.Dimension1:
                    weaponDimensionDamageMin += sfix.min;
                    weaponDimensionDamageMax += sfix.max;
                    break;
                case SuffixName.Dimension2:
                    weaponDimensionDamageMin += sfix.min;
                    weaponDimensionDamageMax += sfix.max;
                    break;
                case SuffixName.Dimension3:
                    weaponDimensionDamageMin += sfix.min;
                    weaponDimensionDamageMax += sfix.max;
                    break;
                case SuffixName.Dimension4:
                    weaponDimensionDamageMin += sfix.min;
                    weaponDimensionDamageMax += sfix.max;
                    break;
                case SuffixName.Dimension5:
                    weaponDimensionDamageMin += sfix.min;
                    weaponDimensionDamageMax += sfix.max;
                    break;
                case SuffixName.Dimension6:
                    weaponDimensionDamageMin += sfix.min;
                    weaponDimensionDamageMax += sfix.max;
                    break;
                case SuffixName.Clout:
                    weaponKineticDamageMin += sfix.min;
                    weaponKineticDamageMax += sfix.max;
                    break;
                case SuffixName.Mutilation:
                    weaponKineticDamageMin += sfix.min;
                    weaponKineticDamageMax += sfix.max;
                    break;
                case SuffixName.Destruction:
                    weaponKineticDamageMin += sfix.min;
                    weaponKineticDamageMax += sfix.max;
                    break;
                case SuffixName.Calamity:
                    weaponKineticDamageMin += sfix.min;
                    weaponKineticDamageMax += sfix.max;
                    break;
                case SuffixName.Havoc:
                    weaponKineticDamageMin += sfix.min;
                    weaponKineticDamageMax += sfix.max;
                    break;
                case SuffixName.Annihilation:
                    weaponKineticDamageMin += sfix.min;
                    weaponKineticDamageMax += sfix.max;
                    break;
                case SuffixName.Poison1:
                    weaponPoisonDamageMin += sfix.min;
                    weaponPoisonDamageMax += sfix.max;
                    break;
                case SuffixName.Poison2:
                    weaponPoisonDamageMin += sfix.min;
                    weaponPoisonDamageMax += sfix.max;
                    break;
                case SuffixName.Poison3:
                    weaponPoisonDamageMin += sfix.min;
                    weaponPoisonDamageMax += sfix.max;
                    break;
                case SuffixName.Poison4:
                    weaponPoisonDamageMin += sfix.min;
                    weaponPoisonDamageMax += sfix.max;
                    break;
                case SuffixName.Poison5:
                    weaponPoisonDamageMin += sfix.min;
                    weaponPoisonDamageMax += sfix.max;
                    break;
                case SuffixName.Poison6:
                    weaponPoisonDamageMin += sfix.min;
                    weaponPoisonDamageMax += sfix.max;
                    break;
                case SuffixName.Bio1:
                    weaponBioDamageMin += sfix.min;
                    weaponBioDamageMax += sfix.max;
                    break;
                case SuffixName.Bio2:
                    weaponBioDamageMin += sfix.min;
                    weaponBioDamageMax += sfix.max;
                    break;
                case SuffixName.Bio3:
                    weaponBioDamageMin += sfix.min;
                    weaponBioDamageMax += sfix.max;
                    break;
                case SuffixName.Bio4:
                    weaponBioDamageMin += sfix.min;
                    weaponBioDamageMax += sfix.max;
                    break;
                case SuffixName.Bio5:
                    weaponBioDamageMin += sfix.min;
                    weaponBioDamageMax += sfix.max;
                    break;
                case SuffixName.Bio6:
                    weaponBioDamageMin += sfix.min;
                    weaponBioDamageMax += sfix.max;
                    break;
                case SuffixName.Draining:
                    leechHealth += rValue;
                    break;
                case SuffixName.Leech:
                    leechHealth += rValue;
                    break;
                case SuffixName.Enervating:
                    leechHealth += rValue;
                    break;
                case SuffixName.Parasite:
                    leechHealth += rValue;
                    break;
                case SuffixName.Predator:
                    leechHealth += rValue;
                    break;
                case SuffixName.Vampire:
                    leechHealth += rValue;
                    break;
                case SuffixName.Exposing:
                    onHitVulnerability += rValue;
                    break;
                case SuffixName.Fragility:
                    onHitVulnerability += rValue;
                    break;
                case SuffixName.Susceptibility:
                    onHitVulnerability += rValue;
                    break;
                case SuffixName.Lag:
                    onHitSlow += rValue;
                    break;
                case SuffixName.Sluggish:
                    onHitSlow += rValue;
                    break;
                case SuffixName.Languid:
                    onHitSlow += rValue;
                    break;
                case SuffixName.Entangle:
                    onHitSnare += rValue;
                    break;
                case SuffixName.Quicksand:
                    onHitSnare += rValue;
                    break;
                case SuffixName.Quagmire:
                    onHitSnare += rValue;
                    break;
                case SuffixName.Frailty:
                    onHitWeaken += rValue;
                    break;
                case SuffixName.Feebleness:
                    onHitWeaken += rValue;
                    break;
                case SuffixName.Debilitation:
                    onHitWeaken += rValue;
                    break;
                case SuffixName.Fright:
                    onHitFear += rValue;
                    break;
                case SuffixName.Terror:
                    onHitFear += rValue;
                    break;
                case SuffixName.Horror:
                    onHitFear += rValue;
                    break;
                case SuffixName.Scowling:
                    onHitIntimidate += rValue;
                    break;
                case SuffixName.Oppressing:
                    onHitIntimidate += rValue;
                    break;
                case SuffixName.Threatening:
                    onHitIntimidate += rValue;
                    break;
                case SuffixName.Teasing:
                    onHitTaunt += rValue;
                    break;
                case SuffixName.Jeering:
                    onHitTaunt += rValue;
                    break;
                case SuffixName.Insulting:
                    onHitTaunt += rValue;
                    break;
                case SuffixName.Scalding:
                    onHitBurn += rValue;
                    break;
                case SuffixName.Heat:
                    onHitBurn += rValue;
                    break;
                case SuffixName.Burning:
                    onHitBurn += rValue;
                    break;
                case SuffixName.Cutting:
                    onHitBleed += rValue;
                    break;
                case SuffixName.Rending:
                    onHitBleed += rValue;
                    break;
                case SuffixName.Wounding:
                    onHitBleed += rValue;
                    break;
                case SuffixName.Scarring:
                    onHitShock += rValue;
                    break;
                case SuffixName.Bright:
                    onHitShock += rValue;
                    break;
                case SuffixName.Shocking:
                    onHitShock += rValue;
                    break;
                case SuffixName.Warmth:
                    thermalDamage += rValue;
                    break;
                case SuffixName.Luminosity:
                    thermalDamage += rValue;
                    break;
                case SuffixName.Incandescence:
                    thermalDamage += rValue;
                    break;
                case SuffixName.Combustion:
                    thermalDamage += rValue;
                    break;
                case SuffixName.Conflagration:
                    thermalDamage += rValue;
                    break;
                case SuffixName.Inferno:
                    thermalDamage += rValue;
                    break;
                case SuffixName.CryoDam1:
                    cryoDamage += rValue;
                    break;
                case SuffixName.CryoDam2:
                    cryoDamage += rValue;
                    break;
                case SuffixName.CryoDam3:
                    cryoDamage += rValue;
                    break;
                case SuffixName.CryoDam4:
                    cryoDamage += rValue;
                    break;
                case SuffixName.CryoDam5:
                    cryoDamage += rValue;
                    break;
                case SuffixName.CryoDam6:
                    cryoDamage += rValue;
                    break;
                case SuffixName.Sparks:
                    shockDamage += rValue;
                    break;
                case SuffixName.Light:
                    shockDamage += rValue;
                    break;
                case SuffixName.Magnetism:
                    shockDamage += rValue;
                    break;
                case SuffixName.Electrons:
                    shockDamage += rValue;
                    break;
                case SuffixName.Volts:
                    shockDamage += rValue;
                    break;
                case SuffixName.Electricity:
                    shockDamage += rValue;
                    break;
                case SuffixName.Emission:
                    radiationDamage += rValue;
                    break;
                case SuffixName.Gamma:
                    radiationDamage += rValue;
                    break;
                case SuffixName.Cosmic:
                    radiationDamage += rValue;
                    break;
                case SuffixName.Neutrons:
                    radiationDamage += rValue;
                    break;
                case SuffixName.Uranium:
                    radiationDamage += rValue;
                    break;
                case SuffixName.Thorium:
                    radiationDamage += rValue;
                    break;
                case SuffixName.Substantial:
                    radiationDamage += rValue;
                    break;
                case SuffixName.PsiDam1:
                    psiDamage += rValue;
                    break;
                case SuffixName.PsiDam2:
                    psiDamage += rValue;
                    break;
                case SuffixName.PsiDam3:
                    psiDamage += rValue;
                    break;
                case SuffixName.PsiDam4:
                    psiDamage += rValue;
                    break;
                case SuffixName.PsiDam5:
                    psiDamage += rValue;
                    break;
                case SuffixName.PsiDam6:
                    psiDamage += rValue;
                    break;
                case SuffixName.DimensionDam1:
                    dimensionDamage += rValue;
                    break;
                case SuffixName.DimensionDam2:
                    dimensionDamage += rValue;
                    break;
                case SuffixName.DimensionDam3:
                    dimensionDamage += rValue;
                    break;
                case SuffixName.DimensionDam4:
                    dimensionDamage += rValue;
                    break;
                case SuffixName.DimensionDam5:
                    dimensionDamage += rValue;
                    break;
                case SuffixName.DimensionDam6:
                    dimensionDamage += rValue;
                    break;
                case SuffixName.Corporeal:
                    kineticDamage += rValue;
                    break;
                case SuffixName.Material:
                    kineticDamage += rValue;
                    break;
                case SuffixName.Somatic:
                    kineticDamage += rValue;
                    break;
                case SuffixName.Solid:
                    kineticDamage += rValue;
                    break;
                case SuffixName.Kinetic:
                    kineticDamage += rValue;
                    break;
                case SuffixName.PoisonDam1:
                    poisonDamage += rValue;
                    break;
                case SuffixName.PoisonDam2:
                    poisonDamage += rValue;
                    break;
                case SuffixName.PoisonDam3:
                    poisonDamage += rValue;
                    break;
                case SuffixName.PoisonDam4:
                    poisonDamage += rValue;
                    break;
                case SuffixName.PoisonDam5:
                    poisonDamage += rValue;
                    break;
                case SuffixName.PoisonDam6:
                    poisonDamage += rValue;
                    break;
                case SuffixName.BioDam1:
                    bioDamage += rValue;
                    break;
                case SuffixName.BioDam2:
                    bioDamage += rValue;
                    break;
                case SuffixName.BioDam3:
                    bioDamage += rValue;
                    break;
                case SuffixName.BioDam4:
                    bioDamage += rValue;
                    break;
                case SuffixName.BioDam5:
                    bioDamage += rValue;
                    break;
                case SuffixName.BioDam6:
                    bioDamage += rValue;
                    break;
            }
        }
    }
    #endregion

    #region Equip Item

    public bool CheckRequirements(Player player)
    {

        if (player.level >= requiredLevel && 
            player.strength.GetValue() >= requiredStrength && 
            player.marksmanship.GetValue() >= requiredMarksmanship && 
            player.arcana.GetValue() >= requiredArcana)
        {
           return true;
        }
        else
        {
            return false;
        }
    }

    //Add/Remove Stats to/from Player
    public void AddStats(StatBlock player)
    {
        if (vitality > 0)
        {
            player.vitality.AddModifier(vitality);
            player.UpdateHealth();
        }
        if (armour > 0)
        {
            player.armour.AddModifier(armour);
        }
        if (block > 0)
        {
            player.block.AddModifier(block);
        }
        if (luck > 0)
        {
            player.luck.AddModifier(luck);
        }
        if (armourPercent > 0)
        {
            player.armourIncreasePercentage += armourPercent;
        }
        if (strength > 0)
        {
            player.strength.AddModifier(strength);
        }  
        if (marksmanship > 0)
        {
            player.marksmanship.AddModifier(marksmanship);
        }
        if (arcana > 0)
        {
            player.arcana.AddModifier(arcana);
        }
        if (thermalResistance > 0)
        {
            player.thermalResistance.AddModifier(thermalResistance);
        }
        if (cryoResistance > 0)
        {
            player.cryoResistance.AddModifier(cryoResistance);
        }
        if (shockResistance > 0)
        {
            player.shockResistance.AddModifier(shockResistance);
        }
        if (radiationResistance > 0)
        {
            player.radiationResistance.AddModifier(radiationResistance);
        }
        if (psiResistance > 0)
        {
            player.psiResistance.AddModifier(psiResistance);
        }
        if (dimensionResistance > 0)
        {
            player.dimensionResistance.AddModifier(dimensionResistance);
        }
        if (kineticResistance > 0)
        {
            player.kineticResistance.AddModifier(kineticResistance);
        }
        if (poisonResistance > 0)
        {
            player.poisonResistance.AddModifier(poisonResistance);
        }
        if (bioResistance > 0)
        {
            player.bioResistance.AddModifier(bioResistance);
        }
        if (corruptionResistance > 0)
        {
            player.corruptionResistance.AddModifier(corruptionResistance);
        }
        if (movement > 0)
        {
            player.movement.AddModifier(movement);
        }
        if (speed > 0)
        {
            player.speed.AddModifier(speed);
        }
        if (ferocity > 0)
        {
            player.ferocity.AddModifier(ferocity);
        }
        if (devastation > 0)
        {
            player.devastation.AddModifier(devastation);
        }
        if (affliction > 0)
        {
            player.affliction.AddModifier(affliction);
        }
        if (persistence > 0)
        {
            player.persistence.AddModifier(persistence);
        }
        if (luck > 0)
        {
            player.luck.AddModifier(luck);
        }
        if (thermalDamage > 0)
        {
            player.thermalDamage.AddModifier(thermalDamage);
        }
        if (cryoDamage > 0)
        {
            player.cryoDamage.AddModifier(cryoDamage);
        }
        if (shockDamage > 0)
        {
            player.shockDamage.AddModifier(shockDamage);
        }
        if (radiationDamage > 0)
        {
            player.radiationDamage.AddModifier(radiationDamage);
        }
        if (psiDamage > 0)
        {
            player.psiDamage.AddModifier(psiDamage);
        }
        if (dimensionDamage > 0)
        {
            player.dimensionDamage.AddModifier(dimensionDamage);
        }
        if (kineticDamage > 0)
        {
            player.kineticDamage.AddModifier(kineticDamage);
        }
        if (poisonDamage > 0)
        {
            player.poisonDamage.AddModifier(poisonDamage);
        }
        if (bioDamage > 0)
        {
            player.bioDamage.AddModifier(bioDamage);
        }
        if (corruptionDamage > 0)
        {
            player.corruptionDamage.AddModifier(corruptionDamage);
        }
        if (xpGain > 0)
        {
            player.xpModifier += xpGain;
        }
    }
    public void RemoveStats(StatBlock player)
    {
        if (vitality > 0)
        {
            player.vitality.RemoveModifier(vitality);
        }
        if (armour > 0)
        {
            player.armour.RemoveModifier(armour);
        }
        if (block > 0)
        {
            player.block.RemoveModifier(block);
        }
        if (luck > 0)
        {
            player.luck.RemoveModifier(luck);
        }
        if (armourPercent > 0)
        {
            player.armourIncreasePercentage -= armourPercent;
        }
        if (strength > 0)
        {
            player.strength.RemoveModifier(strength);
        }
        if (marksmanship > 0)
        {
            player.marksmanship.RemoveModifier(marksmanship);
        }
        if (arcana > 0)
        {
            player.arcana.RemoveModifier(arcana);
        }
        if (thermalResistance > 0)
        {
            player.thermalResistance.RemoveModifier(thermalResistance);
        }
        if (cryoResistance > 0)
        {
            player.cryoResistance.RemoveModifier(cryoResistance);
        }
        if (shockResistance > 0)
        {
            player.shockResistance.RemoveModifier(shockResistance);
        }
        if (radiationResistance > 0)
        {
            player.radiationResistance.RemoveModifier(radiationResistance);
        }
        if (psiResistance > 0)
        {
            player.psiResistance.RemoveModifier(psiResistance);
        }
        if (dimensionResistance > 0)
        {
            player.dimensionResistance.RemoveModifier(dimensionResistance);
        }
        if (kineticResistance > 0)
        {
            player.kineticResistance.RemoveModifier(kineticResistance);
        }
        if (poisonResistance > 0)
        {
            player.poisonResistance.RemoveModifier(poisonResistance);
        }
        if (bioResistance > 0)
        {
            player.bioResistance.RemoveModifier(bioResistance);
        }
        if (corruptionResistance > 0)
        {
            player.corruptionResistance.RemoveModifier(corruptionResistance);
        }
        if (movement > 0)
        {
            player.movement.RemoveModifier(movement);
        }
        if (speed > 0)
        {
            player.speed.RemoveModifier(speed);
        }
        if (ferocity > 0)
        {
            player.ferocity.RemoveModifier(ferocity);
        }
        if (devastation > 0)
        {
            player.devastation.RemoveModifier(devastation);
        }
        if (affliction > 0)
        {
            player.affliction.RemoveModifier(affliction);
        }
        if (persistence > 0)
        {
            player.persistence.RemoveModifier(persistence);
        }
        if (luck > 0)
        {
            player.luck.RemoveModifier(luck);
        }
        if (kineticDamage > 0)
        {
            player.kineticDamage.RemoveModifier(kineticDamage);
        }
        if (thermalDamage > 0)
        {
            player.thermalDamage.RemoveModifier(thermalDamage);
        }
        if (cryoDamage > 0)
        {
            player.cryoDamage.RemoveModifier(cryoDamage);
        }
        if (shockDamage > 0)
        {
            player.shockDamage.RemoveModifier(shockDamage);
        }
        if (radiationDamage > 0)
        {
            player.radiationDamage.RemoveModifier(radiationDamage);
        }
        if (psiDamage > 0)
        {
            player.psiDamage.RemoveModifier(psiDamage);
        }
        if (dimensionDamage > 0)
        {
            player.dimensionDamage.RemoveModifier(dimensionDamage);
        }
        if (kineticDamage > 0)
        {
            player.kineticDamage.RemoveModifier(kineticDamage);
        }
        if (poisonDamage > 0)
        {
            player.poisonDamage.RemoveModifier(poisonDamage);
        }
        if (bioDamage > 0)
        {
            player.bioDamage.RemoveModifier(bioDamage);
        }
        if (corruptionDamage > 0)
        {
            player.corruptionDamage.RemoveModifier(corruptionDamage);
        }
        if (xpGain > 0)
        {
            player.xpModifier -= xpGain;
        }
    }
    #endregion
}
public enum ItemType { Weapon, ItemHead, ItemChest, ItemLegs, ItemFeet, ItemHands, Cybernetic, Bionetic, Genetic, Enchantment, Skill }
public enum Quality { Common, Uncommon, Masterwork, Rare, Legendary, Unique }

