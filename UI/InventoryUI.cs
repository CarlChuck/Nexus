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

    public InventoryObject invObject;

    public InfoPane equippedItemInfo;
    public InfoPane invItemInfo;

    public List<InventorySlot> invSlots;

    //Images for swapping into items
    public Sprite ItemBackCommon;
    public Sprite ItemBackUncommon;
    public Sprite ItemBackMasterwork;
    public Sprite ItemBackRare;
    public Sprite ItemBackLegendary;
    public Sprite ItemBackUnique;

    public Sprite DirectionalCommon;
    public Sprite DirectionalUncommon;
    public Sprite DirectionalMasterwork;
    public Sprite DirectionalRare;
    public Sprite DirectionalLegendary;
    public Sprite DirectionalUnique;

    public Color colourCommon;
    public Color colourUncommon;
    public Color colourMasterwork;
    public Color colourRare;
    public Color colourLegendary;
    public Color colourUnique;

    void Start ()
    {
        weaponManager = WeaponManager.instance;
        inventory = Inventory.instance;
        UpdateUI();
        CloseAllPanes();
        DontDestroyOnLoad(this);
    }	

    //Update UI from Inventory class
    public void UpdateUI()
    {    
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

        UpdatePanel(inventory.weaponry, weaponPane);
        UpdatePanel(inventory.headSlots, headItemPane);
        UpdatePanel(inventory.chestSlots, chestItemPane);
        UpdatePanel(inventory.legSlots, legItemPane);
        UpdatePanel(inventory.feetSlots, feetItemPane);
        UpdatePanel(inventory.handSlots, handItemPane);
        UpdatePanel(inventory.modBionetics, bioneticItemPane);
        UpdatePanel(inventory.modEnchantments, enchantmentItemPane);
        UpdatePanel(inventory.modGenetics, geneticItemPane);
        UpdatePanel(inventory.modCybernetics, cyberneticItemPane);
        UpdatePanel(inventory.skills, skillPane);


        weaponManager.UpdateWeapons();
        //UpdateIcons();
        Player player = Player.instance; 
        stats.UpdateAllStats(player);
    }

    public void UpdateFromSelectedSlot(InventorySlot slot)
    {
        selectedSlot = slot;
        OpenPaneFromItem(slot.iType);
    }
    //Update/Clear panels and slots
    void UpdatePanel(List<InventoryItem> items, GameObject pane)
    {
        Debug.Log("Updating Panel");
        foreach (InventoryItem item in items)
        {
            InventoryObject emptyItem = Instantiate(invObject);
            emptyItem.StartItem(item);
            emptyItem.transform.SetParent(pane.transform);
            emptyItem.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("Added" + emptyItem.name);
        }
    }

    void ClearPanel(GameObject panel)
    {
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    void CloseAllPanes()
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

    public void OpenPaneFromItem(ItemType iType) //TODO add others
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

    public void EquippedItemStats(InventoryItem item)
    {
        equippedItemInfo.UpdateInfo(item);
    }
    public void InvItemStats(InventoryItem item)
    {
        invItemInfo.UpdateInfo(item);
    }
    public void InvItemBlank()
    {
        invItemInfo.EmptyInfo();
    }
}