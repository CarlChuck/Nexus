using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPane : MonoBehaviour
{
    private InventoryItem item;
    [SerializeField] private TextMeshProUGUI infoTextLeft;
    [SerializeField] private TextMeshProUGUI infoTextRight;
    [SerializeField] private TextMeshProUGUI infoTitle;
    [SerializeField] private TextMeshProUGUI valueText;

    [SerializeField] private Transform icon3dParent;
    [SerializeField] private GameObject icon3d;
    [SerializeField] private Image iconBacking;
    [SerializeField] private Image textBacking;
    private void Start()
    {
        EmptyInfo();
    }

    public void UpdateInfo(InventoryItem itemIn)
    {
        item = itemIn;
        if (icon3d != null)
        {
            Destroy(icon3d);
            icon3d = null;
        }
        if (item.icon3d != null)
        {
            icon3d = Instantiate(item.icon3d, icon3dParent);
        }
        UpdateTheColour();
        EmptyInfo();
        infoTitle.text = item.name;
        infoTitle.text += " (" + item.quality.ToString() + ")";

        if (item.itemType == ItemType.Weapon)
        {

            infoTextLeft.text += "Weapon Type: " + item.wType.ToString() + "\n";
            infoTextLeft.text += "Handed: " + item.handedness.ToString() + "\n";
            infoTextRight.text += "Damage: " + item.GetWeaponDamage() + "\n"; 
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
            if (item.thermalResistance != 0)
            {
                infoText.text += item.thermalResistance.ToString() + "\n";
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
            }
            */
        }
        infoTextRight.text += "\n" + item.description;
        infoTextLeft.text += "\n" + item.description;


    }

    private void UpdateTheColour()
    {
        InventoryUI invUI = InventoryUI.instance;

        switch (item.quality)
        {
            case Quality.Common:
                //iconBacking.sprite = invUI.ItemBackCommon;
                //textBacking.sprite = invUI.DirectionalCommon;
                break;
            case Quality.Uncommon:
                //iconBacking.sprite = invUI.ItemBackUncommon;
                //textBacking.sprite = invUI.DirectionalUncommon;
                break;
            case Quality.Masterwork:
                //iconBacking.sprite = invUI.ItemBackMasterwork;
                //textBacking.sprite = invUI.DirectionalMasterwork;
                break;
            case Quality.Rare:
                //iconBacking.sprite = invUI.ItemBackRare;
                //textBacking.sprite = invUI.DirectionalRare;
                break;
            case Quality.Legendary:
                //iconBacking.sprite = invUI.ItemBackLegendary;
                //textBacking.sprite = invUI.DirectionalLegendary;
                break;
            case Quality.Unique:
                //iconBacking.sprite = invUI.ItemBackUnique;
                //textBacking.sprite = invUI.DirectionalUnique;
                break;
        }
    }

    private void EmptyInfo()
    {
        InventoryUI invUI = InventoryUI.instance;
        infoTitle.text = "";
        infoTextRight.text = "";
        infoTextLeft.text = "";
    }
}
