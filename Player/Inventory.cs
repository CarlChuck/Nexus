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
    public List<Item> weaponry = new List<Item>();
    public List<Item> headSlots = new List<Item>();
    public List<Item> chestSlots = new List<Item>();
    public List<Item> legSlots = new List<Item>();
    public List<Item> handSlots = new List<Item>();
    public List<Item> feetSlots = new List<Item>();

    public List<Item> modHealSlots = new List<Item>();
    public List<Item> modDexSlots = new List<Item>();
    public List<Item> modStrSlots = new List<Item>();
    public List<Item> modStaSlots = new List<Item>();

    public List<Item> skills = new List<Item>();

    #endregion

    #region Equipped Slots
    //Equipped
    public Weapon rHand;
    public Weapon lHand;
    public ItemHead headSlot;
    public ItemChest chestSlot;
    public ItemHands handSlot;
    public ItemLegs legSlot;
    public ItemFeet feetSlot;

    public ModHeal modHealSlot;
    public ModDex modDexSlot;
    public ModStr modStrSlot;
    public ModSta modStaSlot;


    //***CLASS SPECIFIC AREA***
    //Golemancer Skills

    //Elementalist Skills
    public ElementalistSkill eleSkill1;
    public ElementalistSkill eleSkill2;
    public ElementalistEliteSkill eleEliteSkill;
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
    public List<Item> startItems;

    private Player player;
    public InventoryUI invUI;
    #endregion

    private void Start()
    {
        ClosePanel(inventoryPane);
        player = Player.instance;

        //add start gear
        AddStartItems(startItems);

        DontDestroyOnLoad(gameObject);
    }

    private void AddStartItems(List<Item> startItems)
    {
        foreach (Item item in startItems)
        {
            PickUpItem(item);
        }
    }

    #region PICKUP ITEM
    public void PickUpItem(Item item)
    {
        switch (item.itemType)
        {
            case ItemType.ItemHead:
                if (headSlot == null)
                {
                    headSlot = item as ItemHead;
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
                    chestSlot = item as ItemChest;
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
                    legSlot = item as ItemLegs;
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
                    handSlot = item as ItemHands;
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
                    feetSlot = item as ItemFeet;
                    item.AddStats(player);
                }
                else
                {
                    Add(item, feetSlots);
                }
                break;
            case ItemType.Skill:
                Add(item, skills);
                break;
            case ItemType.Weapon:
                if (rHand == null)
                {
                    Weapon weap = item as Weapon;
                    if (weap.wType == WeaponType.HPistol || weap.wType == WeaponType.PPistol || weap.wType == WeaponType.Wand)
                    {
                        rHand = weap;
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
    private void Add(Item item, List<Item> items)
    {
        items.Add(item);
    }
    public void Add(Item item)
    {
        if (item.itemType == ItemType.ItemHead)
        {
            Add(item, headSlots);
        }
        else if (item.itemType == ItemType.ItemChest)
        {
            Add(item, chestSlots);
        }
        else if (item.itemType == ItemType.ItemLegs)
        {
            Add(item, legSlots);
        }
        else if (item.itemType == ItemType.ItemHands)
        {
            Add(item, handSlots);
        }
        else if (item.itemType == ItemType.ItemFeet)
        {
            Add(item, feetSlots);
        }
        else if (item.itemType == ItemType.ModDex)
        {
            Add(item, modDexSlots);
        }
        else if (item.itemType == ItemType.ModSta)
        {
            Add(item, modStaSlots);
        }
        else if (item.itemType == ItemType.ModStr)
        {
            Add(item, modStrSlots);
        }
        else if (item.itemType == ItemType.ModHeal)
        {
            Add(item, modHealSlots);
        }
        else if (item.itemType == ItemType.Skill)
        {
            Add(item, skills);
        }
        else if (item.itemType == ItemType.Weapon)
        {
            Add(item, weaponry);
        }
        invUI.UpdateUI();
    }
    private void Remove(Item item, List<Item> items)
    {
        items.Remove(item);
    }
    public void Remove(Item item)
    {
        if (item.itemType == ItemType.ItemHead)
        {
            Remove(item, headSlots);
        }
        else if (item.itemType == ItemType.ItemChest)
        {
            Remove(item, chestSlots);
        }
        else if (item.itemType == ItemType.ItemLegs)
        {
            Remove(item, legSlots);
        }
        else if (item.itemType == ItemType.ItemHands)
        {
            Remove(item, handSlots);
        }
        else if (item.itemType == ItemType.ItemFeet)
        {
            Remove(item, feetSlots);
        }
        else if (item.itemType == ItemType.ModDex)
        {
            Remove(item, modDexSlots);
        }
        else if (item.itemType == ItemType.ModSta)
        {
            Remove(item, modStaSlots);
        }
        else if (item.itemType == ItemType.ModStr)
        {
            Remove(item, modStrSlots);
        }
        else if (item.itemType == ItemType.ModHeal)
        {
            Remove(item, modHealSlots);
        }
        else if (item.itemType == ItemType.Skill)
        {
            Remove(item, skills);
        }
        else if (item.itemType == ItemType.Weapon)
        {
            Remove(item, weaponry);
        }
        invUI.UpdateUI();
    }
    #endregion

    #region Move From Equipped To Inventory
    //functions to call whatever is in an equipped slot and move it to the inventory
    private void RemoveRH()
    {
        rHand.RemoveStats(player);
        Add(rHand);
        rHand = null;
    }
    private void RemoveLH()
    {
        lHand.RemoveStats(player);
        Add(lHand);
        lHand = null;
    }
    private void RemoveHeadlot()
    {
        headSlot.RemoveStats(player);
        Add(headSlot);
        headSlot = null;
    }   
    private void RemoveChestSlot()
    {
        chestSlot.RemoveStats(player);
        Add(chestSlot);
        chestSlot = null;
    }
    private void RemoveLegSlot()
    {
        legSlot.RemoveStats(player);
        Add(legSlot);
        legSlot = null;
    }
    private void RemoveHandSlot()
    {
        handSlot.RemoveStats(player);
        Add(handSlot);
        handSlot = null;
    }
    private void RemoveFeetSlot()
    {
        feetSlot.RemoveStats(player);
        Add(feetSlot);
        feetSlot = null;
    }
    private void RemoveModDexSlot()
    {
        modDexSlot.RemoveStats(player);
        Add(modDexSlot);
        modDexSlot = null;
    }
    private void RemoveModStrSlot()
    {
        modStrSlot.RemoveStats(player);
        Add(modStrSlot);
        modStrSlot = null;
    }
    private void RemoveModStaSlot()
    {
        modStaSlot.RemoveStats(player);
        Add(modStaSlot);
        modStaSlot = null;
    }
    private void RemoveModHealSlot()
    {
        modHealSlot.RemoveStats(player);
        Add(modHealSlot);
        modHealSlot = null;
    }
    private void RemoveElementalistSkill1()
    {
        eleSkill1.RemoveStats(player);
        Add(eleSkill1);
        eleSkill1 = null;
    }
    private void RemoveElementalistSkill2()
    {
        eleSkill2.RemoveStats(player);
        Add(eleSkill2);
        eleSkill2 = null;
    }
    private void RemoveElementalistEliteSkill()
    {
        eleEliteSkill.RemoveStats(player);
        Add(eleEliteSkill);
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
                if (legSlot != null)
                {
                    RemoveFeetSlot();
                }
                break;
            case ItemType.ItemHands:
                if (legSlot != null)
                {
                    RemoveHandSlot();
                }
                break;
            case ItemType.ModDex:
                if (legSlot != null)
                {
                    RemoveModDexSlot();
                }
                break;
            case ItemType.ModSta:
                if (legSlot != null)
                {
                    RemoveModStaSlot();
                }
                break;
            case ItemType.ModStr:
                if (legSlot != null)
                {
                    RemoveModStrSlot();
                }
                break;
            case ItemType.ModHeal:
                if (legSlot != null)
                {
                    RemoveModHealSlot();
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
    public void AddWeapon(Weapon weapon, int slotNumber)
    {
        switch (player.cClass)
        {
            case CharClass.Golemancer:
                AddWeaponsGolemancer(weapon, slotNumber);
                break;
            case CharClass.Elementalist:
                AddWeaponsElementalist(weapon, slotNumber);
                break;
            case CharClass.Psyc:
                AddWeaponsPsyc(weapon, slotNumber);
                break;
            case CharClass.Mystic:
                AddWeaponsMystic(weapon, slotNumber);
                break;
            case CharClass.Artificer:
                AddWeaponsArtificer(weapon, slotNumber);
                break;
            case CharClass.Apoch:
                AddWeaponsApoch(weapon, slotNumber);
                break;
            case CharClass.Crypter:
                AddWeaponsCrypter(weapon, slotNumber);
                break;
            case CharClass.NanoMage:
                AddWeaponsNanoMage(weapon, slotNumber);
                break;
            case CharClass.Envoy:
                AddWeaponsEnvoy(weapon, slotNumber);
                break;
            case CharClass.Vigil:
                AddWeaponsVigil(weapon, slotNumber);
                break;
            case CharClass.Shadow:
                AddWeaponsShadow(weapon, slotNumber);
                break;
            case CharClass.StreetDoctor:
                AddWeaponsStreetDoc(weapon, slotNumber);
                break;
        }
    }
    private void AddWeaponsGolemancer(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.Wand || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.Shield || weapon.wType == WeaponType.Foci || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsElementalist(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Wand)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Wand || weapon.wType == WeaponType.Foci)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsPsyc(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Wand || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Wand || weapon.wType == WeaponType.Foci || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsMystic(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.Wand || weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.Shield || weapon.wType == WeaponType.Foci || weapon.wType == WeaponType.Staff)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsArtificer(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.GravGun)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.Launcher || weapon.wType == WeaponType.Shield ||  weapon.wType == WeaponType.GravGun)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsApoch(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.GravGun)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.GravGun)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsCrypter(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.GravGun || weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Melee)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.GravGun || weapon.wType == WeaponType.PPistol)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsNanoMage(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.GravGun || weapon.wType == WeaponType.Rifle || weapon.wType == WeaponType.HPistol)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.GravGun || weapon.wType == WeaponType.Rifle)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsEnvoy(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Rifle)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Shield || weapon.wType == WeaponType.Rifle || weapon.wType == WeaponType.Launcher)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsVigil(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.Rifle)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Carbine || weapon.wType == WeaponType.Rifle || weapon.wType == WeaponType.Launcher)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsShadow(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Rifle)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.PPistol || weapon.wType == WeaponType.Rifle || weapon.wType == WeaponType.HPistol)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsStreetDoc(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
        {
            if (weapon.wType == WeaponType.Melee || weapon.wType == WeaponType.HPistol || weapon.wType == WeaponType.Carbine)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
        else if (slotNumber == 2)
        {
            if (weapon.wType == WeaponType.NanoGlove || weapon.wType == WeaponType.Launcher || weapon.wType == WeaponType.Carbine)
            {
                AddWeaponsFinal(weapon, slotNumber);
            }
        }
    }
    private void AddWeaponsFinal(Weapon weapon, int slotNumber)
    {
        if (slotNumber == 1)
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
                Remove(weapon); //From Inventory
            }

        }
        else if (slotNumber == 2)
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
            Remove(weapon); //From Inventory
        }
        UpdateIdleAnimation();
    }

    public void AddHeadSlot(ItemHead item)
    {
        if (headSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        headSlot = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddChestSlot(ItemChest item)
    {
        if (chestSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        chestSlot = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddLegSlot(ItemLegs item)
    {
        if (legSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        legSlot = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddHandSlot(ItemHands item)
    {
        if (handSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        handSlot = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddFeetSlot(ItemFeet item)
    {
        if (feetSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        feetSlot = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddModStrSlot(ModStr item)
    {
        if (modStrSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        modStrSlot = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddModStaSlot(ModSta item)
    {
        if (modStaSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        modStaSlot = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddModDexSlot(ModDex item)
    {
        if (modDexSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        modDexSlot = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddModHeallot(ModHeal item)
    {
        if (modHealSlot != null)
        {
            RemoveEquipment(item.itemType);
        }
        modHealSlot = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddElementalistSkill(ElementalistSkill skill, int slotNumber)
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
    public void AddElementalistEliteSkill(ElementalistEliteSkill skill)
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