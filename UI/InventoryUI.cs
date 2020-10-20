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

    //selected inventory slot
    public InventorySlot selected;

    public InventoryObject invObject;

    public InfoPane equippedItemInfo;
    public InfoPane invItemInfo;

    //The inventory equip docks
    public InventorySlot weapon1;
    public InventorySlot weapon2;
    public InventorySlot headItem;
    public InventorySlot chestItem;
    public InventorySlot handItem;
    public InventorySlot legItem;
    public InventorySlot feetItem;
    public InventorySlot skill5;
    public InventorySlot skill6;
    public InventorySlot skill7;
    public InventorySlot skill8;
    public InventorySlot skill9;
    public InventorySlot skill10;
    public InventorySlot skill11;
    public InventorySlot skill12;
    public InventorySlot outfit;

    //Inventory item display icons
    public Image weapon1Icon;
    public Image weapon2Icon;
    public Image headItemIcon;
    public Image chestItemIcon;
    public Image handItemIcon;
    public Image feetItemIcon;
    public Image legItemIcon;
    public Image skill1Icon;
    public Image skill2Icon;
    public Image skill3Icon;
    public Image skill4Icon;
    public Image skill5Icon;
    public Image skill6Icon;
    public Image outfitIcon;

    void Start ()
    {
        weaponManager = WeaponManager.instance;
        inventory = Inventory.instance;
        UpdateUI();
        DontDestroyOnLoad(this);
        CloseAllPanes();
    }	

    //Update UI from Inventory class
    public void UpdateUI()
    {    
        ClearPanel(weaponPane);
        ClearPanel(headItemPane);
        ClearPanel(chestItemPane);
        ClearPanel(legItemPane);
        ClearPanel(skillPane);
        //TODO Add other updates
        UpdatePanel(inventory.weaponry, weaponPane);
        UpdatePanel(inventory.headSlots, headItemPane);
        UpdatePanel(inventory.chestSlots, chestItemPane);
        UpdatePanel(inventory.legSlots, legItemPane);
        UpdatePanel(inventory.skills, skillPane);

        UpdateSlot(inventory.rHand, weapon1);
        UpdateSlot(inventory.lHand, weapon2);
        UpdateSlot(inventory.headSlot, headItem);
        UpdateSlot(inventory.chestSlot, chestItem);
        UpdateSlot(inventory.legSlot, legItem);


        weaponManager.UpdateWeapons();
        UpdateIcons();
        Player player = Player.instance; 
        stats.UpdateAllStats(player);
    }

    //Update/Clear panels and slots
    void UpdatePanel(List<Item> items, GameObject pane)
    {
        foreach (Item item in items)
        {
            InventoryObject emptyItem = Instantiate(invObject);//Instantiate inventory object
            emptyItem.item = item;
            emptyItem.icon.sprite = item.icon;
            emptyItem.objectText.text = item.name;
            emptyItem.transform.SetParent(pane.transform);
            emptyItem.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void UpdateSlot(Item item, InventorySlot slot)
    {
        slot.UpdateItem(item);
    }
    void ClearSlot(InventorySlot slot)
    {
        slot.RemoveItem();
    }
    void ClearPanel(GameObject panel)
    {
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    void UpdateIcons() //TODO add additional updates
    {
        NullIcons();
        if (inventory.rHand != null)
        {
            weapon1Icon.gameObject.SetActive(true);
            weapon1Icon.sprite = inventory.rHand.icon;
        }
        if (inventory.lHand != null)
        {
            weapon2Icon.gameObject.SetActive(true);
            weapon2Icon.sprite = inventory.lHand.icon;
        }
        if (inventory.headSlot != null)
        {
            headItemIcon.gameObject.SetActive(true);
            headItemIcon.sprite = inventory.headSlot.icon;
        }
        if (inventory.chestSlot != null)
        {
            chestItemIcon.gameObject.SetActive(true);
            chestItemIcon.sprite = inventory.chestSlot.icon;
        }
        if (inventory.legSlot != null)
        {
            legItemIcon.gameObject.SetActive(true);
            legItemIcon.sprite = inventory.legSlot.icon;
        }
    }
    void NullIcons() //TODO add additional nulls
    {
        weapon1Icon.gameObject.SetActive(false);
        weapon2Icon.gameObject.SetActive(false);
        headItemIcon.gameObject.SetActive(false);
        chestItemIcon.gameObject.SetActive(false);
        legItemIcon.gameObject.SetActive(false);
        skill1Icon.gameObject.SetActive(false);
        skill2Icon.gameObject.SetActive(false);
        skill3Icon.gameObject.SetActive(false);
        skill4Icon.gameObject.SetActive(false);
        skill5Icon.gameObject.SetActive(false);
        skill6Icon.gameObject.SetActive(false);
        outfitIcon.gameObject.SetActive(false);
    }

    void CloseAllPanes() //TODO add panes
    {
        weaponPane.SetActive(false);
        skillPane.SetActive(false);
        headItemPane.SetActive(false);
        chestItemPane.SetActive(false);
        legItemPane.SetActive(false);
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
        }
    }

    public void EquippedItemStats(Item item)
    {
        equippedItemInfo.UpdateInfo(item);
    }
    public void InvItemStats(Item item)
    {
        invItemInfo.UpdateInfo(item);
    }
    public void InvItemBlank()
    {
        invItemInfo.EmptyInfo();
    }
}