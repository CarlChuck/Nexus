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
    Vigour, Verdure, Robustness, Hardiness, Endurance, Vitality, // + Vitality
    Aegis, Fortified, Bulwark, Barricade, Bastion, Citadel, // + Armour
    Briskness, Pacing, Dashing, Fleet, Swiftness, Haste, // + Movement
    Nimble, Tenacity, Quickness, Alacrity, Celerity, Speed, // + Speed
    Force, Fervor, Mayhem, Ravaging, Fury, Ferocious, // + Ferocity
    Potence, Ruin, Desolation, Power, Murder, Devastation, // + Devastation
    Sorrow, Misery, Sickness, Scourge, Anguish, Pain, // + Affliction
    Resolution, Perseverance, Duration, Constancy, Continuum, Persistence, // + Persistence
    Advantage, Opportunity, Occasion, Kismet, Karma, Serendipity, // + Luck
    Revivication, Regrowth, Regeneration, // + Health Regen
    Intensity, Defiance, Resistance, // + OnStruck - Boon Resistance %
    Attention, Concentration, Precision, // + OnStruck - Boon Precision %
    Rebounding, Mirroring, Reflection, // + OnStruck - Boon Reflection %
    Sturdiness, Stability, Defence, // + OnStruck - Boon Defence %
    Thorns, Spines, Torment, // + OnStruck - Boon Feedback %
    Proficiency, Expertise, Mastery, // + XP Gain

    //Weapons
    Blistering, Smouldering, Scorching, Searing, Blazing, Flame, //Fire Damage
    Glowing, Static, Arcing, Thunder, Lightning, Storm, // Shock Damage (and Stun)
    Corrosion, Contaminating, Toxicity, Suffering, Rupturing, Irradiating, // Radiation Damage (+Hex Dot)
    Clout, Mutilation, Destruction, Calamity, Havoc, Annihilation, //Physical Damage
    Draining, Leech, Enervating, Parasite, Predator, Vampire, //Leech
	Exposing, Fragility, Susceptibility, // OnHit - Hex Vuln %
    Lag, Sluggish, Languid, // OnHit - Hex Slow %
    Entangle, Quicksand, Quagmire, // OnHit - Hex Snare %
    Frailty, Feebleness, Debilitation, // OnHit - Hex Weaken %
    Fright, Terror, Horror, // OnHit - Hex Fear %
    Scowling, Oppressing, Threatening, // OnHit - Hex Intimidate %
    Teasing, Jeering, Insulting, // OnHit - Hex Taunt %
    Scalding, Heat, Burning, // OnHit - Burn %
    Cutting, Rending, Wounding, // OnHit - Bleed %
    Scarring, Bright, Shocking, // OnHit - Shock %

    //Mods
    Warmth, Luminosity, Incandescence, Combustion, Conflagration, Inferno,  //Fire Damage %
    Sparks, Light, Magnetism, Electrons, Volts, Electricity, //Shock Damage %
    Emission, Gamma, Cosmic, Neutrons, Uranium, Thorium, //Radiation Damage %
    Substantial, Corporeal, Material, Somatic, Solid, Kinetic, //Physical Damage %
}