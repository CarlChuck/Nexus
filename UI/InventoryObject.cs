using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private InventoryItem item;
    [SerializeField] private Transform icon3dLocation;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI additonText;
    [SerializeField] private Renderer emissiveRenderer;
    [SerializeField] private GameObject lighting;
    private InventoryUI invUI;
    private Inventory inv;

    public void StartItem(InventoryItem importItem)
    {
        invUI = InventoryUI.instance;
        inv = Inventory.instance;
        item = importItem;
        if (item != null)
        {
            if (item.icon3d != null)
            {
                GameObject newIcon = Instantiate(item.icon3d, icon3dLocation);
            }
        }     
        nameText.text = item.name;
        if (item.itemType == ItemType.Weapon)
        {
            additonText.text = "Damage: " + item.totalDamageMin + " - " + item.totalDamageMax;
        }
        if (item.itemType == ItemType.ItemChest || item.itemType == ItemType.ItemFeet || item.itemType == ItemType.ItemHands || item.itemType == ItemType.ItemHead || item.itemType == ItemType.ItemLegs)
        {
            additonText.text = "Armour: " + item.armour;
        }
        if (item.itemType == ItemType.Enchantment)
        {
            if (item.GetEnchantmentType() == EnchantmentType.ElementRegen)
            {
                additonText.text = "Passive: Element Regen";
            }

        }
        if (item.itemType == ItemType.Cybernetic)
        {
            if (item.GetCyberneticType() == CyberneticType.Armour)
            {
                additonText.text = "Passive: Armour " + item.armour;
            }
            else if (item.GetCyberneticType() == CyberneticType.AttkSpeed)
            {
                additonText.text = "On Activate: Attack Speed";
            }
            else if (item.GetCyberneticType() == CyberneticType.CorruptResist)
            {
                additonText.text = "On Activate: Corrupt Resist";
            }
            else if (item.GetCyberneticType() == CyberneticType.Dodge)
            {
                additonText.text = "On Activate: Dodge";
            }
        }
        if (item.itemType == ItemType.Bionetic)
        {
            if (item.GetBioneticEffect() == BioneticEffect.AoEHeal)
            {
                additonText.text = "On Activate: Area Heal";
            }
            else if (item.GetBioneticEffect() == BioneticEffect.Heal)
            {
                additonText.text = "On Activate: Self Heal";
            }
            else if (item.GetBioneticEffect() == BioneticEffect.HealOverTime)
            {
                additonText.text = "On Activate: Heal Over Time";
            }
            else if (item.GetBioneticEffect() == BioneticEffect.Leech)
            {
                additonText.text = "On Activate: Leeching Attacks";
            }
        }
        if (item.itemType == ItemType.Genetic)
        {
            if (item.GetGeneticType() == GeneticType.Armour)
            {
                additonText.text = "Passive: Amour";
            }
            else if (item.GetGeneticType() == GeneticType.Feedback)
            {
                additonText.text = "Passive: Feedback";
            }
            else if (item.GetGeneticType() == GeneticType.Leech)
            {
                additonText.text = "Passive: Leech";
            }
            else if (item.GetGeneticType() == GeneticType.Luck)
            {
                additonText.text = "Passive: Luck";
            }
            else if (item.GetGeneticType() == GeneticType.Regeneration)
            {
                additonText.text = "Passive: Regeneration";
            }
            else if (item.GetGeneticType() == GeneticType.XpGain)
            {
                additonText.text = "Passive: Experience Bonus";
            }
        }
        SetRarity();
    }
    public void SelectSlot()
    {

        SelectSlotGraphic();
    }
    public void SelectSlotGraphic()
    {

    }
    public void DeSelectSlot()
    {
        
    }

    public void OnPointerDown(PointerEventData pointerData)
    {

    }
    public void OnPointerUp(PointerEventData pointerData)
    {
        ItemType iType = invUI.selectedSlot.iType;
        //int slotNum = invUI.selectedSlot.slotNumber;
        ItemSlot slot = invUI.selectedSlot.slot;

        switch (iType)
        {
            case ItemType.ItemHead:
                inv.AddHeadSlot(item);
                break;
            case ItemType.ItemChest:
                inv.AddChestSlot(item);
                break;
            case ItemType.ItemLegs:
                inv.AddLegSlot(item);
                break;
            case ItemType.ItemFeet:
                inv.AddFeetSlot(item);
                break;
            case ItemType.ItemHands:
                inv.AddHandSlot(item);
                break;
            case ItemType.Cybernetic:
                inv.AddModCybernetic(item);
                break;
            case ItemType.Enchantment:
                inv.AddModEnchantment(item);
                break;
            case ItemType.Genetic:
                inv.AddModGenetic(item);
                break;
            case ItemType.Bionetic:
                inv.AddModBionetic(item);
                break;
            case ItemType.Weapon:
                inv.AddWeapon(item, slot);
                break;
            case ItemType.Skill://TODO
                //inv.AddSkill(item as Skill, slotNum);
                break;
            default:
                break;
        }
        invUI.UpdateFromSelectedSlot(invUI.selectedSlot);
    }
    public void OnPointerEnter(PointerEventData pointerData)
    {
        if (invUI.selectedSlot != this)
        {
            emissiveRenderer.materials[2].SetColor("_EmissiveColor", invUI.hoverEmissiveColour);
            lighting.SetActive(true);
        }
    }
    public void OnPointerExit(PointerEventData pointerData)
    {
        if (invUI.selectedSlot != this)
        {
            SetRarity();
            lighting.SetActive(false);
        }
    }

    public void SetRarity()
    {
        switch (item.quality)
        {
            case Quality.Common:
                nameText.color = invUI.commonTextColour;
                emissiveRenderer.materials[2].SetColor("_EmissiveColor", invUI.commonEmissiveColour);
                break;
            case Quality.Uncommon:
                nameText.color = invUI.uncommonTextColour;
                emissiveRenderer.materials[2].SetColor("_EmissiveColor", invUI.uncommonEmissiveColour);
                break;
            case Quality.Masterwork:
                nameText.color = invUI.masterworkTextColour;
                emissiveRenderer.materials[2].SetColor("_EmissiveColor", invUI.masterworkEmissiveColour);
                break;
            case Quality.Rare:
                nameText.color = invUI.rareTextColour;
                emissiveRenderer.materials[2].SetColor("_EmissiveColor", invUI.rareEmissiveColour);
                break;
            case Quality.Legendary:
                nameText.color = invUI.legendaryTextColour;
                emissiveRenderer.materials[2].SetColor("_EmissiveColor", invUI.legendaryEmissiveColour);
                break;
            case Quality.Unique:
                nameText.color = invUI.uniqueTextColour;
                emissiveRenderer.materials[2].SetColor("_EmissiveColor", invUI.uniqueEmissiveColour);
                break;
        }
    }
}
