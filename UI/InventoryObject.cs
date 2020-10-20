using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Item item;
    public Image icon; //To colour for rarity?
    public TextMeshProUGUI objectText;

    public Image selectedImage;
    public Sprite baseImageBorder;
    public Sprite selectedImageBorder;


    public void SelectSlot()
    {
        selectedImage.sprite = selectedImageBorder;
    }
    public void DeSelectSlot()
    {
        selectedImage.sprite = baseImageBorder;
    }

    public void OnPointerDown(PointerEventData pointerData)
    {

    }
    public void OnPointerUp(PointerEventData pointerData)
    {
        Inventory inv = Inventory.instance;
        InventoryUI invUI = InventoryUI.instance;
        ItemType iType = invUI.selected.iType;
        int slotNum = invUI.selected.slotNumber;

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
            case ItemType.ModDex:
                inv.AddModDexSlot(item as ModDex);
                break;
            case ItemType.ModStr:
                inv.AddModStrSlot(item as ModStr);
                break;
            case ItemType.ModSta:
                inv.AddModStaSlot(item as ModSta);
                break;
            case ItemType.ModHeal:
                inv.AddModHeallot(item as ModHeal);
                break;
            case ItemType.Weapon:
                inv.AddWeapon(item as Weapon, slotNum);
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
        InventoryUI invUI = InventoryUI.instance;
        invUI.InvItemStats(item);
    }
    public void OnPointerExit(PointerEventData pointerData)
    {
        DeSelectSlot();
        InventoryUI invUI = InventoryUI.instance;
        invUI.InvItemBlank();
    }
}
