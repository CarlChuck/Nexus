using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefix : ScriptableObject
{
    public PrefixName pName;
    public int min;
    public int max;
    public List<ItemType> iTypes;
}
public enum PrefixName 
{
    //Armour + Weapons + Mods
    Rugged, Brawny, Strong, Mighty, Titan, Herculean,                               // + Str
    Accurate, Sharpshooter, Sniper, Hawkeye, Deadeye, Assassin,                     // + Marksman
    Mysterious, Spirit, Psy, Mystic, Mythic, Fae,                                   // + Arcana

    //Armour
    Stout, Durable, Tough, Stalwart, Fortified, Invincible,                         // + Armour %
    Carnelian, Spinel, Russet, Jasper, Garnet, Ruby,                                // + Thermal Resist
    Cryo1, Cryo2, Cryo3, Cryo4, Cryo5, Cryo6,                                       // + Cryo Resist //TODO
    Citrine, Chrysoberyl, Ocher, Zircon, Amber, Topaz,                              // + Shock Resist
    AllEle1, AllEle2, AllEle3, AllEle4, AllEle5, AllEle6,                           // + All Elemental Resists //TODO
    Peridot, Verdelite, Beryl, Viridian, Jade, Emerald,                             // + Radiation Resist
    Psi1, Psi2, Psi3, Psi4, Psi5, Psi6,                                             // + Psi Resist //TODO
    Dimension1, Dimension2, Dimension3, Dimension4, Dimension5, Dimension6,         // + Dimensional Resist //TODO
    AllCyber1, AllCyber2, AllCyber3, AllCyber4, AllCyber5, AllCyber6,               // + All Cyber Resists //TODO
    Flourite, Charoite, Sugilite, Kunzite, Iolite, Amethyst,                        // + Kinetic Resist
    Poison1, Poison2, Poison3, Poison4, Poison5, Poison6,                           // + Poison Resist  //TODO
    Bio1, Bio2, Bio3, Bio4, Bio5, Bio6,                                             // + Bio Resist //TODO
    AllMundane1, AllMundane2, AllMundane3, AllMundane4, AllMundane5, AllMundane6,   // + All Mundane Resists //TODO
    Corrupt1, Corrupt2, Corrupt3, Corrupt4, Corrupt5, Corrupt6,                     // + Corruption Resist //TODO
    Quartz, Coral, Moonstone, Opal, Pearl, Diamond,                                 // + All Resist
    Favoured, Successful, Fortunate, Wealthy, Prosperous, Lucky,                    // + Luck

    //Weapons
    Reinforced, Preserving, Shielding, Defending, Protecting, Guarding,             // + Armour (Shield Only)
    Disrupting, Obstructing, Deflecting, Repelling, Parrying, Warding,              // + Blocking (Shield Only)

    //Weapon + Mods
    Brisk, Quick, Swift, Fast, Accelerating, Rapid,                                 //+ Speed
    Peppy, Cruel, Ferocious, Brutal, Savage, Deadly,                                // +% Damage
}