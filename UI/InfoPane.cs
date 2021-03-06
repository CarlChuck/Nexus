﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPane : MonoBehaviour
{

    public TextMeshProUGUI infoText;
    public TextMeshProUGUI infoTitle;

    private void Start()
    {
        ResetPane();
    }

    public void ResetPane()
    {
        infoTitle.text = null;
        infoText.text = null;
    }

    public void UpdateInfo(Item item)
    {
        infoText.text = "";
        infoTitle.text = item.name;
        infoTitle.text += " (" + item.quality.ToString() + ")";

        if (item.itemType == ItemType.Weapon)
        {
            Weapon weapon = item as Weapon;
            infoText.text += "Weapon Type: " + weapon.wType.ToString() + "\n";
            infoText.text += "Handed: " + weapon.handedness.ToString() + "\n";
            //infoText.text += "Damage: " + weapon.damage.ToString() + "\n"; //TODO Damage Range
        }
        else if (item.itemType == ItemType.Skill)
        {/*
            Skill skill = item as Skill;
            infoText.text += "Class: " + skill.classRequired.ToString() + "\n";
            infoText.text += "Damage: " + skill.damage.ToString() + "\n";

            //TODO Cost for class abilities
            if (skill.classRequired == CharClass.Elementalist)
            {
                ElementalistSkill eSkill = skill as ElementalistSkill;
            }*/
        }
        else
        {  
            /*
            if (item.vitality != 0)
            {
                infoText.text += item.vitality.ToString() + "\n";
            }
            if (item.armour != 0)
            {
                infoText.text += item.armour.ToString() + "\n";
            }
            if (item.strength != 0)
            {
                infoText.text += item.strength.ToString() + "\n";
            }
            if (item.marksmanship != 0)
            {
                infoText.text += item.marksmanship.ToString() + "\n";
            }
            if (item.arcana != 0)
            {
                infoText.text += item.arcana.ToString() + "\n";
            }
            if (item.fireResistance != 0)
            {
                infoText.text += item.fireResistance.ToString() + "\n";
            }
            if (item.shockResistance != 0)
            {
                infoText.text += item.shockResistance.ToString() + "\n";
            }
            if (item.radResistance != 0)
            {
                infoText.text += item.radResistance.ToString() + "\n";
            }
            if (item.physicalResistance != 0)
            {
                infoText.text += item.physicalResistance.ToString() + "\n";
            }
            if (item.movement != 0)
            {
                infoText.text += item.movement.ToString() + "\n";
            }
            if (item.speed != 0)
            {
                infoText.text += item.speed.ToString() + "\n";
            }
            if (item.ferocity != 0)
            {
                infoText.text += item.ferocity.ToString() + "\n";
            }
            if (item.devastation != 0)
            {
                infoText.text += item.devastation.ToString() + "\n";
            }
            if (item.affliction != 0)
            {
                infoText.text += item.affliction.ToString() + "\n";
            }
            if (item.persistence != 0)
            {
                infoText.text += item.persistence.ToString() + "\n";
            }
            if (item.physDamage != 0)
            {
                infoText.text += item.physDamage.ToString() + "\n";
            }
            if (item.fireDamage != 0)
            {
                infoText.text += item.fireDamage.ToString() + "\n";
            }
            if (item.shockDamage != 0)
            {
                infoText.text += item.shockDamage.ToString() + "\n";
            }
            if (item.radDamage != 0)
            {
                infoText.text += item.radDamage.ToString() + "\n";
            }*/
        }
        infoText.text += "\n" + item.description;
    }

    public void EmptyInfo()
    {
        infoTitle.text = "";
        infoText.text = "";
    }
}
