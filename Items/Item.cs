using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public Animator anim;
    public ItemType itemType;
    public Quality quality;
    public string description;
    public GameObject lootDropGraphic;
    private List<Prefix> prefixes;
    private List<Suffix> suffixes;

    //Stats
    public int vitality;
    public int armour;
    public int strength;
    public int marksmanship;
    public int arcana;

    //Defence Skills
    public int fireResistance;
    public int shockResistance;
    public int radResistance;
    public int physicalResistance;

    //Secondary Skills
    public int movement;
    public int speed;
    public int ferocity;
    public int devastation;
    public int affliction;
    public int persistence;
    public int luck;

    //Hidden Skills
    public int physDamage;
    public int fireDamage;
    public int shockDamage;
    public int radDamage;

    //TODO AddPrefix/Suffix stats to the item
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
    }
}
public enum ItemType { Weapon, ItemHead, ItemChest, ItemLegs, ItemFeet, ItemHands, ModDex, ModStr, ModSta, ModHeal, Skill }
public enum Quality { Common, Uncommon, Masterwork, Rare, Legendary, Unique }

