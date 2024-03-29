using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [Header("Main")]
    public Item baseItem;
    public GameObject icon3d = null;
    public ItemType itemType;
    public Quality quality;
    public string description;
    public List<Prefix> prefixes;
    public List<Suffix> suffixes;

    public GameObject lootDropGraphic;

    [Header("Requirements")]
    public int requiredLevel = 0;
    public int requiredStrength = 0;
    public int requiredMarksmanship = 0;
    public int requiredArcana = 0;

    #region Stats
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
    public int movement;
    public int speed;
    public int ferocity;
    public int devastation;
    public int affliction;
    public int persistence;

    //Tertiary Skills
    public int healthRegen;
    public int luck;
    public int xpGain;
    public int leechHealth;
    public int feedback;

    #endregion

    #region Armour/ShieldStats
    [Header("ARMOUR/SHIELD")]
    //Armour Additionals
    public int armour;
    public int armourPercent; //TODO

    public int onStruckResistance;
    public int onStruckPrecision;
    public int onStruckReflection;
    public int onStruckDefence;
    public int onStruckFeedback;
    public int onHitVulnerability;

    [Header("SHIELD")]
    public int block;

    #endregion

    #region SkillStats

    [Header("Skills")]
    public CharClass classRequired;
    public float skillCooldown;
    public int damage;
    public int boonDuration;
    public int hexDuration;

    #region EleSkills
    [Header("Elementalist Skills")]
    public EleSkill eleSkill;
    public EleEliteSkill eleEliteSkill;
    #endregion


    #endregion

    #region WeaponStats
    [Header("WEAPON")]

    public Handed handedness;
    public WeaponType wType;
    public GameObject mesh;
    public List<CharClass> cClasses;

    //Starting damage from weapon
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

    //Damage mods from prefix/suffix
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

    //Final damage calculated by type
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

    //Total damage for purposes of displaying on UI
    public int totalDamageMin;
    public int totalDamageMax;

    public int damagePercent; //TODO

    public bool melee;
    public float weaponCooldown;

    //OnHits
    public int onHitSlow;
    public int onHitSnare;
    public int onHitWeaken;
    public int onHitFear;
    public int onHitIntimidate;
    public int onHitTaunt;
    public int onHitBurn;
    public int onHitBleed;
    public int onHitShock;
    #endregion

    #region ModStats
    [Header("MODS")]
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

    [Header("GENETIC")]
    [SerializeField] private GeneticType gType;
    public int geneticAmount;

    [Header("ENCHANTMENTS")]
    [SerializeField] private EnchantmentType eType;
    public int enchantmentAmount;

    [Header("CYBERNETIC")]
    [SerializeField] private CyberneticType cType;
    public int cyberDuration = 0;
    public float cyberCooldown = 0;

    [Header("BIONETIC")]
    [SerializeField] private BioneticEffect bEffect;
    public int bioDuration = 0;
    public int bioAmount = 0; //percentage of health healed, or percent of damage converted to health
    public float bioCooldown = 5f;
    #endregion

    [Header("Value")]
    public int value;

    public void BuildInventoryItem(Item item, Quality qual)
    {
        name = item.name;
        baseItem = item;
        itemType = item.itemType;
        if (item.icon3d != null)
        {
            icon3d = item.icon3d;
        }
        quality = qual;
        description = item.description;
        lootDropGraphic = item.lootDropGraphic;
        if (item is Weapon)
        {
            Weapon weap = item as Weapon;
            melee = weap.melee;
            weaponCooldown = weap.cooldown;
        }
        AddPreSuf();
        AddWeaponItemStats();
        InitialiseWeapon();
        AddModStats();
        GenerateArmour();
        if (quality != Quality.Common)
        {
            name = GenerateName();
        }
        //Calculate Value
    }

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
    public void GenerateArmour()
    {
        if (itemType == ItemType.ItemChest || itemType == ItemType.ItemFeet || itemType == ItemType.ItemHands || itemType == ItemType.ItemHead || itemType == ItemType.ItemLegs)
        {
            if (baseItem.armourMin > 0)
            {
                armour = (Random.Range(baseItem.armourMin, baseItem.armourMax + 1) * ((armourPercent + 100)/100));
            }
        }
        if (itemType == ItemType.Cybernetic && cType == CyberneticType.Armour)
        {
            if (baseItem.armourMin > 0)
            {
                armour = (Random.Range(baseItem.armourMin, baseItem.armourMax + 1) * ((armourPercent + 100) / 100));
            }
        }
        if (itemType == ItemType.Weapon && wType == WeaponType.Shield)
        {
            if (baseItem.armourMin > 0)
            {
                armour = (Random.Range(baseItem.armourMin, baseItem.armourMax + 1) * ((armourPercent + 100) / 100));
            }
        }
    }
    public void AddModStats()
    {
        thermalDamage = baseItem.thermalDamage;
        cryoDamage = baseItem.cryoDamage;
        shockDamage = baseItem.shockDamage;
        radiationDamage = baseItem.radiationDamage;
        psiDamage = baseItem.psiDamage;
        dimensionDamage = baseItem.dimensionDamage;
        kineticDamage = baseItem.kineticDamage;
        poisonDamage = baseItem.poisonDamage;
        bioDamage = baseItem.bioDamage;
        corruptionDamage = baseItem.corruptionDamage;

        if (baseItem is GeneticMod)
        {
            GeneticMod gMod = baseItem as GeneticMod;
            gType = gMod.gType;
            geneticAmount = gMod.amount;
        }
        if (baseItem is BioneticMod)
        {
            BioneticMod bMod = baseItem as BioneticMod;
            bEffect = bMod.bEffect;
            bioDuration = bMod.duration;
            bioAmount = bMod.amount;
            bioCooldown = bMod.cooldown;
        }
        if (baseItem is EnchantmentMod)
        {
            EnchantmentMod eMod = baseItem as EnchantmentMod;
            eType = eMod.eType;
            enchantmentAmount = eMod.amount;
        }
        if (baseItem is CyberneticMod)
        {
            CyberneticMod cMod = baseItem as CyberneticMod;
            cType = cMod.cType;
            cyberDuration = cMod.duration;
            cyberCooldown = cMod.cooldown;
        }

    }

    #region NameGeneration
    private string GenerateName()
    {
        if (quality == Quality.Uncommon || quality == Quality.Masterwork)
        {
            return GenerateMagicalName();
        }
        else if (quality == Quality.Rare || quality == Quality.Legendary)
        {
            return GenerateRareName();
        }
        else
        {
            return name;
        }
    }
    private string GetPrefixName()
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
    private string GetSuffixName()
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
    private string GenerateRareName()
    {
        RarePrefixPart1 rand1 = (RarePrefixPart1)Random.Range(0, (int)RarePrefixPart1.Max);
        RarePrefixPart2 rand2 = (RarePrefixPart2)Random.Range(0, (int)RarePrefixPart2.Max);
        string rarePrefix1 = rand1.ToString();
        string rarePrefix2 = rand2.ToString();
        string rareName = rarePrefix1 + " " + rarePrefix2 + " " + name;
        return rareName;
    }
    private string GenerateMagicalName()
    {
        string prefix = GetPrefixName();
        string suffix = GetSuffixName();
        string magicName = prefix + name + suffix;
        return magicName;
    }
    #endregion

    //Add Stats from Prefix/Suffix to Item
    //TODO maybe need to finish this off
    public void AddPreSuf()
    {
        if (prefixes != null) 
        {

            foreach (Prefix pfix in prefixes)
            {
                int rValue = Random.Range(pfix.min, pfix.max + 1);
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
                    case PrefixName.Ventilated:
                        thermalResistance += rValue;
                        break;
                    case PrefixName.Ablative:
                        thermalResistance += rValue;
                        break;
                    case PrefixName.Cooling:
                        thermalResistance += rValue;
                        break;
                    case PrefixName.Beryllium:
                        thermalResistance += rValue;
                        break;
                    case PrefixName.Emissive:
                        thermalResistance += rValue;
                        break;
                    case PrefixName.Thermic:
                        thermalResistance += rValue;
                        break;
                    case PrefixName.Warm:
                        cryoResistance += rValue;
                        break;
                    case PrefixName.Thawing:
                        cryoResistance += rValue;
                        break;
                    case PrefixName.Polymer:
                        cryoResistance += rValue;
                        break;
                    case PrefixName.Nitro:
                        cryoResistance += rValue;
                        break;
                    case PrefixName.Heated:
                        cryoResistance += rValue;
                        break;
                    case PrefixName.Insulated:
                        cryoResistance += rValue;
                        break;
                    case PrefixName.AntiStatic:
                        shockResistance += rValue;
                        break;
                    case PrefixName.Magnetic:
                        shockResistance += rValue;
                        break;
                    case PrefixName.Rubber:
                        shockResistance += rValue;
                        break;
                    case PrefixName.Silicone:
                        shockResistance += rValue;
                        break;
                    case PrefixName.Dissipative:
                        shockResistance += rValue;
                        break;
                    case PrefixName.Grounding:
                        shockResistance += rValue;
                        break;
                    case PrefixName.Stable:
                        thermalResistance += rValue;
                        cryoResistance += rValue;
                        shockResistance += rValue;
                        break;
                    case PrefixName.Temperate:
                        thermalResistance += rValue;
                        cryoResistance += rValue;
                        shockResistance += rValue;
                        break;
                    case PrefixName.Constant:
                        thermalResistance += rValue;
                        cryoResistance += rValue;
                        shockResistance += rValue;
                        break;
                    case PrefixName.Primordial:
                        thermalResistance += rValue;
                        cryoResistance += rValue;
                        shockResistance += rValue;
                        break;
                    case PrefixName.Primal:
                        thermalResistance += rValue;
                        cryoResistance += rValue;
                        shockResistance += rValue;
                        break;
                    case PrefixName.Elemental:
                        thermalResistance += rValue;
                        cryoResistance += rValue;
                        shockResistance += rValue;
                        break;
                    case PrefixName.Hazmat:
                        radiationResistance += rValue;
                        break;
                    case PrefixName.Lead:
                        radiationResistance += rValue;
                        break;
                    case PrefixName.Carbide:
                        radiationResistance += rValue;
                        break;
                    case PrefixName.Ion:
                        radiationResistance += rValue;
                        break;
                    case PrefixName.Boron:
                        radiationResistance += rValue;
                        break;
                    case PrefixName.Radium:
                        radiationResistance += rValue;
                        break;
                    case PrefixName.Neuron:
                        psiResistance += rValue;
                        break;
                    case PrefixName.Axon:
                        psiResistance += rValue;
                        break;
                    case PrefixName.Synaptic:
                        psiResistance += rValue;
                        break;
                    case PrefixName.Telekinetic:
                        psiResistance += rValue;
                        break;
                    case PrefixName.Psychokinetic:
                        psiResistance += rValue;
                        break;
                    case PrefixName.Psionic:
                        psiResistance += rValue;
                        break;
                    case PrefixName.Spatial:
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Manifold:
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Tesseract:
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Quantum:
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Euclidean:
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Absolute:
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Tech:
                        radiationResistance += rValue;
                        psiResistance += rValue;
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Synthetic:
                        radiationResistance += rValue;
                        psiResistance += rValue;
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Fabricated:
                        radiationResistance += rValue;
                        psiResistance += rValue;
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Graviton:
                        radiationResistance += rValue;
                        psiResistance += rValue;
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Synthwave:
                        radiationResistance += rValue;
                        psiResistance += rValue;
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Holographic:
                        radiationResistance += rValue;
                        psiResistance += rValue;
                        dimensionResistance += rValue;
                        break;
                    case PrefixName.Sturdy:
                        kineticResistance += rValue;
                        break;
                    case PrefixName.Compact:
                        kineticResistance += rValue;
                        break;
                    case PrefixName.Rock:
                        kineticResistance += rValue;
                        break;
                    case PrefixName.Steel:
                        kineticResistance += rValue;
                        break;
                    case PrefixName.Dense:
                        kineticResistance += rValue;
                        break;
                    case PrefixName.Solid:
                        kineticResistance += rValue;
                        break;
                    case PrefixName.Neutralising:
                        poisonResistance += rValue;
                        break;
                    case PrefixName.Vaccine:
                        poisonResistance += rValue;
                        break;
                    case PrefixName.Antibody:
                        poisonResistance += rValue;
                        break;
                    case PrefixName.Mithridatism:
                        poisonResistance += rValue;
                        break;
                    case PrefixName.Immune:
                        poisonResistance += rValue;
                        break;
                    case PrefixName.Antidote:
                        poisonResistance += rValue;
                        break;
                    case PrefixName.Alkaline:
                        bioResistance += rValue;
                        break;
                    case PrefixName.Sodium:
                        bioResistance += rValue;
                        break;
                    case PrefixName.Acerbic:
                        bioResistance += rValue;
                        break;
                    case PrefixName.Antibiotic:
                        bioResistance += rValue;
                        break;
                    case PrefixName.Antigen:
                        bioResistance += rValue;
                        break;
                    case PrefixName.Genetic:
                        bioResistance += rValue;
                        break;
                    case PrefixName.Counteractive:
                        kineticResistance += rValue;
                        poisonResistance += rValue;
                        bioResistance += rValue;
                        break;
                    case PrefixName.Obstructive:
                        kineticResistance += rValue;
                        poisonResistance += rValue;
                        bioResistance += rValue;
                        break;
                    case PrefixName.Aversive:
                        kineticResistance += rValue;
                        poisonResistance += rValue;
                        bioResistance += rValue;
                        break;
                    case PrefixName.Hindering:
                        kineticResistance += rValue;
                        poisonResistance += rValue;
                        bioResistance += rValue;
                        break;
                    case PrefixName.Defiant:
                        kineticResistance += rValue;
                        poisonResistance += rValue;
                        bioResistance += rValue;
                        break;
                    case PrefixName.Resiliant:
                        kineticResistance += rValue;
                        poisonResistance += rValue;
                        bioResistance += rValue;
                        break;
                    case PrefixName.Declining:
                        corruptionResistance += rValue;
                        break;
                    case PrefixName.Decaying:
                        corruptionResistance += rValue;
                        break;
                    case PrefixName.Degenerating:
                        corruptionResistance += rValue;
                        break;
                    case PrefixName.Ataxic:
                        corruptionResistance += rValue;
                        break;
                    case PrefixName.Entropic:
                        corruptionResistance += rValue;
                        break;
                    case PrefixName.Tide:
                        corruptionResistance += rValue;
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
                    case PrefixName.Amethyst:
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
                    case PrefixName.Sapphire:
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
                    case PrefixName.Emerald:
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
                    case PrefixName.Ruby:
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
        }

        if (suffixes != null)
        {
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
                    case SuffixName.Chill:
                        weaponCryoDamageMin += sfix.min;
                        weaponCryoDamageMax += sfix.max;
                        break;
                    case SuffixName.Cold:
                        weaponCryoDamageMin += sfix.min;
                        weaponCryoDamageMax += sfix.max;
                        break;
                    case SuffixName.Frost:
                        weaponCryoDamageMin += sfix.min;
                        weaponCryoDamageMax += sfix.max;
                        break;
                    case SuffixName.Ice:
                        weaponCryoDamageMin += sfix.min;
                        weaponCryoDamageMax += sfix.max;
                        break;
                    case SuffixName.Rime:
                        weaponCryoDamageMin += sfix.min;
                        weaponCryoDamageMax += sfix.max;
                        break;
                    case SuffixName.Glacier:
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
                    case SuffixName.Contamination:
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
                    case SuffixName.Agitation:
                        weaponPsiDamageMin += sfix.min;
                        weaponPsiDamageMax += sfix.max;
                        break;
                    case SuffixName.Ejection:
                        weaponPsiDamageMin += sfix.min;
                        weaponPsiDamageMax += sfix.max;
                        break;
                    case SuffixName.Suspension:
                        weaponPsiDamageMin += sfix.min;
                        weaponPsiDamageMax += sfix.max;
                        break;
                    case SuffixName.Phobia:
                        weaponPsiDamageMin += sfix.min;
                        weaponPsiDamageMax += sfix.max;
                        break;
                    case SuffixName.Manipulation:
                        weaponPsiDamageMin += sfix.min;
                        weaponPsiDamageMax += sfix.max;
                        break;
                    case SuffixName.Projection:
                        weaponPsiDamageMin += sfix.min;
                        weaponPsiDamageMax += sfix.max;
                        break;
                    case SuffixName.Astral:
                        weaponDimensionDamageMin += sfix.min;
                        weaponDimensionDamageMax += sfix.max;
                        break;
                    case SuffixName.Veil:
                        weaponDimensionDamageMin += sfix.min;
                        weaponDimensionDamageMax += sfix.max;
                        break;
                    case SuffixName.Planes:
                        weaponDimensionDamageMin += sfix.min;
                        weaponDimensionDamageMax += sfix.max;
                        break;
                    case SuffixName.Ectoplasm:
                        weaponDimensionDamageMin += sfix.min;
                        weaponDimensionDamageMax += sfix.max;
                        break;
                    case SuffixName.Banishment:
                        weaponDimensionDamageMin += sfix.min;
                        weaponDimensionDamageMax += sfix.max;
                        break;
                    case SuffixName.Displacement:
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
                    case SuffixName.Affliction:
                        weaponPoisonDamageMin += sfix.min;
                        weaponPoisonDamageMax += sfix.max;
                        break;
                    case SuffixName.Contagion:
                        weaponPoisonDamageMin += sfix.min;
                        weaponPoisonDamageMax += sfix.max;
                        break;
                    case SuffixName.Virulence:
                        weaponPoisonDamageMin += sfix.min;
                        weaponPoisonDamageMax += sfix.max;
                        break;
                    case SuffixName.Toxins:
                        weaponPoisonDamageMin += sfix.min;
                        weaponPoisonDamageMax += sfix.max;
                        break;
                    case SuffixName.Blight:
                        weaponPoisonDamageMin += sfix.min;
                        weaponPoisonDamageMax += sfix.max;
                        break;
                    case SuffixName.Venom:
                        weaponPoisonDamageMin += sfix.min;
                        weaponPoisonDamageMax += sfix.max;
                        break;
                    case SuffixName.Virus:
                        weaponBioDamageMin += sfix.min;
                        weaponBioDamageMax += sfix.max;
                        break;
                    case SuffixName.Bacteria:
                        weaponBioDamageMin += sfix.min;
                        weaponBioDamageMax += sfix.max;
                        break;
                    case SuffixName.Miasma:
                        weaponBioDamageMin += sfix.min;
                        weaponBioDamageMax += sfix.max;
                        break;
                    case SuffixName.Disease:
                        weaponBioDamageMin += sfix.min;
                        weaponBioDamageMax += sfix.max;
                        break;
                    case SuffixName.Epidemic:
                        weaponBioDamageMin += sfix.min;
                        weaponBioDamageMax += sfix.max;
                        break;
                    case SuffixName.Plague:
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
                    case SuffixName.Entanglement:
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
                    case SuffixName.Thermal:
                        thermalDamage += rValue;
                        break;
                    case SuffixName.Cryogenics:
                        cryoDamage += rValue;
                        break;
                    case SuffixName.Shock:
                        shockDamage += rValue;
                        break;
                    case SuffixName.Radiation:
                        radiationDamage += rValue;
                        break;
                    case SuffixName.Psy:
                        psiDamage += rValue;
                        break;
                    case SuffixName.Dimensions:
                        dimensionDamage += rValue;
                        break;
                    case SuffixName.Kinetic:
                        kineticDamage += rValue;
                        break;
                    case SuffixName.Poison:
                        poisonDamage += rValue;
                        break;
                    case SuffixName.Biogenics:
                        bioDamage += rValue;
                        break;
                }
            }
        }
    }

    private void AddWeaponItemStats()
    {
        if (baseItem is Weapon)
        {
            Weapon weap = baseItem as Weapon;
            wType = weap.wType;
            mesh = weap.mesh;
            weaponThermalDamageMin = weap.weaponThermalDamageMin;
            weaponThermalDamageMax = weap.weaponThermalDamageMax;
            weaponCryoDamageMin = weap.weaponCryoDamageMin;
            weaponCryoDamageMax = weap.weaponCryoDamageMax;
            weaponShockDamageMin = weap.weaponShockDamageMin;
            weaponShockDamageMax = weap.weaponShockDamageMax;
            weaponRadDamageMin = weap.weaponRadDamageMin;
            weaponRadDamageMax = weap.weaponRadDamageMax;
            weaponPsiDamageMin = weap.weaponPsiDamageMin;
            weaponPsiDamageMax = weap.weaponPsiDamageMax;
            weaponDimensionDamageMin = weap.weaponDimensionDamageMin;
            weaponDimensionDamageMax = weap.weaponDimensionDamageMax;
            weaponKineticDamageMin = weap.weaponKineticDamageMin;
            weaponKineticDamageMax = weap.weaponKineticDamageMax;
            weaponPoisonDamageMin = weap.weaponPoisonDamageMin;
            weaponPoisonDamageMax = weap.weaponPoisonDamageMax;
            weaponBioDamageMin = weap.weaponBioDamageMin;
            weaponBioDamageMax = weap.weaponBioDamageMax;
            weaponCorruptionDamageMin = weap.weaponCorruptionDamageMin;
            weaponCorruptionDamageMax = weap.weaponCorruptionDamageMax;
        }
    }

    public void InitialiseWeapon()
    {
        if (itemType == ItemType.Weapon)
        {
            finalThermalMin = thermalMin + ((thermalMin / 100) * damagePercent) + weaponThermalDamageMin;
            finalThermalMax = thermalMax + ((thermalMax / 100) * damagePercent) + weaponThermalDamageMax;
            finalCryoMin = cryoMin + ((cryoMin / 100) * damagePercent) + weaponCryoDamageMin;
            finalCryoMax = cryoMax + ((cryoMax / 100) * damagePercent) + weaponCryoDamageMax;
            finalShockMin = shockMin + ((shockMin / 100) * damagePercent) + weaponShockDamageMin;
            finalShockMax = shockMax + ((shockMax / 100) * damagePercent) + weaponShockDamageMax;
            finalRadMin = radMin + ((radMin / 100) * damagePercent) + weaponRadDamageMin;
            finalRadMax = radMax + ((radMax / 100) * damagePercent) + weaponRadDamageMax;
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
            finalCorruptionMax = corruptionMax + ((corruptionMax / 100) * damagePercent) + weaponCorruptionDamageMax;
            totalDamageMin = finalThermalMin + finalCryoMin + finalShockMin + finalRadMin + finalPsiMin + finalDimensionMin + finalKineticMin + finalPoisonMin + finalBioMin + finalCorruptionMin;
            totalDamageMax = finalThermalMax + finalCryoMax + finalShockMax + finalRadMax + finalPsiMax + finalDimensionMax + finalKineticMax + finalPoisonMax + finalBioMax + finalCorruptionMax;
            SetWeaponClasses();
        }       
    }

    private void SetWeaponClasses()
    {
        cClasses = new List<CharClass>();
        switch (wType)
        {
            case WeaponType.Carbine:
                cClasses.Add(CharClass.Golemancer);
                cClasses.Add(CharClass.Apoch);
                cClasses.Add(CharClass.Vigil);
                cClasses.Add(CharClass.StreetDoctor);
                break;
            case WeaponType.Foci:
                cClasses.Add(CharClass.Golemancer);
                cClasses.Add(CharClass.Elementalist);
                cClasses.Add(CharClass.Psyc);
                cClasses.Add(CharClass.Mystic);
                break;
            case WeaponType.GravGun:
                cClasses.Add(CharClass.Artificer);
                cClasses.Add(CharClass.Apoch);
                cClasses.Add(CharClass.Crypter);
                cClasses.Add(CharClass.NanoMage);
                break;
            case WeaponType.HPistol:
                cClasses.Add(CharClass.Elementalist);
                cClasses.Add(CharClass.Mystic);
                cClasses.Add(CharClass.Artificer);
                cClasses.Add(CharClass.NanoMage);
                cClasses.Add(CharClass.Guardian);
                cClasses.Add(CharClass.Vigil);
                cClasses.Add(CharClass.Shadow);
                cClasses.Add(CharClass.StreetDoctor);
                break;
            case WeaponType.Launcher:
                cClasses.Add(CharClass.Artificer);
                cClasses.Add(CharClass.Guardian);
                cClasses.Add(CharClass.Vigil);
                cClasses.Add(CharClass.StreetDoctor);
                break;
            case WeaponType.Melee:
                cClasses.Add(CharClass.Mystic);
                cClasses.Add(CharClass.Apoch);
                cClasses.Add(CharClass.Crypter);
                cClasses.Add(CharClass.Guardian);
                cClasses.Add(CharClass.Shadow);
                cClasses.Add(CharClass.StreetDoctor);
                break;
            case WeaponType.NanoGlove:
                cClasses.Add(CharClass.Artificer);
                cClasses.Add(CharClass.Crypter);
                cClasses.Add(CharClass.NanoMage);
                cClasses.Add(CharClass.StreetDoctor);
                break;
            case WeaponType.PPistol:
                cClasses.Add(CharClass.Psyc);
                cClasses.Add(CharClass.Apoch);
                cClasses.Add(CharClass.Crypter);
                cClasses.Add(CharClass.Shadow);
                break;
            case WeaponType.Rifle:
                cClasses.Add(CharClass.NanoMage);
                cClasses.Add(CharClass.Guardian);
                cClasses.Add(CharClass.Vigil);
                cClasses.Add(CharClass.Shadow);
                break;
            case WeaponType.Shield:
                cClasses.Add(CharClass.Golemancer);
                cClasses.Add(CharClass.Mystic);
                cClasses.Add(CharClass.Artificer);
                cClasses.Add(CharClass.Guardian);
                break;
            case WeaponType.Staff:
                cClasses.Add(CharClass.Golemancer);
                cClasses.Add(CharClass.Psyc);
                cClasses.Add(CharClass.Mystic);
                break;
            case WeaponType.Wand:
                cClasses.Add(CharClass.Golemancer);
                cClasses.Add(CharClass.Elementalist);
                cClasses.Add(CharClass.Psyc);
                cClasses.Add(CharClass.Mystic);
                break;
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
            player.xpGain.AddModifier(xpGain);
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
            player.xpGain.RemoveModifier(xpGain);
        }
    }

    #endregion

    #region Returns
    public GeneticType GetGeneticType()
    {
        return gType;
    }

    public EnchantmentType GetEnchantmentType()
    {
        return eType;
    }

    public BioneticEffect GetBioneticEffect()
    {
        return bEffect;
    }
    public CyberneticType GetCyberneticType()
    {
        return cType;
    }

    public string GetWeaponDamage()
    {
        string damage = "Damage: ";
        if (itemType == ItemType.Weapon)
        {
            if (totalDamageMin > 0)
            {
                damage = damage + totalDamageMin + " - ";
            }
            if (totalDamageMax > 0)
            {
                damage = damage + totalDamageMax + "\n(";
            }
            if (finalThermalMin > 0)
            {
                damage = damage + "Thermal: " + finalThermalMin + " - ";
            }        
            if (finalThermalMax > 0)
            {
                damage = damage + finalThermalMax + ")\n";
            }
            if (finalCryoMin > 0)
            {
                damage = damage + "Cryo: " + finalCryoMin + " - ";
            }
            if (finalCryoMax > 0)
            {
                damage = damage + finalCryoMax + ")\n";
            }
            if (finalShockMin > 0)
            {
                damage = damage + "Shock: " + finalShockMin + " - ";
            }
            if (finalShockMax > 0)
            {
                damage = damage + finalShockMax + ")\n";
            }
            if (finalRadMin > 0)
            {
                damage = damage + "Radiation: " + finalRadMin + " - ";
            }
            if (finalRadMax > 0)
            {
                damage = damage + finalRadMax + ")\n";
            }
            if (finalPsiMin > 0)
            {
                damage = damage + "Psi: " + finalPsiMin + " - ";
            }
            if (finalPsiMax > 0)
            {
                damage = damage + finalPsiMax + ")\n";
            }
            if (finalDimensionMin > 0)
            {
                damage = damage + "Dimension: " + finalDimensionMin + " - ";
            }
            if (finalDimensionMax > 0)
            {
                damage = damage + finalDimensionMax + ")\n";
            }
            if (finalKineticMin > 0)
            {
                damage = damage + "Kinetic: " + finalKineticMin + " - ";
            }
            if (finalKineticMax > 0)
            {
                damage = damage + finalKineticMax + ")\n";
            }
            if (finalPoisonMin > 0)
            {
                damage = damage + "Poison: " + finalPoisonMin + " - ";
            }
            if (finalPoisonMax > 0)
            {
                damage = damage + finalPoisonMax + ")\n";
            }
            if (finalBioMin > 0)
            {
                damage = damage + "Bio: " + finalBioMin + " - ";
            }
            if (finalBioMax > 0)
            {
                damage = damage + finalBioMax + ")\n";
            }
            if (finalCorruptionMin > 0)
            {
                damage = damage + "Corruption: " + finalCorruptionMin + " - ";
            }
            if (finalCorruptionMax > 0)
            {
                damage = damage + finalCorruptionMax + ")\n";
            }      
        }
        return damage;
    }
    
    public bool CheckClassAgainstPlayer()
    {
        foreach (CharClass cClass in cClasses)
        {
            if (cClass == Player.instance.cClass)
            {
                return true;
            }
        }
        return false;
    }

    public string GetClasses()
    {
        string classList = "";
        foreach (CharClass cClass in cClasses)
        {
            classList += cClass.ToString() + ", ";
        }
        return classList;
    }
    #endregion
}
//For reference, original enum are in Item
//ItemType { Weapon, ItemHead, ItemChest, ItemLegs, ItemFeet, ItemHands, Cybernetic, Bionetic, Genetic, Enchantment, Skill }
//Quality { Common, Uncommon, Masterwork, Rare, Legendary, Unique }

//TODO List of rare names
public enum RarePrefixPart1 { Chaos, Max }
public enum RarePrefixPart2 { Bane, Max }