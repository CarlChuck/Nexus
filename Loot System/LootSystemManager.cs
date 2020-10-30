using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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

    #region ItemLists T1
    public List<ItemHands> handItems1;
    public List<ItemHead> headItems1;
    public List<ItemChest> chestItems1;
    public List<ItemFeet> feetItems1;
    public List<ItemLegs> legItems1;
    public List<ModDex> modDexItems1;
    public List<ModStr> modStrItems1;
    public List<ModSta> modStaItems1;
    public List<ModHeal> modHealItems1;
    public List<Weapon> weapons1;
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

    #region ItemLists T2
    public List<ItemHands> handItems2;
    public List<ItemHead> headItems2;
    public List<ItemChest> chestItems2;
    public List<ItemFeet> feetItems2;
    public List<ItemLegs> legItems2;
    public List<ModDex> modDexItems2;
    public List<ModStr> modStrItems2;
    public List<ModSta> modStaItems2;
    public List<ModHeal> modHealItems2;
    public List<Weapon> weapons2;
    #endregion

    #region ItemLists T3
    public List<ItemHands> handItems3;
    public List<ItemHead> headItems3;
    public List<ItemChest> chestItems3;
    public List<ItemFeet> feetItems3;
    public List<ItemLegs> legItems3;
    public List<ModDex> modDexItems3;
    public List<ModStr> modStrItems3;
    public List<ModSta> modStaItems3;
    public List<ModHeal> modHealItems3;
    public List<Weapon> weapons3;
    #endregion

    #region Prefix/Suffix Lists
    //Prefixes for 
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

    #region Variables for generation
    //current loot level This is set by area difficulty
    private int LootTier; // 1 to 3 based on D2 equivalent of normal, nightmare, hell difficulties
    private int difficultyLevel; //1-6 based on area difficulty

    //Loot distribution by difficulty
    [SerializeField] private int[] randomRangeDifficulty1 = { 2500, 500, 100, 10, 5};
    [SerializeField] private int[] randomRangeDifficulty2 = { 2500, 800, 150, 20, 10 };
    [SerializeField] private int[] randomRangeDifficulty3 = { 2500, 1200, 200, 40, 15 };
    [SerializeField] private int[] randomRangeDifficulty4 = { 2500, 1600, 300, 60, 20 };
    [SerializeField] private int[] randomRangeDifficulty5 = { 2500, 2000, 500, 100, 30 };
    [SerializeField] private int[] randomRangeDifficulty6 = { 2000, 2500, 800, 200, 50 };

    [SerializeField] private GameObject lootItemPrefab = default;
    #endregion

    #region Generation Assisting methods
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
    private int[] DifficultyLevel()
    {
        if (difficultyLevel == 1)
        {
            return randomRangeDifficulty1;
        }
        else if (difficultyLevel == 2)
        {
            return randomRangeDifficulty2;
        }
        else if (difficultyLevel == 3)
        {
            return randomRangeDifficulty3;
        }
        else if (difficultyLevel == 4)
        {
            return randomRangeDifficulty4;
        }
        else if (difficultyLevel == 5)
        {
            return randomRangeDifficulty5;
        }
        else
        {
            return randomRangeDifficulty6;
        }
    }
    private int LootNumber(int enemyRarity)
    {
        int randomNumber = Random.Range(1, 101);
        if (enemyRarity == 1)
        {
            if (randomNumber < 51)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else if (enemyRarity == 2)
        {
            if (randomNumber < 25)
            {
                return 3;
            }
            else if (randomNumber >= 25 && randomNumber < 75)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        else if (enemyRarity == 3)
        {
            if (randomNumber < 25)
            {
                return 4;
            }
            else if (randomNumber >= 25 && randomNumber < 75)
            {
                return 3;
            }
            else
            {
                return 2;
            }
        }
        else if (enemyRarity == 4)
        {
            if (randomNumber < 25)
            {
                return 5;
            }
            else if (randomNumber >= 25 && randomNumber < 75)
            {
                return 4;
            }
            else
            {
                return 3;
            }
        }
        else if (enemyRarity == 5)
        {
            if (randomNumber < 25)
            {
                return 6;
            }
            else if (randomNumber >= 25 && randomNumber < 75)
            {
                return 5;
            }
            else
            {
                return 4;
            }
        }
        else
        {
            if (randomNumber < 25)
            {
                return 7;
            }
            else if (randomNumber >= 25 && randomNumber < 75)
            {
                return 6;
            }
            else
            {
                return 5;
            }
        }
    }
    #endregion
    
    //Master method for dropping the loot
    public void DropLoot(int enemyRarity, Vector3 spawnPoint)
    {
        LootTier = LootItemTypeDifficulty(); 

        int lootNumber = LootNumber(enemyRarity); 
        
        List<Item> lootList = new List<Item>(); //List of items being generated randomly
        if (lootNumber > 0)
        {
            for (int i = 1; i <= lootNumber; i++)
            {
                int randomNumber = Random.Range(1, 6); //number to choose item type (int max number is exclusive)
                if (randomNumber == 1)
                {
                    lootList.Add(SpawnSkill());
                }
                else if (randomNumber == 2)
                {
                    lootList.Add(SpawnMod(LootTier));
                }
                else if (randomNumber == 3)
                {
                    lootList.Add(SpawnArmour(LootTier));
                }
                else if (randomNumber == 4)
                {
                    lootList.Add(SpawnWeapon(LootTier));
                }
                else if (randomNumber == 5)
                {
                    //Money?
                }
            }

            //Spawn the loot items in world
            foreach (Item item in lootList)
            {
                item.GenerateArmour();
                item.AddPreSuf();
                GameObject newLootItem = Instantiate(lootItemPrefab);
                newLootItem.GetComponent<LootItem>().ActivateLootItem(item, spawnPoint);
            }
        }
    }

    #region Item Generating methods
    public Weapon SpawnWeapon(int lootTier)
    {
        Weapon newItem = RandomiseWeapon(lootTier);
        newItem.quality = DifficultyRandomResult(DifficultyLevel(), Player.instance.luck.GetValue());
        if (newItem.quality == Quality.Unique)
        {
            GeneratePrefixSuffix(newItem);
        }
        else
        {
            newItem = GetUniqueItem(newItem) as Weapon;
        }
        newItem.InitialiseWeapon();
        return newItem;
    }
    public Item SpawnArmour(int lootTier)
    {
        Item newItem = null;
        int randNum = Random.Range(1, 6);
        if (randNum == 1)
        {
            newItem = RandomiseChestItem(lootTier);
        } 
        else if (randNum == 2)
        {
            newItem = RandomiseFeetItem(lootTier);
        }
        else if (randNum == 3)
        {
            newItem = RandomiseHandItem(lootTier);
        }
        else if (randNum == 4)
        {
            newItem = RandomiseHeadItem(lootTier);
        }
        else if (randNum == 5)
        {
            newItem = RandomiseLegItem(lootTier);
        }
        newItem.quality = DifficultyRandomResult(DifficultyLevel(), Player.instance.luck.GetValue());
        if (newItem.quality == Quality.Unique)
        {
            GeneratePrefixSuffix(newItem);
        }
        else
        {
            newItem = GetUniqueItem(newItem);
        }
        GeneratePrefixSuffix(newItem);
        return newItem;
    }
    public Item SpawnMod(int lootTier)
    {
        Item newItem = null;
        int randNum = Random.Range(1, 5);
        if (randNum == 1)
        {
            newItem = RandomiseModDex(lootTier);
        }
        else if (randNum == 2)
        {
            newItem = RandomiseModStr(lootTier);
        }
        else if (randNum == 3)
        {
            newItem = RandomiseModSta(lootTier);
        }
        else if (randNum == 4)
        {
            newItem = RandomiseModHeal(lootTier);
        }
        newItem.quality = DifficultyRandomResult(DifficultyLevel(), Player.instance.luck.GetValue());
        if (newItem.quality == Quality.Unique)
        {
            GeneratePrefixSuffix(newItem);
        }
        else
        {
            newItem = GetUniqueItem(newItem);
        }
        GeneratePrefixSuffix(newItem);
        return newItem;
    }
    public Skill SpawnSkill()
    {
        Skill newItem = RandomiseSkill();        
        //newItem.quality = DifficultyRandomResult(DifficultyLevel(), Player.instance.luck.GetValue());
        GeneratePrefixSuffix(newItem);
        return newItem;
    }
    public Item GetUniqueItem(Item item)
    {
        //replace item with unique
        return item; //temporary to stop errors
    }
    public void GeneratePrefixSuffix(Item item)
    {
        if (item.quality == Quality.Uncommon)
        {
            int randomNumber = Random.Range(1, 3);
            if (randomNumber == 1)
            {
                AddPrefix(item);
            }
            else
            {
                AddSuffix(item);
            }
            item.name = GenerateMagicalName(item);
        }
        else if (item.quality == Quality.Masterwork)
        {
            AddPrefix(item);
            AddSuffix(item);
            item.name = GenerateMagicalName(item);
        }
        else if (item.quality == Quality.Rare)
        {
            AddPrefix(item);
            AddPrefix(item);
            AddSuffix(item);
            AddSuffix(item);
            item.name = GenerateRareName(item.name);
        }
        else if (item.quality == Quality.Legendary)
        {
            AddPrefix(item);
            AddPrefix(item);
            AddSuffix(item);
            AddSuffix(item);
            AddSuffix(item);
            AddSuffix(item);
            item.name = GenerateRareName(item.name);
        }
        else
        {

        }
    }
    public void AddPrefix(Item item)
    {
        bool genItem = false;
        Prefix pFix = GeneratePrefix();
        foreach (ItemType iType in pFix.iTypes)
        {
            if (iType == item.itemType)
            {
                item.AddPrefix(pFix);
                genItem = true;
            }
        }
        if (genItem == false)
        {
            AddPrefix(item);
        }
    }
    public void AddSuffix(Item item)
    {
        bool genItem = false;
        Suffix sFix = GenerateSuffix();
        foreach (ItemType iType in sFix.iTypes)
        {
            if (iType == item.itemType)
            {
                item.AddSuffix(sFix);
                genItem = true;
            }
        }
        if (genItem == false)
        {
            AddSuffix(item);
        }
    }
    public Prefix GeneratePrefix()
    {
        int randomNumber = Random.Range(1, GetPrefixList().Count + 1);
        Prefix pFix = GetPrefixList()[randomNumber];
        return pFix;
    }
    public Suffix GenerateSuffix()
    {
        int randomNumber = Random.Range(1,GetSuffixList().Count + 1);
        Suffix sFix = GetSuffixList()[randomNumber];
        return sFix;
    }
    public List<Prefix> GetPrefixList()
    {
        return pList1;
    }
    public List<Suffix> GetSuffixList()
    {
        return sList1;
    }
    public string GenerateRareName(string iName)
    {
        RarePrefixPart1 rand1 = (RarePrefixPart1)Random.Range(0, (int)RarePrefixPart1.Max);
        RarePrefixPart2 rand2 = (RarePrefixPart2)Random.Range(0, (int)RarePrefixPart2.Max);
        string rarePrefix1 = rand1.ToString();
        string rarePrefix2 = rand2.ToString();
        string rareName = rarePrefix1 + rarePrefix2 + " " + iName;
        return rareName;
    }
    public string GenerateMagicalName(Item item)
    {
        string iName = item.name;
        string prefix = item.GetPrefixName();
        string suffix = item.GetSuffixName();
        string magicName = prefix + iName + " of " + suffix;
        return magicName;
    }
    #endregion

    //ONLY ELEMENTALIST SKILLS AT THE MOMENT
    #region Pull Item from Random Table
    //handItems
    public ItemHands RandomiseHandItem(int lootTier)
    {
        ItemHands newItem; 
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, handItems2.Count + 1);
            return newItem = Instantiate(handItems2[randomNumber]);
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, handItems3.Count + 1);
            return newItem = Instantiate(handItems3[randomNumber]);
        }
        else
        {
            int randomNumber = Random.Range(0, handItems1.Count + 1);
            return newItem = Instantiate(handItems1[randomNumber]);
        }
    }   
    //headItems
    public ItemHead RandomiseHeadItem(int lootTier)
    {
        ItemHead newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, headItems2.Count + 1);
            return newItem = Instantiate(headItems2[randomNumber]);
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, headItems3.Count + 1);
            return newItem = Instantiate(headItems3[randomNumber]);
        }
        else
        {
            int randomNumber = Random.Range(0, headItems1.Count + 1);
            return newItem = Instantiate(headItems1[randomNumber]);
        }
    }    
    //chestItems
    public ItemChest RandomiseChestItem(int lootTier)
    {
        ItemChest newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, chestItems2.Count + 1);
            return newItem = Instantiate(chestItems2[randomNumber]);
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, chestItems3.Count + 1);
            return newItem = Instantiate(chestItems3[randomNumber]);
        }
        else
        {
            int randomNumber = Random.Range(0, chestItems1.Count + 1);
            return newItem = Instantiate(chestItems1[randomNumber]);
        }
    }
    //feetItems
    public ItemFeet RandomiseFeetItem(int lootTier)
    {
        ItemFeet newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, feetItems2.Count + 1);
            return newItem = Instantiate(feetItems2[randomNumber]);
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, feetItems3.Count + 1);
            return newItem = Instantiate(feetItems3[randomNumber]);
        }
        else
        {
            int randomNumber = Random.Range(0, feetItems1.Count + 1);
            return newItem = Instantiate(feetItems1[randomNumber]);
        }
    }
    //legItems
    public ItemLegs RandomiseLegItem(int lootTier)
    {
        ItemLegs newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, legItems2.Count + 1);
            return newItem = Instantiate(legItems2[randomNumber]);
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, legItems3.Count + 1);
            return newItem = Instantiate(legItems3[randomNumber]);
        }
        else
        {
            int randomNumber = Random.Range(0, legItems1.Count + 1);
            return newItem = Instantiate(legItems1[randomNumber]);
        }
    }
    //modDexItems
    public ModDex RandomiseModDex(int lootTier)
    {
        ModDex newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, modDexItems2.Count + 1);
            return newItem = Instantiate(modDexItems2[randomNumber]);
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, modDexItems3.Count + 1);
            return newItem = Instantiate(modDexItems3[randomNumber]);
        }
        else
        {
            int randomNumber = Random.Range(0, modDexItems1.Count + 1);
            return newItem = Instantiate(modDexItems1[randomNumber]);
        }    
    }
    //modStrItems
    public ModStr RandomiseModStr(int lootTier)
    {
        ModStr newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, modStrItems2.Count + 1);
            return newItem = Instantiate(modStrItems2[randomNumber]);
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, modStrItems3.Count + 1);
            return newItem = Instantiate(modStrItems3[randomNumber]);
        }
        else
        {
            int randomNumber = Random.Range(0, modStrItems1.Count + 1);
            return newItem = Instantiate(modStrItems1[randomNumber]);
        }
    }
    //modStaItems
    public ModSta RandomiseModSta(int lootTier)
    {
        ModSta newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, modStaItems2.Count + 1);
            return newItem = Instantiate(modStaItems2[randomNumber]);
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, modStaItems3.Count + 1);
            return newItem = Instantiate(modStaItems3[randomNumber]);
        }
        else
        {
            int randomNumber = Random.Range(0, modStaItems1.Count + 1);
            return newItem = Instantiate(modStaItems1[randomNumber]);
        }
    }
    //modHealItems
    public ModHeal RandomiseModHeal(int lootTier)
    {
        ModHeal newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, modHealItems2.Count + 1);
            return newItem = Instantiate(modHealItems2[randomNumber]);
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, modHealItems3.Count + 1);
            return newItem = Instantiate(modHealItems3[randomNumber]);
        }
        else
        {
            int randomNumber = Random.Range(0, modHealItems1.Count + 1);
            return newItem = Instantiate(modHealItems1[randomNumber]);
        }        
    }
    //weapons
    public Weapon RandomiseWeapon(int lootTier)
    {
        Weapon newWeapon;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, weapons2.Count + 1);
            return newWeapon = Instantiate(weapons2[randomNumber]);
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, weapons3.Count + 1);
            return newWeapon = Instantiate(weapons3[randomNumber]);
        }
        else
        {
            int randomNumber = Random.Range(0, weapons1.Count + 1);
            return newWeapon = Instantiate(weapons1[randomNumber]);
        }
    }
    //Skills
    public Skill RandomiseSkill()
    {
        int randomNumber = Random.Range(1, 13);
        Skill newSkill;
        switch (randomNumber)
        {
            case 1:
                return newSkill = RandomElementalistSkill(); //TODO
            case 2:
                return newSkill = RandomElementalistSkill();
            case 3:
                return newSkill = RandomElementalistSkill(); //TODO
            case 4:
                return newSkill = RandomElementalistSkill(); //TODO
            case 5:
                return newSkill = RandomElementalistSkill(); //TODO
            case 6:
                return newSkill = RandomElementalistSkill(); //TODO
            case 7:
                return newSkill = RandomElementalistSkill(); //TODO
            case 8:
                return newSkill = RandomElementalistSkill(); //TODO
            case 9:
                return newSkill = RandomElementalistSkill(); //TODO
            case 10:
                return newSkill = RandomElementalistSkill(); //TODO
            case 11:
                return newSkill = RandomElementalistSkill(); //TODO
            case 12:
                return newSkill = RandomElementalistSkill(); //TODO
            default:
                return newSkill = RandomElementalistSkill(); //TODO
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
//TODO List of rare names
public enum RarePrefixPart1 {Chaos, Max}
public enum RarePrefixPart2 {Bane, Max}