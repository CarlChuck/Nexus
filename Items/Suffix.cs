using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Cryo1, Cryo2, Cryo3, Cryo4, Cryo5, Cryo6,                               // Cryo Damage
    Glowing, Static, Arcing, Thunder, Lightning, Storm,                     // Shock Damage (and Stun)
    Corrosion, Contaminating, Toxicity, Suffering, Rupturing, Irradiating,  // Radiation Damage (+Hex Dot)
    Psi1, Psi2, Psi3, Psi4, Psi5, Psi6,                                     // Psi Damage
    Dimension1, Dimension2, Dimension3, Dimension4, Dimension5, Dimension6, // Dimensional Damage
    Clout, Mutilation, Destruction, Calamity, Havoc, Annihilation,          // Kinetic Damage
    Poison1, Poison2, Poison3, Poison4, Poison5, Poison6,                   // Poison Damage
    Bio1, Bio2, Bio3, Bio4, Bio5, Bio6,                                     // Bio Damage
    Corrupt1, Corrupt2, Corrupt3, Corrupt4, Corrupt5, Corrupt6,             // Corruption Damage //KEEP OUT OF MAIN LIST (Uniques only)
    Draining, Leech, Enervating, Parasite, Predator, Vampire,               // Leech
	Exposing, Fragility, Susceptibility,                                    // OnHit - Hex Vuln %
    Lag, Sluggish, Languid,                                                 // OnHit - Hex Slow %
    Entangle, Quicksand, Quagmire,                                          // OnHit - Hex Snare %
    Frailty, Feebleness, Debilitation,                                      // OnHit - Hex Weaken %
    Fright, Terror, Horror,                                                 // OnHit - Hex Fear %
    Scowling, Oppressing, Threatening,                                      // OnHit - Hex Intimidate %
    Teasing, Jeering, Insulting,                                            // OnHit - Hex Taunt %
    Scalding, Heat, Burning,                                                // OnHit - Burn %
    Cutting, Rending, Wounding,                                             // OnHit - Bleed %
    Scarring, Bright, Shocking,                                             // OnHit - Shock %

    //Mods
    Warmth, Luminosity, Incandescence, Combustion, Conflagration, Inferno,                      // Thermal Damage %
    CryoDam1, CryoDam2, CryoDam3, CryoDam4, CryoDam5, CryoDam6,                                 // Cryo Damage %
    Sparks, Light, Magnetism, Electrons, Volts, Electricity,                                    // Shock Damage %
    AllEleDam1, AllEleDam2, AllEleDam3, AllEleDam4, AllEleDam5, AllEleDam6,                     // All Elemental Damage %
    Emission, Gamma, Cosmic, Neutrons, Uranium, Thorium,                                        // Radiation Damage %
    PsiDam1, PsiDam2, PsiDam3, PsiDam4, PsiDam5, PsiDam6,                                       // Psi Damage %
    DimensionDam1, DimensionDam2, DimensionDam3, DimensionDam4, DimensionDam5, DimensionDam6,   // Dimensional Damage %
    AllCyberDam1, AllCyberDam2, AllCyberDam3, AllCyberDam4, AllCyberDam5, AllCyberDam6,         // All Cyber Damage %
    Substantial, Corporeal, Material, Somatic, Solid, Kinetic,                                  // Kinetic Damage %
    PoisonDam1, PoisonDam2, PoisonDam3, PoisonDam4, PoisonDam5, PoisonDam6,                     // Poison Damage %
    BioDam1, BioDam2, BioDam3, BioDam4, BioDam5, BioDam6,                                       // Bio Damage %
    AllMundane1, AllMundane2, AllMundane3, AllMundane4, AllMundane5, AllMundane6,               // All Mundane Damage %
}