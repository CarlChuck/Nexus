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

    public List<Item> modBionetics = new List<Item>();
    public List<Item> modCybernetics = new List<Item>();
    public List<Item> modEnchantments = new List<Item>();
    public List<Item> modGenetics = new List<Item>();

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

    public BioneticMod modBionetic;
    public CyberneticMod modCybernetic;
    public EnchantmentMod modEnchantment;
    public GeneticMod modGenetic;


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
                Weapon weap = item as Weapon;
                weap.InitialiseWeapon();
                if (rHand == null)
                {


                    if (weap.wType == WeaponType.HPistol || weap.wType == WeaponType.PPistol || weap.wType == WeaponType.Wand)
                    {
                        rHand = weap;
                        item.AddStats(player);
                    }
                    else
                    {
                        Add(weap, weaponry);
                    }
                }
                else
                {
                    Add(weap, weaponry);
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
        if (item.CheckRequirements(player))
        {
            items.Add(item);
        }
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
        else if (item.itemType == ItemType.Cybernetic)
        {
            Add(item, modCybernetics);
        }
        else if (item.itemType == ItemType.Genetic)
        {
            Add(item, modGenetics);
        }
        else if (item.itemType == ItemType.Enchantment)
        {
            Add(item, modEnchantments);
        }
        else if (item.itemType == ItemType.Bionetic)
        {
            Add(item, modBionetics);
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
        else if (item.itemType == ItemType.Cybernetic)
        {
            Remove(item, modCybernetics);
        }
        else if (item.itemType == ItemType.Genetic)
        {
            Remove(item, modGenetics);
        }
        else if (item.itemType == ItemType.Enchantment)
        {
            Remove(item, modEnchantments);
        }
        else if (item.itemType == ItemType.Bionetic)
        {
            Remove(item, modBionetics);
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
    private void RemovemodCybernetic()
    {
        modCybernetic.RemoveStats(player);
        Add(modCybernetic);
        modCybernetic = null;
    }
    private void RemovemodEnchantment()
    {
        modEnchantment.RemoveStats(player);
        Add(modEnchantment);
        modEnchantment = null;
    }
    private void RemovemodGenetic()
    {
        modGenetic.RemoveStats(player);
        Add(modGenetic);
        modGenetic = null;
    }
    private void RemovemodBionetic()
    {
        modBionetic.RemoveStats(player);
        Add(modBionetic);
        modBionetic = null;
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
    public void AddWeapon(Weapon weapon, ItemSlot slot)
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
            case CharClass.Envoy:
                AddWeaponsEnvoy(weapon, slot);
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
    private void AddWeaponsGolemancer(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsElementalist(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsPsyc(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsMystic(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsArtificer(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsApoch(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsCrypter(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsNanoMage(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsEnvoy(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsVigil(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsShadow(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsStreetDoc(Weapon weapon, ItemSlot slot)
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
    private void AddWeaponsFinal(Weapon weapon, ItemSlot slot)
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
                Remove(weapon); //From Inventory
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
    public void AddModEnchantment(EnchantmentMod item)
    {
        if (modEnchantment != null)
        {
            RemoveEquipment(item.itemType);
        }
        modEnchantment = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddModGenetic(GeneticMod item)
    {
        if (modGenetic != null)
        {
            RemoveEquipment(item.itemType);
        }
        modGenetic = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddModCybernetic(CyberneticMod item)
    {
        if (modCybernetic != null)
        {
            RemoveEquipment(item.itemType);
        }
        modCybernetic = item;
        item.AddStats(player);
        Remove(item);
    }
    public void AddModBionetic(BioneticMod item)
    {
        if (modBionetic != null)
        {
            RemoveEquipment(item.itemType);
        }
        modBionetic = item;
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