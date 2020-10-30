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
    Rugged, Brawny, Strong, Mighty, Titan, Herculean, // + Str
    Accurate, Sharpshooter, Sniper, Hawkeye, Deadeye, Assassin, // + Marksman
    Mysterious, Spirit, Psy, Mystic, Mythic, Fae, // + Arcana

    //Armour
    Stout, Durable, Tough, Stalwart, Fortified, Invincible, // + Armour %
    Carnelian, Spinel, Russet, Jasper, Garnet, Ruby, // + Fire Resist
    Citrine, Chrysoberyl, Ocher, Zircon, Amber, Topaz, // + Shock Resist
    Peridot, Verdelite, Beryl, Viridian, Jade, Emerald, // + Radiation Resist
    Flourite, Charoite, Sugilite, Kunzite, Iolite, Amethyst, // + Physical Resist
    Quartz, Coral, Moonstone, Opal, Pearl, Diamond, // + All Resist
    Favoured, Successful, Fortunate, Wealthy, Prosperous, Lucky, // + Luck

    //Weapons
    Reinforced, Preserving, Shielding, Defending, Protecting, Guarding, // + Armour (Shield Only)
    Disrupting, Obstructing, Deflecting, Repelling, Parrying, Warding, // + Blocking (Shield Only)

    //Weapon + Mods
    Brisk, Quick, Swift, Fast, Accelerating, Rapid, //+ Speed
    Peppy, Cruel, Ferocious, Brutal, Savage, Deadly, // +% Damage
}