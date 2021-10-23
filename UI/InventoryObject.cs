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
    [SerializeField] private TextMeshProUGUI damageText;
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
        damageText.text = item.totalDamageMin + " - " + item.totalDamageMax;
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
