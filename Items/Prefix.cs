using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Prefix")]
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
    Ventilated, Ablative, Cooling, Beryllium, Emissive, Thermic,                    // + Thermal Resist
    Warm, Thawing, Polymer, Nitro, Heated, Insulated,                               // + Cryo Resist
    AntiStatic, Magnetic, Rubber, Silicone, Dissipative, Grounding,                 // + Shock Resist
    Stable, Temperate, Constant, Primordial, Primal, Elemental,                     // + All Elemental Resists
    Hazmat, Lead, Carbide, Ion, Boron, Radium,                                      // + Radiation Resist
    Neuron, Axon, Synaptic, Telekinetic, Psychokinetic, Psionic,                    // + Psi Resist
    Spatial, Manifold, Tesseract, Quantum, Euclidean, Absolute,                     // + Dimensional Resist 
    Tech, Synthetic, Fabricated, Graviton, Synthwave, Holographic,                  // + All Cyber Resists
    Sturdy, Compact, Rock, Steel, Dense, Solid,                                     // + Kinetic Resist 
    Neutralising, Vaccine, Antibody, Mithridatism, Immune, Antidote,                // + Poison Resist
    Alkaline, Sodium, Acerbic, Antibiotic, Antigen, Genetic,                        // + Bio Resist 
    Counteractive, Obstructive, Aversive, Hindering, Defiant, Resiliant,            // + All Mundane Resists
    Declining, Decaying, Degenerating, Ataxic, Entropic, Tide,                      // + Corruption Resist
    Quartz, Amethyst, Sapphire, Emerald, Ruby, Diamond,                             // + All Resist
    Favoured, Successful, Fortunate, Wealthy, Prosperous, Lucky,                    // + Luck

    //Weapons
    Reinforced, Preserving, Shielding, Defending, Protecting, Guarding,             // + Armour (Shield Only)
    Disrupting, Obstructing, Deflecting, Repelling, Parrying, Warding,              // + Blocking (Shield Only)

    //Weapon + Mods
    Brisk, Quick, Swift, Fast, Accelerating, Rapid,                                 //+ Speed
    Peppy, Cruel, Ferocious, Brutal, Savage, Deadly,                                // +% Damage
}