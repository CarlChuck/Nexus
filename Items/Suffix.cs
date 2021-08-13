using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Suffix")]
public class Suffix : ScriptableObject
{
    public SuffixName sName;
    public bool the;
    public int min;
    public int max;
    public List<ItemType> iTypes;
}
public enum SuffixName 
{
    //Armour
    Vigour, Verdure, Robustness, Hardiness, Endurance, Vitality,            // + Vitality
    Aegis, Fortified, Bulwark, Barricade, Bastion, Citadel,                 // + Armour
    Briskness, Pacing, Dashing, Fleet, Swiftness, Haste,                    // + Movement
    Nimble, Tenacity, Quickness, Alacrity, Celerity, Speed,                 // + Speed
    Force, Fervor, Mayhem, Ravaging, Fury, Ferocious,                       // + Ferocity
    Potence, Ruin, Desolation, Power, Murder, Devastation,                  // + Devastation
    Sorrow, Misery, Sickness, Scourge, Anguish, Pain,                       // + Affliction
    Resolution, Perseverance, Duration, Constancy, Continuum, Persistence,  // + Persistence
    Advantage, Opportunity, Occasion, Kismet, Karma, Serendipity,           // + Luck
    Revivication, Regrowth, Regeneration,                                   // + Health Regen
    Intensity, Defiance, Resistance,                                        // + OnStruck - Boon Resistance %
    Attention, Concentration, Precision,                                    // + OnStruck - Boon Precision %
    Rebounding, Mirroring, Reflection,                                      // + OnStruck - Boon Reflection %
    Sturdiness, Stability, Defence,                                         // + OnStruck - Boon Defence %
    Thorns, Spines, Torment,                                                // + OnStruck - Boon Feedback %
    Proficiency, Expertise, Mastery,                                        // + XP Gain

    //Weapons
    Blistering, Smouldering, Scorching, Searing, Blazing, Flame,            // Thermal Damage
    Chill, Cold, Frost, Ice, Rime, Glacier,                                 // Cryo Damage
    Glowing, Static, Arcing, Thunder, Lightning, Storm,                     // Shock Damage (and Stun)
    Corrosion, Contamination, Toxicity, Suffering, Rupturing, Irradiating,  // Radiation Damage (+Hex Dot)
    Agitation, Ejection, Suspension, Phobia, Manipulation, Projection,      // Psi Damage
    Astral, Veil, Planes, Ectoplasm, Banishment, Displacement,              // Dimensional Damage
    Clout, Mutilation, Destruction, Calamity, Havoc, Annihilation,          // Kinetic Damage
    Affliction, Contagion, Virulence, Toxins, Blight, Venom,                // Poison Damage
    Virus, Bacteria, Miasma, Disease, Epidemic, Plague,                     // Bio Damage
    Corrupt1, Corrupt2, Corrupt3, Corrupt4, Corrupt5, Corrupt6,             // Corruption Damage //KEEP OUT OF MAIN LIST (Uniques only)
    Draining, Leech, Enervating, Parasite, Predator, Vampire,               // Leech
	Exposing, Fragility, Susceptibility,                                    // OnHit - Hex Vuln %
    Lag, Sluggish, Languid,                                                 // OnHit - Hex Slow %
    Entanglement, Quicksand, Quagmire,                                      // OnHit - Hex Snare %
    Frailty, Feebleness, Debilitation,                                      // OnHit - Hex Weaken %
    Fright, Terror, Horror,                                                 // OnHit - Hex Fear %
    Scowling, Oppressing, Threatening,                                      // OnHit - Hex Intimidate %
    Teasing, Jeering, Insulting,                                            // OnHit - Hex Taunt %
    Scalding, Heat, Burning,                                                // OnHit - Burn %
    Cutting, Rending, Wounding,                                             // OnHit - Bleed %
    Scarring, Bright, Shocking,                                             // OnHit - Shock %

    //Mods

    //Mod Enchantment only
    Thermal,                                                                // Thermal Damage %
    Cryogenics,                                                             // Cryo Damage %
    Shock,                                                                  // Shock Damage %
    Radiation,                                                              // Radiation Damage %
    Psy,                                                                    // Psi Damage %
    Dimensions,                                                             // Dimensional Damage %
    Kinetic,                                                                // Kinetic Damage %
    Poison,                                                                 // Poison Damage %
    Biogenics                                                               // Bio Damage %
}