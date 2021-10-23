using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    #region Singleton
    public static InventoryUI instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    //The singleton management classes
    public Inventory inventory;
    public WeaponManager weaponManager;
    public StatPane stats;

    //The inventory pane where items go
    public GameObject weaponPane;
    public GameObject skillPane;
    public GameObject headItemPane;
    public GameObject chestItemPane;
    public GameObject handItemPane;
    public GameObject legItemPane;
    public GameObject feetItemPane;
    public GameObject bioneticItemPane;
    public GameObject enchantmentItemPane;
    public GameObject geneticItemPane;
    public GameObject cyberneticItemPane;

    //selected inventory slot
    public InventorySlot selectedSlot;
    public Transform equippedPane;

    public InventoryObject invObject;

    public InfoPane equippedItemInfo;

    public List<InventorySlot> invSlots;

    public Color commonTextColour = default;
    public Color uncommonTextColour = default;
    public Color masterworkTextColour = default;
    public Color rareTextColour = default;
    public Color legendaryTextColour = default;
    public Color uniqueTextColour = default;

    [ColorUsage(true, true)]
    public Color commonEmissiveColour = default;
    [ColorUsage(true, true)]
    public Color uncommonEmissiveColour = default;
    [ColorUsage(true, true)]
    public Color masterworkEmissiveColour = default;
    [ColorUsage(true, true)]
    public Color rareEmissiveColour = default;
    [ColorUsage(true, true)]
    public Color legendaryEmissiveColour = default;
    [ColorUsage(true, true)]
    public Color uniqueEmissiveColour = default;

    [ColorUsage(true, true)]
    public Color baseEmissiveColour = default;
    [ColorUsage(true, true)]
    public Color hoverEmissiveColour = default;
    [ColorUsage(true, true)]
    public Color selectedEmissiveColour = default;


    void Start ()
    {
        DontDestroyOnLoad(this);
        weaponManager = WeaponManager.instance;
        inventory = Inventory.instance;
        selectedSlot = invSlots[0];
        selectedSlot.SelectSlot();
        UpdateFromSelectedSlot(selectedSlot);
    }	

    //Update UI from Inventory class
    public void UpdateUI()
    {
        ClearEquipped();
        ClearPanel(weaponPane);
        ClearPanel(headItemPane);
        ClearPanel(chestItemPane);
        ClearPanel(legItemPane);
        ClearPanel(feetItemPane);
        ClearPanel(handItemPane);
        ClearPanel(bioneticItemPane);
        ClearPanel(enchantmentItemPane);
        ClearPanel(geneticItemPane);
        ClearPanel(cyberneticItemPane);
        ClearPanel(skillPane);

        if (selectedSlot != null)
        {
            if (selectedSlot.slot == ItemSlot.LWeap)
            {
                if (inventory.lHand != null)
                {
                    UpdatePanel(inventory.weaponry, weaponPane);
                }
                else
                {
                    UpdatePanel(inventory.weaponry, weaponPane);
                }
            }
            else
            {
                if (inventory.rHand != null)
                {
                    UpdatePanel(inventory.weaponry, weaponPane);
                }
                else
                {
                    UpdatePanel(inventory.weaponry, weaponPane);
                }

                if (inventory.headSlot != null)
                {
                    UpdatePanel(inventory.headSlots, headItemPane);
                }
                else
                {
                    UpdatePanel(inventory.headSlots, headItemPane);
                }

                if (inventory.chestSlot != null)
                {
                    UpdatePanel(inventory.chestSlots, chestItemPane);
                }
                else
                {
                    UpdatePanel(inventory.chestSlots, chestItemPane);
                }

                if (inventory.legSlot != null)
                {
                    UpdatePanel(inventory.legSlots, legItemPane);
                }
                else
                {
                    UpdatePanel(inventory.legSlots, legItemPane);
                }

                if (inventory.feetSlot != null)
                {
                    UpdatePanel(inventory.feetSlots, feetItemPane);
                }
                else
                {
                    UpdatePanel(inventory.feetSlots, feetItemPane);
                }

                if (inventory.handSlot != null)
                {
                    UpdatePanel(inventory.handSlots, handItemPane);
                }
                else
                {
                    UpdatePanel(inventory.handSlots, handItemPane);
                }

                if (inventory.modBionetic != null)
                {
                    UpdatePanel(inventory.modBionetics, bioneticItemPane);
                }
                else
                {
                    UpdatePanel(inventory.modBionetics, bioneticItemPane);
                }

                if (inventory.modEnchantment != null)
                {
                    UpdatePanel(inventory.modEnchantments, enchantmentItemPane);
                }
                else
                {
                    UpdatePanel(inventory.modEnchantments, enchantmentItemPane);
                }

                if (inventory.modGenetic != null)
                {
                    UpdatePanel(inventory.modGenetics, geneticItemPane);
                }
                else
                {
                    UpdatePanel(inventory.modGenetics, geneticItemPane);
                }

                if (inventory.modCybernetic != null)
                {
                    UpdatePanel(inventory.modCybernetics, cyberneticItemPane);
                }
                else
                {
                    UpdatePanel(inventory.modCybernetics, cyberneticItemPane);
                }
            }            
        }


        if (selectedSlot != null)
        {
            if (selectedSlot.slot == ItemSlot.LWeap)
            {
                 UpdateEquippedDisplay(inventory.lHand);

            }
            else
            {
                switch (selectedSlot.iType)
                {
                    case ItemType.Weapon:
                            UpdateEquippedDisplay(inventory.rHand);
                        break;
                    case ItemType.ItemChest:
                            UpdateEquippedDisplay(inventory.chestSlot);
                        break;
                    case ItemType.ItemFeet:
                            UpdateEquippedDisplay(inventory.feetSlot);
                        break;
                    case ItemType.ItemHands:
                            UpdateEquippedDisplay(inventory.handSlot);
                        break;
                    case ItemType.ItemHead:
                            UpdateEquippedDisplay(inventory.headSlot);
                        break;
                    case ItemType.ItemLegs:
                            UpdateEquippedDisplay(inventory.legSlot);
                        break;
                    case ItemType.Genetic:
                            UpdateEquippedDisplay(inventory.modGenetic);
                        break;
                    case ItemType.Bionetic:
                            UpdateEquippedDisplay(inventory.modBionetic);
                        break;
                    case ItemType.Cybernetic:
                            UpdateEquippedDisplay(inventory.modCybernetic);
                        break;
                    case ItemType.Enchantment:
                            UpdateEquippedDisplay(inventory.modEnchantment);
                        break;
                    default:
                        break;
                }
            }
        }

        //UpdatePanel(inventory.skills, skillPane);

        weaponManager.UpdateWeapons();
        Player player = Player.instance; 
        stats.UpdateAllStats(player);
    }

    public void UpdateFromSelectedSlot(InventorySlot slot)
    {
        selectedSlot = slot;
        OpenPaneFromItem(slot.iType);
        UpdateUI();
    }

    //Update/Clear panels and slots
    private void UpdateEquippedDisplay(InventoryItem equipped)
    {
        if (equipped != null)
        {
            InventoryObject emptyItem = Instantiate(invObject, equippedPane);
            emptyItem.StartItem(equipped);
        }
    }

    private void UpdatePanel(List<InventoryItem> items, GameObject pane)
    {
        foreach (InventoryItem item in items)
        {
            InventoryObject emptyItem = Instantiate(invObject, pane.transform);
            emptyItem.StartItem(item);
        }
    }
    
    private void ClearEquipped()
    {
        foreach(Transform child in equippedPane)
        {
            Destroy(child.gameObject);
        }
    }
    
    private void ClearPanel(GameObject panel)
    {
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void CloseAllPanes()
    {
        weaponPane.SetActive(false);
        skillPane.SetActive(false);
        headItemPane.SetActive(false);
        chestItemPane.SetActive(false);
        legItemPane.SetActive(false);
        handItemPane.SetActive(false);
        feetItemPane.SetActive(false);
        bioneticItemPane.SetActive(false);
        enchantmentItemPane.SetActive(false);
        geneticItemPane.SetActive(false);
        cyberneticItemPane.SetActive(false);
    }

    private void OpenPaneFromItem(ItemType iType)
    {
        CloseAllPanes();
        switch (iType)
        {
            case ItemType.Weapon:
                weaponPane.SetActive(true);
                break;
            case ItemType.Skill:
                skillPane.SetActive(true);
                break;
            case ItemType.ItemHead:
                headItemPane.SetActive(true);
                break;
            case ItemType.ItemChest:
                chestItemPane.SetActive(true);
                break;
            case ItemType.ItemLegs:
                legItemPane.SetActive(true);
                break;
            case ItemType.ItemHands:
                handItemPane.SetActive(true);
                break;
            case ItemType.ItemFeet:
                feetItemPane.SetActive(true);
                break;
            case ItemType.Bionetic:
                bioneticItemPane.SetActive(true);
                break;
            case ItemType.Genetic:
                geneticItemPane.SetActive(true);
                break;
            case ItemType.Cybernetic:
                cyberneticItemPane.SetActive(true);
                break;
            case ItemType.Enchantment:
                enchantmentItemPane.SetActive(true);
                break;
        }
        UpdateEquippedItemDisplay();
    }
    private void UpdateEquippedItemDisplay()
    {
        InventoryItem itemInSlot = null;
        switch (selectedSlot.iType)
        {
            case ItemType.ItemHead:
                itemInSlot = inventory.headSlot;
                break;
            case ItemType.ItemChest:
                itemInSlot = inventory.chestSlot;
                break;
            case ItemType.ItemHands:
                itemInSlot = inventory.handSlot;
                break;
            case ItemType.ItemLegs:
                itemInSlot = inventory.legSlot;
                break;
            case ItemType.ItemFeet:
                itemInSlot = inventory.feetSlot;
                break;
            case ItemType.Bionetic:
                itemInSlot = inventory.modBionetic;
                break;
            case ItemType.Genetic:
                itemInSlot = inventory.modGenetic;
                break;
            case ItemType.Cybernetic:
                itemInSlot = inventory.modCybernetic;
                break;
            case ItemType.Enchantment:
                itemInSlot = inventory.modEnchantment;
                break;
            case ItemType.Weapon:
                if (selectedSlot.slot == ItemSlot.RWeap)
                {
                    itemInSlot = inventory.rHand;
                }
                else
                {
                    itemInSlot = inventory.lHand;
                }
                break;
        }
        if (itemInSlot != null)
        {
            equippedItemInfo.gameObject.SetActive(true);
            equippedItemInfo.UpdateInfo(itemInSlot);
        }
        else
        {
            equippedItemInfo.gameObject.SetActive(false);
        }
    }

    public Color GetEmissionColorByRarity(Quality quality)
    {
        switch (quality)
        {
            case Quality.Common:
                return commonEmissiveColour;
            case Quality.Uncommon:
                return uncommonEmissiveColour;
            case Quality.Masterwork:
                return masterworkEmissiveColour;
            case Quality.Rare:
                return rareEmissiveColour;
            case Quality.Legendary:
                return legendaryEmissiveColour;
            case Quality.Unique:
                return uniqueEmissiveColour;
            default:
                return baseEmissiveColour;
        }
    }
    public Color GetColorByRarity(Quality quality)
    {
        switch (quality)
        {
            case Quality.Common:
                return commonTextColour;
            case Quality.Uncommon:
                return uncommonTextColour;
            case Quality.Masterwork:
                return masterworkTextColour;
            case Quality.Rare:
                return rareTextColour;
            case Quality.Legendary:
                return legendaryTextColour;
            case Quality.Unique:
                return uniqueTextColour;
            default:
                return commonTextColour;
        }
    }
}