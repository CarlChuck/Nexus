using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    #region In Bag Lists
    //Actual 'database' of equipment to aid saving
    //Inventory
    public List<InventoryItem> weaponry = new List<InventoryItem>();
    public List<InventoryItem> headSlots = new List<InventoryItem>();
    public List<InventoryItem> chestSlots = new List<InventoryItem>();
    public List<InventoryItem> legSlots = new List<InventoryItem>();
    public List<InventoryItem> handSlots = new List<InventoryItem>();
    public List<InventoryItem> feetSlots = new List<InventoryItem>();

    public List<InventoryItem> modBionetics = new List<InventoryItem>();
    public List<InventoryItem> modCybernetics = new List<InventoryItem>();
    public List<InventoryItem> modEnchantments = new List<InventoryItem>();
    public List<InventoryItem> modGenetics = new List<InventoryItem>();

    public List<InventoryItem> skills = new List<InventoryItem>();

    #endregion

    #region Equipped Slots
    //Equipped
    public InventoryItem rHand;
    public InventoryItem lHand;
    public InventoryItem headSlot;
    public InventoryItem chestSlot;
    public InventoryItem handSlot;
    public InventoryItem legSlot;
    public InventoryItem feetSlot;

    public InventoryItem modBionetic;
    public InventoryItem modCybernetic;
    public InventoryItem modEnchantment;
    public InventoryItem modGenetic;


    //***CLASS SPECIFIC AREA***
    //Golemancer Skills

    //Elementalist Skills
    public InventoryItem eleSkill1;
    public InventoryItem eleSkill2;
    public InventoryItem eleEliteSkill;
    //Psyc Skills

    //Mystic Skills

    //Artificer Skills

    //Apoch Skills

    //Crypter Skills

    //Nano Mage Skills

    //Envoy Skills

    //Vigil Skills

    //Shadow Skills

    //Street Doc Skills

    #endregion

    #region References
    bool invActive = false;

    //The Inventory UI
    public GameObject inventoryPane;
    public Button defaultButton;

    //Starting gear
    public List<InventoryItem> startItems;

    private Player player;
    public InventoryUI invUI;
    #endregion

    private void Start()
    {
        DontDestroyOnLoad(this);
        ClosePanel(inventoryPane);
        player = Player.instance;

        //add start gear
        AddStartItems(startItems);
    }

    private void AddStartItems(List<InventoryItem> startItems)
    {
        foreach (InventoryItem item in startItems)
        {
            item.BuildInventoryItem(item.baseItem, item.baseItem.quality);
            PickUpItem(item);
        }
    }

    #region PICKUP ITEM
    public void PickUpItem(InventoryItem item)
    {
        switch (item.itemType)
        {
            case ItemType.ItemHead:
                if (headSlot == null)
                {
                    headSlot = item;
                    item.AddStats(player);
                }
                else
                {
                    Add(item, headSlots);
                }
                break;
            case ItemType.ItemChest:
                if (chestSlot == null)
                {
                    chestSlot = item;
                    item.AddStats(player);
                }
                else
                {
                    Add(item, chestSlots);
                }
                break;
            case ItemType.ItemLegs:
                if (legSlot == null)
                {
                    legSlot = item;
                    item.AddStats(player);
                }
                else
                {
                    Add(item, legSlots);
                }
                break;
            case ItemType.ItemHands:
                if (handSlot == null)
                {
                    handSlot = item;
                    item.AddStats(player);
                }
                else
                {
                    Add(item, handSlots);
                }
                break;
            case ItemType.ItemFeet:
                if (feetSlot == null)
                {
                    feetSlot = item;
                    item.AddStats(player);
                }
                else
                {
                    Add(item, feetSlots);
                }
                break;
            case ItemType.Bionetic:
                if (modBionetic == null)
                {
                    modBionetic = item;
                    item.AddStats(player);
                }
                else
                {
                    Add(item, modBionetics);
                }
                break;
            case ItemType.Cybernetic:
                if (modCybernetic == null)
                {
                    modCybernetic = item;
                    item.AddStats(player);
                }
                else
                {
                    Add(item, modCybernetics);
                }
                break;
            case ItemType.Genetic:
                if (modGenetic == null)
                {
                    modGenetic = item;
                    item.AddStats(player);
                }
                else
                {
                    Add(item, modGenetics);
                }
                break;
            case ItemType.Enchantment:
                if (modEnchantment == null)
                {
                    modEnchantment = item;
                    item.AddStats(player);
                }
                else
                {
                    Add(item, modEnchantments);
                }
                break;
            case ItemType.Skill:

                Add(item, skills);
                break;
            case ItemType.Weapon:
                if (rHand == null)
                {
                    if (item.wType == WeaponType.HPistol || item.wType == WeaponType.PPistol || item.wType == WeaponType.Wand)
                    {
                        rHand = item;
                        item.AddStats(player);
                    }
                    else
                    {
                        Add(item, weaponry);
                    }
                }
                else
                {
                    Add(item, weaponry);
                }
                break;
            default:
                break;
        }
        invUI.UpdateUI();
        UpdateIdleAnimation();
    }
    #endregion

    #region Base add/removes
    private void Add(InventoryItem item, List<InventoryItem> items)
    {
        if (item.CheckRequirements(player))
        {
            if (item.itemType == ItemType.ItemHead)
            {
                headSlots.Add(item);
            }
            else if (item.itemType == ItemType.ItemChest)
            {
                chestSlots.Add(item);
            }
            else if (item.itemType == ItemType.ItemLegs)
            {
                legSlots.Add(item);
            }
            else if (item.itemType == ItemType.ItemHands)
            {
                handSlots.Add(item);
            }
            else if (item.itemType == ItemType.ItemFeet)
            {
                feetSlots.Add(item);
            }
            else if (item.itemType == ItemType.Cybernetic)
            {
                modCybernetics.Add(item);
            }
            else if (item.itemType == ItemType.Genetic)
            {
                modGenetics.Add(item);
            }
            else if (item.itemType == ItemType.Enchantment)
            {
                modEnchantments.Add(item);
            }
            else if (item.itemType == ItemType.Bionetic)
            {
                modBionetics.Add(item);
            }
            else if (item.itemType == ItemType.Skill)
            {
                skills.Add(item);
            }
            else if (item.itemType == ItemType.Weapon)
            {
                weaponry.Add(item);
            }
        }
        invUI.UpdateUI();
    }
    private void Remove(InventoryItem item, List<InventoryItem> items)
    {
        if (item.itemType == ItemType.ItemHead)
        {
            headSlots.Remove(item);
        }
        else if (item.itemType == ItemType.ItemChest)
        {
            chestSlots.Remove(item);
        }
        else if (item.itemType == ItemType.ItemLegs)
        {
            legSlots.Remove(item);
        }
        else if (item.itemType == ItemType.ItemHands)
        {
            handSlots.Remove(item);
        }
        else if (item.itemType == ItemType.ItemFeet)
        {
            feetSlots.Remove(item);
        }
        else if (item.itemType == ItemType.Cybernetic)
        {
            modCybernetics.Remove(item);
        }
        else if (item.itemType == ItemType.Genetic)
        {
            modGenetics.Remove(item);
        }
        else if (item.itemType == ItemType.Enchantment)
        {
            modEnchantments.Remove(item);
        }
        else if (item.itemType == ItemType.Bionetic)
        {
            modBionetics.Remove(item);
        }
        else if (item.itemType == ItemType.Skill)
        {
            skills.Remove(item);
        }
        else if (item.itemType == ItemType.Weapon)
        {
            weaponry.Remove(item);
        }
        invUI.UpdateUI();
    }
    #endregion

    #region Move From Equipped To Inventory
    //functions to call whatever is in an equipped slot and move it to the inventory
    private void RemoveRH()
    {
        rHand.RemoveStats(player);
        Add(rHand, weaponry);
        rHand = null;
    }
    private void RemoveLH()
    {
        lHand.RemoveStats(player);
        Add(lHand, weaponry);
        lHand = null;
    }
    private void RemoveHeadlot()
    {
        headSlot.RemoveStats(player);
        Add(headSlot, headSlots);
        headSlot = null;
    }   
    private void RemoveChestSlot()
    {
        chestSlot.RemoveStats(player);
        Add(chestSlot, chestSlots);
        chestSlot = null;
    }
    private void RemoveLegSlot()
    {
        legSlot.RemoveStats(player);
        Add(legSlot, legSlots);
        legSlot = null;
    }
    private void RemoveHandSlot()
    {
        handSlot.RemoveStats(player);
        Add(handSlot, handSlots);
        handSlot = null;
    }
    private void RemoveFeetSlot()
    {
        feetSlot.RemoveStats(player);
        Add(feetSlot, feetSlots);
        feetSlot = null;
    }
    private void RemovemodCybernetic()
    {
        modCybernetic.RemoveStats(player);
        Add(modCybernetic, modCybernetics);
        modCybernetic = null;
    }
    private void RemovemodEnchantment()
    {
        modEnchantment.RemoveStats(player);
        Add(modEnchantment, modEnchantments);
        modEnchantment = null;
    }
    private void RemovemodGenetic()
    {
        modGenetic.RemoveStats(player);
        Add(modGenetic, modGenetics);
        modGenetic = null;
    }
    private void RemovemodBionetic()
    {
        modBionetic.RemoveStats(player);
        Add(modBionetic, modBionetics);
        modBionetic = null;
    }
    private void RemoveElementalistSkill1()
    {
        eleSkill1.RemoveStats(player);
        Add(eleSkill1, skills);
        eleSkill1 = null;
    }
    private void RemoveElementalistSkill2()
    {
        eleSkill2.RemoveStats(player);
        Add(eleSkill2, skills);
        eleSkill2 = null;
    }
    private void RemoveElementalistEliteSkill()
    {
        eleEliteSkill.RemoveStats(player);
        Add(eleEliteSkill, skills);
        eleEliteSkill = null;
    }

    //functions to call moving equipped to inventory from outside of class
    public void RemoveWeapon(int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (rHand != null)
            {
                RemoveRH();
            }
        }
        else if (slotNumber == 2)
        {
            if (lHand != null)
            {
                RemoveLH();
            }
        }
    }
    public void RemoveEquipment(ItemType slotType)
    {
        switch (slotType)
        {
            case ItemType.ItemHead:
                if(headSlot != null)
                {
                    RemoveHeadlot();
                }
                break;
            case ItemType.ItemChest:
                if (chestSlot != null)
                {
                    RemoveChestSlot();
                }
                break;
            case ItemType.ItemLegs:
                if (legSlot != null)
                {
                    RemoveLegSlot();
                }
                break;
            case ItemType.ItemFeet:
                if (feetSlot != null)
                {
                    RemoveFeetSlot();
                }
                break;
            case ItemType.ItemHands:
                if (handSlot != null)
                {
                    RemoveHandSlot();
                }
                break;
            case ItemType.Cybernetic:
                if (modCybernetic != null)
                {
                    RemovemodCybernetic();
                }
                break;
            case ItemType.Genetic:
                if (modGenetic != null)
                {
                    RemovemodGenetic();
                }
                break;
            case ItemType.Enchantment:
                if (modEnchantment != null)
                {
                    RemovemodEnchantment();
                }
                break;
            case ItemType.Bionetic:
                if (modBionetic != null)
                {
                    RemovemodBionetic();
                }
                break;
            default:
                break;           
        }
    }    
    public void RemoveEleSkill(int slotNumber)
    {
        switch (slotNumber)
        {
            case 1:
                if (eleSkill1 != null)
                {
                    RemoveElementalistSkill1();
                }
                break;
            case 2:
                if (eleSkill2 != null)
                {
                    RemoveElementalistSkill2();
                }
                break;
            case 3:
                if (eleEliteSkill != null)
                {
                    RemoveElementalistEliteSkill();
                }
                break;
        }
    }

    #endregion

    #region Move From Inventory to Equipment Slot
    //functions to call moving from inventory to equipslot from outside class and removes existing item in slot back to inventory

    public void AddWeapon(InventoryItem weapon, ItemSlot slot)
    {
        switch (player.cClass)
        {
            case CharClass.Golemancer:
                AddWeaponsGolemancer(weapon, slot);
                break;
            case CharClass.Elementalist:
                AddWeaponsElementalist(weapon, slot);
                break;
            case CharClass.Psyc:
                AddWeaponsPsyc(weapon, slot);
                break;
            case CharClass.Mystic:
                AddWeaponsMystic(weapon, slot);
                break;
            case CharClass.Artificer:
                AddWeaponsArtificer(weapon, slot);
                break;
            case CharClass.Apoch:
                AddWeaponsApoch(weapon, slot);
                break;
            case CharClass.Crypter:
                AddWeaponsCrypter(weapon, slot);
                break;
            case CharClass.NanoMage:
                AddWeaponsNanoMage(weapon, slot);
                break;
            case CharClass.Guardian:
                AddWeaponsGuardian(weapon, slot);
                break;
            case CharClass.Vigil:
                AddWeaponsVigil(weapon, slot);
                break;
            case CharClass.Shadow:
                AddWeaponsShadow(weapon, slot);
                break;
            case CharClass.StreetDoctor:
                AddWeaponsStreetDoc(weapon, slot);
                break;
        }
    }
    private void AddWeaponsGolemancer(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.Wand || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.Shield || weapon.wType == WeaponType.Foci || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsElementalist(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Wand)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Wand || weapon.wType == WeaponType.Foci)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsPsyc(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Wand || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Wand || weapon.wType == WeaponType.Foci || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsMystic(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.Wand || weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.Shield || weapon.wType == WeaponType.Foci || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsArtificer(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.GravGun)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.Launcher || weapon.wType == WeaponType.Shield ||  weapon.wType == WeaponType.GravGun)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsApoch(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.GravGun)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.GravGun)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsCrypter(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.GravGun || weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Melee)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.GravGun || weapon.wType == WeaponType.PPistol)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsNanoMage(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.GravGun || weapon.wType == WeaponType.Rifle || weapon.wType == WeaponType.HPistol)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.GravGun || weapon.wType == WeaponType.Rifle)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsGuardian(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Rifle)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Shield || weapon.wType == WeaponType.Rifle || weapon.wType == WeaponType.Launcher)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsVigil(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.Rifle)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.Rifle || weapon.wType == WeaponType.Launcher)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsShadow(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Rifle)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Rifle || weapon.wType == WeaponType.HPistol)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsStreetDoc(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Carbine)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
        else if (slot == ItemSlot.LWeap)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.Launcher || weapon.wType == WeaponType.Carbine)
            {
                AddWeaponsFinal(weapon, slot);
            }
        }
    }
    private void AddWeaponsFinal(InventoryItem weapon, ItemSlot slot)
    {
        if (slot == ItemSlot.RWeap)
        {
            if (weapon.handedness != Handed.LeftOnly)
            {
                if (rHand != null)
                {
                    RemoveWeapon(1); //From Right Hand
                }
                if (lHand != null)
                {
                    if (lHand.handedness == Handed.TwoHanded || weapon.handedness == Handed.TwoHanded)
                    {
                        RemoveWeapon(2); //From Left Hand
                    }
                }
                rHand = weapon; //Add weapon to Right Hand

                weapon.AddStats(player);
                Remove(weapon, weaponry); //From Inventory
            }

        }
        else if (slot == ItemSlot.LWeap)
        {
            if (lHand != null)
            {
                RemoveWeapon(2); //From Left Hand
            }
            if (rHand != null)
            {
                if (rHand.handedness == Handed.TwoHanded || weapon.handedness == Handed.TwoHanded)
                {
                    RemoveWeapon(1); //From Right Hand
                }
            }
            if (weapon.handedness == Handed.TwoHanded)
            {
                rHand = weapon; //Two Hander always goes in Right

            }
            else
            {
                lHand = weapon; //Add weapon to Left Hand

            }
            weapon.AddStats(player);
            Remove(weapon, weaponry); //From Inventory
        }
        UpdateIdleAnimation();
    }

    public void AddHeadSlot(InventoryItem item)
    {
        if (headSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        headSlot = item;
        item.AddStats(player);
        Remove(item, headSlots);
    }
    public void AddChestSlot(InventoryItem item)
    {
        if (chestSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        chestSlot = item;
        item.AddStats(player);
        Remove(item, chestSlots);
    }
    public void AddLegSlot(InventoryItem item)
    {
        if (legSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        legSlot = item;
        item.AddStats(player);
        Remove(item, legSlots);
    }
    public void AddHandSlot(InventoryItem item)
    {
        if (handSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        handSlot = item;
        item.AddStats(player);
        Remove(item, handSlots);
    }
    public void AddFeetSlot(InventoryItem item)
    {
        if (feetSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        feetSlot = item;
        item.AddStats(player);
        Remove(item, feetSlots);
    }
    public void AddModEnchantment(InventoryItem item)
    {
        if (modEnchantment != null)
        {
            RemoveEquipment(item.itemType);
        }
        modEnchantment = item;
        item.AddStats(player);
        Remove(item, modEnchantments);
    }
    public void AddModGenetic(InventoryItem item)
    {
        if (modGenetic != null)
        {
            RemoveEquipment(item.itemType);
        }
        modGenetic = item;
        item.AddStats(player);
        Remove(item, modGenetics);
    }
    public void AddModCybernetic(InventoryItem item)
    {
        if (modCybernetic != null)
        {
            RemoveEquipment(item.itemType);
        }
        modCybernetic = item;
        item.AddStats(player);
        Remove(item, modCybernetics);
    }
    public void AddModBionetic(InventoryItem item)
    {
        if (modBionetic != null)
        {
            RemoveEquipment(item.itemType);
        }
        modBionetic = item;
        item.AddStats(player);
        Remove(item, modBionetics);
    }
    public void AddElementalistSkill(InventoryItem skill, int slotNumber)
    {
        switch (slotNumber)
        {
            case 1:
                if (eleSkill1 != null)
                {
                    RemoveElementalistSkill1();
                }
                eleSkill1 = skill;
                break;
            case 2:
                if (eleSkill2 != null)
                {
                    RemoveElementalistSkill2();
                }
                eleSkill2 = skill;
                break;
        }
    }
    public void AddElementalistEliteSkill(InventoryItem skill)
    {
        if (eleEliteSkill != null)
        {
            RemoveElementalistEliteSkill();
        }
        eleEliteSkill = skill;
    }


    #endregion

    //Update Animation Idle Root
    private void UpdateIdleAnimation()
    {
        Animator pAnim = Player.instance.anim;
        Player.instance.rhIK.data.targetPositionWeight = 0f;
        Player.instance.lhIK.data.targetPositionWeight = 0f;
        pAnim.SetBool("PistolREquipped", false);
        pAnim.SetBool("PistolLEquipped", false);
        pAnim.SetBool("RifleEquipped", false);
        pAnim.SetBool("StaffEquipped", false);
        pAnim.SetBool("NanoREquipped", false);
        pAnim.SetBool("NanoLEquipped", false);
        pAnim.SetBool("WandREquipped", false);
        pAnim.SetBool("WandLEquipped", false);
        pAnim.SetBool("MeleeREquipped", false);
        pAnim.SetBool("MeleeLEquipped", false);
        pAnim.SetBool("ShieldEquipped", false);
        pAnim.SetBool("FociEquipped", false);

        if (rHand != null)
        {
            switch (rHand.wType)
            {
                case WeaponType.Carbine:
                    Player.instance.rhIK.data.targetPositionWeight = 1f;
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("RifleEquipped", true);
                    break;
                case WeaponType.Rifle:
                    Player.instance.rhIK.data.targetPositionWeight = 1f;
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("RifleEquipped", true);
                    break;
                case WeaponType.GravGun:
                    Player.instance.rhIK.data.targetPositionWeight = 1f;
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("RifleEquipped", true);
                    break;
                case WeaponType.HPistol:
                    Player.instance.rhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("PistolREquipped", true);
                    break;
                case WeaponType.Melee:
                    Player.instance.rhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("MeleeREquipped", true);
                    break;
                case WeaponType.NanoGlove:
                    Player.instance.rhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("NanoREquipped", true);
                    break;
                case WeaponType.PPistol:
                    Player.instance.rhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("PistolREquipped", true);
                    break;
                case WeaponType.Staff:
                    Player.instance.rhIK.data.targetPositionWeight = 1f;
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("StaffEquipped", true);
                    break;
                case WeaponType.Wand:
                    Player.instance.rhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("WandREquipped", true);
                    break;
                default:
                    break;
            }
        }
        if (lHand != null)
        {
            switch (lHand.wType)
            {
                case WeaponType.Launcher:
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("PistolLEquipped", true);
                    break;
                case WeaponType.Foci:
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("FociEquipped", true);
                    break;
                case WeaponType.Shield:
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("ShieldEquipped", true);
                    break;
                case WeaponType.HPistol:
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("PistolLEquipped", true);
                    break;
                case WeaponType.Melee:
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("MeleeLEquipped", true);
                    break;
                case WeaponType.NanoGlove:
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("NanoLEquipped", true);
                    break;
                case WeaponType.PPistol:
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("PistolLEquipped", true);
                    break;
                case WeaponType.Wand:
                    Player.instance.lhIK.data.targetPositionWeight = 1f;
                    pAnim.SetBool("WandLEquipped", true);
                    break;
                default:
                    break;
            }
        }
    }

    #region On Open Inventory
    //open/close a panel in UI
    public void OnInventoryPressed()
    {
        invActive = !invActive;
        inventoryPane.SetActive(invActive);
        player.inventoryOpen = !player.inventoryOpen;
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    #endregion
}