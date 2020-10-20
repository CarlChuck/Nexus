using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystemManager : MonoBehaviour
{
    #region Singleton
    public static LootSystemManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    #region ItemLists
    public List<ItemHands> handItems;
    public List<ItemHead> headItems;
    public List<ItemChest> chestItems;
    public List<ItemFeet> feetItems;
    public List<ItemLegs> legItems;
    public List<ModDex> modDexItems;
    public List<ModStr> modStrItems;
    public List<ModSta> modStaItems;
    public List<ModHeal> modHealItems;
    public List<Weapon> weapons;
    public List<ElementalistSkill> elementalSkills;
    public List<GolemancerSkill> golemancerSkills;
    public List<PsionSkill> psionSkills;
    public List<MysticSkill> MysticSkills;
    public List<CrypterSkill> crypterSkills;
    public List<ApochSkill> apochSkills;
    public List<ArtificerSkill> artificerSkills;
    public List<NanoMageSkill> nanoMageSkills;
    public List<VigilSkill> vigilSkills;
    public List<ShadowSkill> shadowSkills;
    public List<EnvoySkill> envoySkills;
    public List<StreetDoctorSkill> streetDoctorSkills;
    #endregion

    #region Prefix/SuffixLists
    public List<Prefix> pList1;
    public List<Prefix> pList2;
    public List<Prefix> pList3;
    public List<Prefix> pList4;
    public List<Prefix> pList5;
    public List<Prefix> pList6;
    public List<Suffix> sList1;
    public List<Suffix> sList2;
    public List<Suffix> sList3;
    public List<Suffix> sList4;
    public List<Suffix> sList5;
    public List<Suffix> sList6;

    #endregion

    //current loot level This is set by area difficulty
    private int LootTier; // 1 to 3 based on D2 equivalent of normal, nightmare, hell difficulties

    //Loot distribution by difficulty
    [SerializeField] private int[] randomRangeDifficulty1 = { 2500, 500, 100, 10, 5};
    [SerializeField] private int[] randomRangeDifficulty2 = { 2500, 800, 150, 20, 10 };
    [SerializeField] private int[] randomRangeDifficulty3 = { 2500, 1200, 200, 40, 15 };
    [SerializeField] private int[] randomRangeDifficulty4 = { 2500, 1600, 300, 60, 20 };
    [SerializeField] private int[] randomRangeDifficulty5 = { 2500, 2000, 500, 100, 30 };
    [SerializeField] private int[] randomRangeDifficulty6 = { 2000, 2500, 800, 200, 50 };

    [SerializeField] private GameObject lootItemPrefab = default;

    private Quality DifficultyRandomResult(int[] rRange, int magicFind)
    {
        int uncommonChance = rRange[0];
        int masterworkChance = (rRange[1]/100) * magicFind ;
        int rareChance = (rRange[2]) * magicFind;
        int legendaryChance = (rRange[3]) * magicFind;
        int uniqueChance = (rRange[4]) * magicFind;
        int commonChance = Mathf.Clamp(10000 - (rRange[0] + rRange[1] + rRange[2] + rRange[3] + rRange[4]), 0, 10000);
        int[] finalRange = {commonChance, uncommonChance, masterworkChance, rareChance, legendaryChance, uniqueChance };
        int randomNumber = Random.Range(1, finalRange[5]+1);
        Quality qual = Quality.Common;
        if (randomNumber <= finalRange[0])
        {
            qual = Quality.Common;
        }
        else if (randomNumber > finalRange[0] && randomNumber <= finalRange[1])
        {
            qual = Quality.Uncommon;
        }
        else if (randomNumber > finalRange[1] && randomNumber <= finalRange[2])
        {
            qual = Quality.Masterwork;
        }
        else if (randomNumber > finalRange[2] && randomNumber <= finalRange[3])
        {
            qual = Quality.Rare;
        }
        else if (randomNumber > finalRange[3] && randomNumber <= finalRange[4])
        {
            qual = Quality.Legendary;
        }
        else
        {
            qual = Quality.Unique;
        }
        return qual;
    }
    private int LootItemTypeDifficulty()
    {
        int lootItemTypeDifficulty; //To be passed to the lootdifficultytier to item generation
        if (LootTier == 2)
        {
            int randomNumber = Random.Range(1, 101);
            if (randomNumber <= 85)
            {
                lootItemTypeDifficulty = 1;
            }
            else
            {
                lootItemTypeDifficulty = 2;
            }
        }
        else if (LootTier == 3)
        {
            int randomNumber = Random.Range(1, 101);
            if (randomNumber <= 60)
            {
                lootItemTypeDifficulty = 1;
            }
            else if (randomNumber > 60 && randomNumber <= 85)
            {
                lootItemTypeDifficulty = 2;
            }
            else
            {
                lootItemTypeDifficulty = 3;
            }
        }
        else
        {
            lootItemTypeDifficulty = 1;
        }

        return lootItemTypeDifficulty;
    }

    //Master method for dropping the loot
    public void DropLoot(int enemyRarity, Vector3 spawnPoint)
    {

        int lootNumber = 1; //number of items to drop
        
        List<Item> lootList = new List<Item>(); //List of items being generated randomly
        for (int i=1; i<=lootNumber; i++)
        {
            int randomNumber = Random.Range(1, 13); //number to choose item type (int max number is exclusive)
            if (randomNumber == 1)
            {
                //Skill
            }
            else if (randomNumber == 2)
            {
                //Mod
            }
            else if (randomNumber == 3)
            {
                //Armour
            }
            else if (randomNumber == 4)
            {
                //Weapon
                lootList.Add(SpawnWeapon());
            }
            else if (randomNumber == 1)
            {

            }
        }

        //Spawn the loot items in world
        foreach (Item item in lootList)
        {
            GameObject newLootItem = Instantiate(lootItemPrefab);
            newLootItem.GetComponent<LootItem>().ActivateLootItem(item, spawnPoint);
        }
    }

    public Weapon SpawnWeapon()
    {
        string prefix = "";
        string suffix = "";
        Weapon newWeapon = RandomiseWeapon();
        //RandomiseRarity(newWeapon);
        //newWeapon.damage = AddStatValueFifty(newWeapon);
        //GenerateStatsForItem(newWeapon, out newWeapon.description, out suffix);
        //GeneratePrefix(newWeapon, out prefix);
        newWeapon.name = prefix + newWeapon.name;
        return newWeapon;
    }
    public ItemChest SpawnItemChest()
    {
        string prefix = "";
        string suffix = "";
        ItemChest newItemChest = RandomiseChestItem();
        //RandomiseRarity(newItemChest);
        //GenerateStatsForItem(newItemChest, out newItemChest.description, out suffix);
        //GeneratePrefix(newItemChest, out prefix);
        newItemChest.name = prefix + newItemChest.name + " of " + suffix;
        return newItemChest;
    }

    //ONLY ELEMENTALIST SKILLS AT THE MOMENT
    #region Pull from Random Table
    //handItems
    public ItemHands RandomiseHandItem()
    {
        int randomNumber = Random.Range(0, handItems.Count + 1);
        ItemHands newItem;
        return newItem = Instantiate(handItems[randomNumber]);
    }

    //headItems
    public ItemHead RandomiseHeadItem()
    {
        int randomNumber = Random.Range(0, headItems.Count + 1);
        ItemHead newItem;
        return newItem = Instantiate(headItems[randomNumber]);
    }

    //chestItems
    public ItemChest RandomiseChestItem()
    {
        int randomNumber = Random.Range(0, chestItems.Count + 1);
        ItemChest newItem;
        return newItem = Instantiate(chestItems[randomNumber]);
    }

    //feetItems
    public ItemFeet RandomiseFeetItem()
    {
        int randomNumber = Random.Range(0, feetItems.Count + 1);
        ItemFeet newItem;
        return newItem = Instantiate(feetItems[randomNumber]);
    }

    //legItems
    public ItemLegs RandomiseLegItem()
    {
        int randomNumber = Random.Range(0, legItems.Count + 1);
        ItemLegs newItem;
        return newItem = Instantiate(legItems[randomNumber]);
    }

    //modDexItems
    public ModDex RandomiseModDex()
    {
        int randomNumber = Random.Range(0, modDexItems.Count + 1);
        ModDex newItem;
        return newItem = Instantiate(modDexItems[randomNumber]);
    }

    //modStrItems
    public ModStr RandomiseModStr()
    {
        int randomNumber = Random.Range(0, modStrItems.Count + 1);
        ModStr newItem;
        return newItem = Instantiate(modStrItems[randomNumber]);
    }

    //modStaItems
    public ModSta RandomiseModSta()
    {
        int randomNumber = Random.Range(0, modStaItems.Count + 1);
        ModSta newItem;
        return newItem = Instantiate(modStaItems[randomNumber]);
    }

    //modHealItems
    public ModHeal RandomiseModHeal()
    {
        int randomNumber = Random.Range(0, modHealItems.Count + 1);
        ModHeal newItem;
        return newItem = Instantiate(modHealItems[randomNumber]);
    }

    //weapons
    public Weapon RandomiseWeapon()
    {
        int randomNumber = Random.Range(0, weapons.Count + 1);
        Weapon newWeapon;
        return newWeapon = Instantiate(weapons[randomNumber]);
    }

    //Skills
    public Skill RandomiseSkill()
    {
        int randomNumber = Random.Range(1, 2);
        Skill newSkill;
        switch (randomNumber)
        {
            case 1:
                return newSkill = RandomElementalistSkill();
            default:
                return newSkill = RandomElementalistSkill();
        }
    }
    public Skill RandomElementalistSkill()
    {
        int randomNumber = Random.Range(0, elementalSkills.Count+1);
        ElementalistSkill newEleSkill;
        return newEleSkill = Instantiate(elementalSkills[randomNumber]);
    }
    #endregion
}
