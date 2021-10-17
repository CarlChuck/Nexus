﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [Header("Main")]
    public GameObject icon3d = null; //Set in Inspector
    public ItemType itemType; //Set in Inspector
    public Quality quality;
    public string description; //Set in Inspector
    public GameObject lootDropGraphic; //Set in Inspector

    [Header("Requirements")]
    public int requiredLevel = 0;
    public int requiredStrength = 0;
    public int requiredMarksmanship = 0;
    public int requiredArcana = 0;

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
    //Armour range
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
}
public enum ItemType { Weapon, ItemHead, ItemChest, ItemLegs, ItemFeet, ItemHands, Cybernetic, Bionetic, Genetic, Enchantment, Skill}
public enum Quality { Common, Uncommon, Masterwork, Rare, Legendary, Unique }

