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

    #region StatModifiers
    [Header("Stat Mods")]
    //Stats
    public int vitality;
    public int strength;
    public int marksmanship;
    public int arcana;

    //Defence Skills
    public int fireResistance;
    public int shockResistance;
    public int radResistance;
    public int physicalResistance;

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
    public int physDamage;
    public int fireDamage;
    public int shockDamage;
    public int radDamage;
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
                    fireResistance += rValue;
                    break;
                case PrefixName.Spinel:
                    fireResistance += rValue;
                    break;
                case PrefixName.Russet:
                    fireResistance += rValue;
                    break;
                case PrefixName.Jasper:
                    fireResistance += rValue;
                    break;
                case PrefixName.Garnet:
                    fireResistance += rValue;
                    break;
                case PrefixName.Ruby:
                    fireResistance += rValue;
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
                case PrefixName.Peridot:
                    radResistance += rValue;
                    break;
                case PrefixName.Verdelite:
                    radResistance += rValue;
                    break;
                case PrefixName.Beryl:
                    radResistance += rValue;
                    break;
                case PrefixName.Viridian:
                    radResistance += rValue;
                    break;
                case PrefixName.Jade:
                    radResistance += rValue;
                    break;
                case PrefixName.Emerald:
                    radResistance += rValue;
                    break;
                case PrefixName.Flourite:
                    physicalResistance += rValue;
                    break;
                case PrefixName.Charoite:
                    physicalResistance += rValue;
                    break;
                case PrefixName.Sugilite:
                    physicalResistance += rValue;
                    break;
                case PrefixName.Kunzite:
                    physicalResistance += rValue;
                    break;
                case PrefixName.Iolite:
                    physicalResistance += rValue;
                    break;
                case PrefixName.Amethyst:
                    physicalResistance += rValue;
                    break;
                case PrefixName.Quartz:
                    fireResistance += rValue;
                    shockResistance += rValue;
                    radResistance += rValue;
                    physicalResistance += rValue;
                    break;
                case PrefixName.Coral:
                    fireResistance += rValue;
                    shockResistance += rValue;
                    radResistance += rValue;
                    physicalResistance += rValue;
                    break;
                case PrefixName.Moonstone:
                    fireResistance += rValue;
                    shockResistance += rValue;
                    radResistance += rValue;
                    physicalResistance += rValue;
                    break;
                case PrefixName.Opal:
                    fireResistance += rValue;
                    shockResistance += rValue;
                    radResistance += rValue;
                    physicalResistance += rValue;
                    break;
                case PrefixName.Pearl:
                    fireResistance += rValue;
                    shockResistance += rValue;
                    radResistance += rValue;
                    physicalResistance += rValue;
                    break;
                case PrefixName.Diamond:
                    fireResistance += rValue;
                    shockResistance += rValue;
                    radResistance += rValue;
                    physicalResistance += rValue;
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
                    weaponFireDamageMin += sfix.min;
                    weaponFireDamageMax += sfix.max;
                    break;
                case SuffixName.Smouldering:
                    weaponFireDamageMin += sfix.min;
                    weaponFireDamageMax += sfix.max;
                    break;
                case SuffixName.Scorching:
                    weaponFireDamageMin += sfix.min;
                    weaponFireDamageMax += sfix.max;
                    break;
                case SuffixName.Searing:
                    weaponFireDamageMin += sfix.min;
                    weaponFireDamageMax += sfix.max;
                    break;
                case SuffixName.Blazing:
                    weaponFireDamageMin += sfix.min;
                    weaponFireDamageMax += sfix.max;
                    break;
                case SuffixName.Flame:
                    weaponFireDamageMin += sfix.min;
                    weaponFireDamageMax += sfix.max;
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
                case SuffixName.Clout:
                    weaponPhysDamageMin += sfix.min;
                    weaponPhysDamageMax += sfix.max;
                    break;
                case SuffixName.Mutilation:
                    weaponPhysDamageMin += sfix.min;
                    weaponPhysDamageMax += sfix.max;
                    break;
                case SuffixName.Destruction:
                    weaponPhysDamageMin += sfix.min;
                    weaponPhysDamageMax += sfix.max;
                    break;
                case SuffixName.Calamity:
                    weaponPhysDamageMin += sfix.min;
                    weaponPhysDamageMax += sfix.max;
                    break;
                case SuffixName.Havoc:
                    weaponPhysDamageMin += sfix.min;
                    weaponPhysDamageMax += sfix.max;
                    break;
                case SuffixName.Annihilation:
                    weaponPhysDamageMin += sfix.min;
                    weaponPhysDamageMax += sfix.max;
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
                    fireDamage += rValue;
                    break;
                case SuffixName.Luminosity:
                    fireDamage += rValue;
                    break;
                case SuffixName.Incandescence:
                    fireDamage += rValue;
                    break;
                case SuffixName.Combustion:
                    fireDamage += rValue;
                    break;
                case SuffixName.Conflagration:
                    fireDamage += rValue;
                    break;
                case SuffixName.Inferno:
                    fireDamage += rValue;
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
                    radDamage += rValue;
                    break;
                case SuffixName.Gamma:
                    radDamage += rValue;
                    break;
                case SuffixName.Cosmic:
                    radDamage += rValue;
                    break;
                case SuffixName.Neutrons:
                    radDamage += rValue;
                    break;
                case SuffixName.Uranium:
                    radDamage += rValue;
                    break;
                case SuffixName.Thorium:
                    radDamage += rValue;
                    break;
                case SuffixName.Substantial:
                    physDamage += rValue;
                    break;
                case SuffixName.Corporeal:
                    physDamage += rValue;
                    break;
                case SuffixName.Material:
                    physDamage += rValue;
                    break;
                case SuffixName.Somatic:
                    physDamage += rValue;
                    break;
                case SuffixName.Solid:
                    physDamage += rValue;
                    break;
                case SuffixName.Kinetic:
                    physDamage += rValue;
                    break;
            }
        }
    }
    #endregion

    #region Equip Item
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
        if (fireResistance > 0)
        {
            player.fireResistance.AddModifier(fireResistance);
        }
        if (shockResistance > 0)
        {
            player.shockResistance.AddModifier(shockResistance);
        }
        if (radResistance > 0)
        {
            player.radResistance.AddModifier(radResistance);
        }
        if (physicalResistance > 0)
        {
            player.physicalResistance.AddModifier(physicalResistance);
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
        if (physDamage > 0)
        {
            player.physDamage.AddModifier(physDamage);
        }
        if (fireDamage > 0)
        {
            player.fireDamage.AddModifier(fireDamage);
        }
        if (shockDamage > 0)
        {
            player.shockDamage.AddModifier(shockDamage);
        }
        if (radDamage > 0)
        {
            player.radDamage.AddModifier(radDamage);
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
        if (fireResistance > 0)
        {
            player.fireResistance.RemoveModifier(fireResistance);
        }
        if (shockResistance > 0)
        {
            player.shockResistance.RemoveModifier(shockResistance);
        }
        if (radResistance > 0)
        {
            player.radResistance.RemoveModifier(radResistance);
        }
        if (physicalResistance > 0)
        {
            player.physicalResistance.RemoveModifier(physicalResistance);
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
        if (physDamage > 0)
        {
            player.physDamage.RemoveModifier(physDamage);
        }
        if (fireDamage > 0)
        {
            player.fireDamage.RemoveModifier(fireDamage);
        }
        if (shockDamage > 0)
        {
            player.shockDamage.RemoveModifier(shockDamage);
        }
        if (radDamage > 0)
        {
            player.radDamage.RemoveModifier(radDamage);
        }
        if (xpGain > 0)
        {
            player.xpModifier -= xpGain;
        }
    }

    #endregion
}
public enum ItemType { Weapon, ItemHead, ItemChest, ItemLegs, ItemFeet, ItemHands, ModDex, ModStr, ModSta, ModHeal, Skill }
public enum Quality { Common, Uncommon, Masterwork, Rare, Legendary, Unique }

