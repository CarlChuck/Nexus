using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Item item;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI objectText;

    [SerializeField] private Image iconBacking;
    [SerializeField] private Image textBacking;
    private InventoryUI invUI;
    private Inventory inv;
    public void StartItem(Item importItem)
    {
        invUI = InventoryUI.instance;
        inv = Inventory.instance;
        item = importItem;
        icon.sprite = item.icon;
        objectText.text = item.name;
        SetRarity();
    }
    public void SelectSlot()
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
                inv.AddHeadSlot(item as ItemHead);
                break;
            case ItemType.ItemChest:
                inv.AddChestSlot(item as ItemChest);
                break;
            case ItemType.ItemLegs:
                inv.AddLegSlot(item as ItemLegs);
                break;
            case ItemType.ItemFeet:
                inv.AddFeetSlot(item as ItemFeet);
                break;
            case ItemType.ItemHands:
                inv.AddHandSlot(item as ItemHands);
                break;
            case ItemType.Cybernetic:
                inv.AddModCybernetic(item as CyberneticMod);
                break;
            case ItemType.Enchantment:
                inv.AddModEnchantment(item as EnchantmentMod);
                break;
            case ItemType.Genetic:
                inv.AddModGenetic(item as GeneticMod);
                break;
            case ItemType.Bionetic:
                inv.AddModBionetic(item as BioneticMod);
                break;
            case ItemType.Weapon:
                inv.AddWeapon(item as Weapon, slot);
                break;
            case ItemType.Skill://TODO
                //inv.AddSkill(item as Skill, slotNum);
                break;
            default:
                break;
        }
        invUI.invItemInfo.EmptyInfo();

    }
    public void OnPointerEnter(PointerEventData pointerData)
    {
        SelectSlot();
        invUI.InvItemStats(item);
    }
    public void OnPointerExit(PointerEventData pointerData)
    {
        DeSelectSlot();
        invUI.InvItemBlank();
    }

    public void SetRarity()
    {
        switch (item.quality)
        {
            case Quality.Common:
                iconBacking.sprite = invUI.ItemBackCommon;
                textBacking.sprite = invUI.DirectionalCommon;
                break;
            case Quality.Uncommon:
                iconBacking.sprite = invUI.ItemBackUncommon;
                textBacking.sprite = invUI.DirectionalUncommon;
                break;
            case Quality.Masterwork:
                iconBacking.sprite = invUI.ItemBackMasterwork;
                textBacking.sprite = invUI.DirectionalMasterwork;
                break;
            case Quality.Rare:
                iconBacking.sprite = invUI.ItemBackRare;
                textBacking.sprite = invUI.DirectionalRare;
                break;
            case Quality.Legendary:
                iconBacking.sprite = invUI.ItemBackLegendary;
                textBacking.sprite = invUI.DirectionalLegendary;
                break;
            case Quality.Unique:
                iconBacking.sprite = invUI.ItemBackUnique;
                textBacking.sprite = invUI.DirectionalUnique;
                break;
        }
    }
}
