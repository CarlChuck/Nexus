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
    [SerializeField] private TextMeshProUGUI requirementText;

    [SerializeField] private Transform icon3dParent;
    [SerializeField] private GameObject icon3d;

    //Lights
    [SerializeField] private GameObject commonBackLight = default;
    [SerializeField] private GameObject uncommonBackLight = default;
    [SerializeField] private GameObject masterworkBackLight = default;
    [SerializeField] private GameObject rareBackLight = default;
    [SerializeField] private GameObject legendaryBackLight = default;
    [SerializeField] private GameObject uniqueBackLight = default;

    //emissive Colours
    [SerializeField] private Renderer emissiveMaterial = default;

    //Colour sources in InventoryUI
    [SerializeField] private InventoryUI invUi;


    public void Start()
    {
        EmptyInfo();
        invUi = InventoryUI.instance;
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
        UpdateTheColour(); //Fix Showing colour
        EmptyInfo();
        infoTitle.text = item.name;
        infoTitle.text += " (" + item.quality.ToString() + ")"; //Rarity in words

        if (item.itemType == ItemType.Weapon)
        {
            infoTextLeft.text += "Weapon Type: " + item.wType.ToString() + "\n";
            infoTextLeft.text += "Handed: " + item.handedness.ToString() + "\n";
            infoTextRight.text += item.GetWeaponDamage() + "\n";
            if (item.wType == WeaponType.Shield)
            {
                infoTextRight.text += "Armour: " + item.armour.ToString() + "\n";
                infoTextRight.text += "Block: " + item.block.ToString() + "\n";
            }
        }
        else if (item.itemType == ItemType.ItemChest || item.itemType == ItemType.ItemFeet || item.itemType == ItemType.ItemHands || item.itemType == ItemType.ItemHead || item.itemType == ItemType.ItemLegs)
        {
            infoTextRight.text += "Armour: " + item.armour.ToString() + "\n";
        }
        else if (item.itemType == ItemType.Bionetic)
        {
            infoTextLeft.text += "Bionetic Type: " + item.GetBioneticEffect().ToString() + "\n";
        }
        else if (item.itemType == ItemType.Genetic)
        {
            infoTextLeft.text += "Genetic Type: " + item.GetGeneticType().ToString() + "\n";
        }
        else if (item.itemType == ItemType.Cybernetic)
        {
            infoTextLeft.text += "Cybernetic Type: " + item.GetCyberneticType().ToString() + "\n";
        }
        else if (item.itemType == ItemType.Enchantment)
        {
            infoTextLeft.text += "Enchantment Type: " + item.GetEnchantmentType().ToString() + "\n";
        }

        UpdateRequirements();

        //Check and correct all these
        if (item.vitality != 0)
        {
            infoTextRight.text += "+ " + item.vitality.ToString() + " Vitality" + "\n";
        }
        if (item.strength != 0)
        {
            infoTextRight.text += "+ " + item.strength.ToString() + " Strength" + "\n";
        }
        if (item.marksmanship != 0)
        {
            infoTextRight.text += "+ " + item.marksmanship.ToString() + " Marksmanship" + "\n";
        }
        if (item.arcana != 0)
        {
            infoTextRight.text += "+ " + item.arcana.ToString() + " Arcana" + "\n";
        }
        if (item.thermalResistance != 0)
        {
            infoTextRight.text += "+ " + item.thermalResistance.ToString() + " Thermal Resist" + "\n";
        }
        if (item.cryoResistance != 0)
        {
            infoTextRight.text += "+ " + item.cryoResistance.ToString() + " Cryo Resist" + "\n";
        }
        if (item.shockResistance != 0)
        {
            infoTextRight.text += "+ " + item.shockResistance.ToString() + " Shock Resist" + "\n";
        }
        if (item.radiationResistance != 0)
        {
            infoTextRight.text += "+ " + item.radiationResistance.ToString() + " Radiation Resist" + "\n";
        }
        if (item.psiResistance != 0)
        {
            infoTextRight.text += "+ " + item.psiResistance.ToString() + " Psi Resist" + "\n";
        }
        if (item.dimensionResistance != 0)
        {
            infoTextRight.text += "+ " + item.dimensionResistance.ToString() + " Dimension Resist" + "\n";
        }
        if (item.kineticResistance != 0)
        {
            infoTextRight.text += "+ " + item.kineticResistance.ToString() + " Kinetic Resist" + "\n";
        }
        if (item.poisonResistance != 0)
        {
            infoTextRight.text += "+ " + item.poisonResistance.ToString() + " Poison Resist" + "\n";
        }
        if (item.bioResistance != 0)
        {
            infoTextRight.text += "+ " + item.bioResistance.ToString() + " Bio Resist" + "\n";
        }
        if (item.corruptionResistance != 0)
        {
            infoTextRight.text += "+ " + item.corruptionResistance.ToString() + " Corruption Resist" + "\n";
        }
        if (item.movement != 0)
        {
            infoTextRight.text += "+ " + item.movement.ToString() + " Movement" + "\n";
        }
        if (item.speed != 0)
        {
            infoTextRight.text += "+ " + item.speed.ToString() + " Speed" + "\n";
        }
        if (item.ferocity != 0)
        {
            infoTextRight.text += "+ " + item.ferocity.ToString() + " Ferocity" + "\n";
        }
        if (item.devastation != 0)
        {
            infoTextRight.text += "+ " + item.devastation.ToString() + " Devastation" + "\n";
        }
        if (item.affliction != 0)
        {
            infoTextRight.text += "+ " + item.affliction.ToString() + " Affliction" + "\n";
        }
        if (item.persistence != 0)
        {
            infoTextRight.text += "+ " + item.persistence.ToString() + " Persistence" + "\n";
        }
        if (item.healthRegen != 0)
        {
            infoTextRight.text += "+ " + item.healthRegen.ToString() + " Health Regen" + "\n";
        }
        if (item.luck != 0)
        {
            infoTextRight.text += "+ " + item.luck.ToString() + " Luck" + "\n";
        }
        if (item.xpGain != 0)
        {
            infoTextRight.text += "+ " + item.xpGain.ToString() + " Xp Gain" + "\n";
        }
        if (item.leechHealth != 0)
        {
            infoTextRight.text += "+ " + item.leechHealth.ToString() + " Leech Health" + "\n";
        }
        if (item.feedback != 0)
        {
            infoTextRight.text += "+ " + item.feedback.ToString() + " Feedback" + "\n";
        }
        if (item.thermalDamage != 0)
        {
            infoTextRight.text += "+ " + item.thermalDamage.ToString() + " Thermal Damage" + "\n";
        }
        if (item.cryoDamage != 0)
        {
            infoTextRight.text += "+ " + item.cryoDamage.ToString() + " Cryo Damage" + "\n";
        }
        if (item.shockDamage != 0)
        {
            infoTextRight.text += "+ " + item.shockDamage.ToString() + " Shock Damage" + "\n";
        }
        if (item.radiationDamage != 0)
        {
            infoTextRight.text += "+ " + item.radiationDamage.ToString() + "Radiation Damage" + "\n";
        }
        if (item.psiDamage != 0)
        {
            infoTextRight.text += "+ " + item.psiDamage.ToString() + "Psi Damage" + "\n";
        }
        if (item.dimensionDamage != 0)
        {
            infoTextRight.text += "+ " + item.dimensionDamage.ToString() + "Dimension Damage" + "\n";
        }
        if (item.kineticDamage != 0)
        {
            infoTextRight.text += "+ " + item.kineticDamage.ToString() + " Kinetic Damage" + "\n";
        }
        if (item.poisonDamage != 0)
        {
            infoTextRight.text += "+ " + item.poisonDamage.ToString() + " Poison Damage" + "\n";
        }
        if (item.bioDamage != 0)
        {
            infoTextRight.text += "+ " + item.bioDamage.ToString() + " Bio Damage" + "\n";
        }
        if (item.corruptionDamage != 0)
        {
            infoTextRight.text += "+ " + item.corruptionDamage.ToString() + " Corruption Damage" + "\n";
        }


        infoTextLeft.text += item.description + "\n";

        valueText.text = item.value.ToString();
        SetRarity();
    }

    private void UpdateRequirements()
    {
        if (item.requiredLevel > 10 || item.requiredStrength > 10 || item.requiredMarksmanship > 10 || item.requiredArcana > 10 || item.itemType == ItemType.Weapon)
        {
            requirementText.text = "Requirements" + "\n";
        }

        if (item.requiredLevel > 10) 
        {
            requirementText.text += "level: " + item.requiredLevel + "\n";
        }
        if (item.requiredStrength > 10) 
        {
            requirementText.text += "Strength: " + item.requiredStrength + "\n";
        }
        if (item.requiredMarksmanship > 10) 
        {
            requirementText.text += "Marksmanship: " + item.requiredMarksmanship + "\n";
        }
        if (item.requiredArcana > 10) 
        {
            requirementText.text += "Arcana: " + item.requiredArcana + "\n";
        }

        if (item.itemType == ItemType.Weapon)
        {
            requirementText.text += item.GetClasses();
        }

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

    private void SetRarity()
    {
        if (item.quality == Quality.Common)
        {
            SetCommon();
        }
        else if (item.quality == Quality.Uncommon)
        {
            SetUncommon();
        }
        else if (item.quality == Quality.Masterwork)
        {
            SetMasterwork();
        }
        else if (item.quality == Quality.Rare)
        {
            SetRare();
        }
        else if (item.quality == Quality.Legendary)
        {
            SetLegendary();
        }
        else if (item.quality == Quality.Unique)
        {
            SetUnique();
        }
    }

    private void SetCommon()
    {
        emissiveMaterial.material.SetColor("_EmissiveColor", invUi.commonEmissiveColour);
        SetAllLightsOff();
        commonBackLight.SetActive(true);
        infoTitle.color = invUi.commonTextColour;
    }
    private void SetUncommon()
    {
        emissiveMaterial.material.SetColor("_EmissiveColor", invUi.uncommonEmissiveColour);
        SetAllLightsOff();
        uncommonBackLight.SetActive(true);
        infoTitle.color = invUi.uncommonTextColour;
    }
    private void SetMasterwork()
    {
        emissiveMaterial.material.SetColor("_EmissiveColor", invUi.masterworkEmissiveColour);
        SetAllLightsOff();
        masterworkBackLight.SetActive(true);
        infoTitle.color = invUi.masterworkTextColour;
    }
    private void SetRare()
    {
        emissiveMaterial.material.SetColor("_EmissiveColor", invUi.rareEmissiveColour);
        SetAllLightsOff();
        rareBackLight.SetActive(true);
        infoTitle.color = invUi.rareTextColour;
    }
    private void SetLegendary()
    {
        emissiveMaterial.material.SetColor("_EmissiveColor", invUi.legendaryEmissiveColour);
        SetAllLightsOff();
        legendaryBackLight.SetActive(true);
        infoTitle.color = invUi.legendaryTextColour;
    }
    private void SetUnique()
    {
        emissiveMaterial.material.SetColor("_EmissiveColor", invUi.uniqueEmissiveColour);
        SetAllLightsOff();
        uniqueBackLight.SetActive(true);
        infoTitle.color = invUi.uniqueTextColour;
    }

    private void SetAllLightsOff()
    {
        commonBackLight.SetActive(false);
        uncommonBackLight.SetActive(false);
        masterworkBackLight.SetActive(false);
        rareBackLight.SetActive(false);
        legendaryBackLight.SetActive(false);
        uniqueBackLight.SetActive(false);
    }
}
