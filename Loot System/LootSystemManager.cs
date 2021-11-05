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
    public List<CyberneticMod> modCyberneticItems1;
    public List<EnchantmentMod> modEnchantmentItems1;
    public List<GeneticMod> modGeneticItems1;
    public List<BioneticMod> modBioneticItems1;
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
    public List<CyberneticMod> modCyberneticItems2;
    public List<EnchantmentMod> modEnchantmentItems2;
    public List<GeneticMod> modGeneticItems2;
    public List<BioneticMod> modBioneticItems2;
    public List<Weapon> weapons2;
    #endregion

    #region ItemLists T3
    public List<ItemHands> handItems3;
    public List<ItemHead> headItems3;
    public List<ItemChest> chestItems3;
    public List<ItemFeet> feetItems3;
    public List<ItemLegs> legItems3;
    public List<CyberneticMod> modCyberneticItems3;
    public List<EnchantmentMod> modEnchantmentItems3;
    public List<GeneticMod> modGeneticItems3;
    public List<BioneticMod> modBioneticItems3;
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
    private int lootTier; // 1 to 3 based on D2 equivalent of normal, nightmare, hell difficulties
    private int difficultyLevel; //1-6 based on area difficulty

    //Loot distribution by difficulty
    [SerializeField] private int[] randomRangeDifficulty1 = { 2500, 500, 100, 10, 5};
    [SerializeField] private int[] randomRangeDifficulty2 = { 2500, 800, 150, 20, 10 };
    [SerializeField] private int[] randomRangeDifficulty3 = { 2500, 1200, 200, 40, 15 };
    [SerializeField] private int[] randomRangeDifficulty4 = { 2500, 1600, 300, 60, 20 };
    [SerializeField] private int[] randomRangeDifficulty5 = { 2500, 2000, 500, 100, 30 };
    [SerializeField] private int[] randomRangeDifficulty6 = { 2000, 2500, 800, 200, 50 };

    [SerializeField] private GameObject lootItemPrefab = default;
    [SerializeField] private InventoryItem inventoryItem = default;
    #endregion

    private void Start()
    {
        if (lootTier < 1)
        {
            lootTier = 1;
        }
        if (difficultyLevel < 1)
        {
            difficultyLevel = 1;
        }
    }
    //Master method for dropping the loot

    public void SetAreaDifficulty(int num)
    {
        if (num > 0 && num < 7)
        {
            difficultyLevel = num;
        }
        else
        {
            difficultyLevel = 1;
        }
    }

    public void SetLootTier(int num)
    {
        if (num > 0 && num < 4)
        {
            lootTier = num;
        }
        else
        {
            lootTier = 1;
        }
    }

    public void DropLoot(int enemyRarity, Transform spawnPoint)
    {
        lootTier = LootItemTypeDifficulty();

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
                    lootList.Add(SpawnMod(lootTier));
                }
                else if (randomNumber == 3)
                {
                    lootList.Add(SpawnArmour(lootTier));
                }
                else if (randomNumber == 4)
                {
                    lootList.Add(SpawnWeapon(lootTier));
                }
                else if (randomNumber > 4)
                {
                    //Money?
                }
            }

            //Spawn the loot items in world
            foreach (Item item in lootList)
            {
                GameObject newLootItem = Instantiate(lootItemPrefab, spawnPoint.position, Quaternion.identity);
                InventoryItem iItem = Instantiate(inventoryItem, gameObject.transform);
                Quality qual = DifficultyRandomResult(DifficultyLevel(), Player.instance.luck.GetValue());
                GeneratePrefixSuffix(iItem, qual);
                iItem.BuildInventoryItem(item, qual);
                newLootItem.GetComponent<LootItem>().ActivateLootItem(iItem, spawnPoint);

                //generate a name
                if (item.quality == Quality.Unique)
                {
                    //item = GetUniqueItem(item) //TODO
                }
                else
                {
                    //Generate Name
                }
            }
        }
    }

    #region Generation Assisting methods
    private Quality DifficultyRandomResult(int[] rRange, int magicFind)
    {
        //TODO add magicFind to some below
        int uncommonChance = rRange[0];
        int masterworkChance = (rRange[1]); //magic find
        int rareChance = (rRange[2]); //magic find
        int legendaryChance = (rRange[3]); //magic find
        int uniqueChance = (rRange[4]);
        int commonChance = Mathf.Clamp(10000 - (rRange[0] + rRange[1] + rRange[2] + rRange[3] + rRange[4]), 0, 10000);

        int finalUncommonChance = commonChance + uncommonChance;
        int finalMasterworkChance = finalUncommonChance + masterworkChance;
        int finalRareChance = finalMasterworkChance + rareChance;
        int finalLegendaryChance = finalRareChance + legendaryChance;
        int finalUniqueChance = finalLegendaryChance + uniqueChance;

        int[] finalRange = {commonChance, finalUncommonChance, finalMasterworkChance, finalRareChance, finalLegendaryChance, finalUniqueChance };
        int cumulativeNumber = commonChance + uncommonChance + masterworkChance + rareChance + legendaryChance + uniqueChance + 1;  //Should be 10001 anyway but this just avoids oddness
        int randomNumber = Random.Range(1, cumulativeNumber);
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
        if (lootTier == 2)
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
        else if (lootTier == 3)
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

    #region Item Generating methods
    public Weapon SpawnWeapon(int lootTier)
    {
        Weapon newItem = RandomiseWeapon(lootTier);

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
        return newItem;
    }
    public Item SpawnMod(int lootTier)
    {
        Item newItem = null;
        int randNum = Random.Range(1, 5);
        if (randNum == 1)
        {
            newItem = RandomiseModCybernetic(lootTier);
        }
        else if (randNum == 2)
        {
            newItem = RandomiseModEnchantment(lootTier);
        }
        else if (randNum == 3)
        {
            newItem = RandomiseModGenetic(lootTier);
        }
        else if (randNum == 4)
        {
            newItem = RandomiseModBionetic(lootTier);
        }
        return newItem;
    }
    public Skill SpawnSkill()
    {
        Skill newItem = RandomiseSkill();
        return newItem;
    }
    public InventoryItem GetUniqueItem(InventoryItem item)
    {
        //replace item with unique
        return item; //temporary to stop errors
    }
    public void GeneratePrefixSuffix(InventoryItem item, Quality qual)
    {
        if (qual == Quality.Uncommon)
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
        }
        else if (qual == Quality.Masterwork)
        {
            AddPrefix(item);
            AddSuffix(item);
        }
        else if (qual == Quality.Rare)
        {
            AddPrefix(item);
            AddPrefix(item);
            AddSuffix(item);
            AddSuffix(item);
        }
        else if (qual == Quality.Legendary)
        {
            AddPrefix(item);
            AddPrefix(item);
            AddSuffix(item);
            AddSuffix(item);
            AddSuffix(item);
            AddSuffix(item);
        }
        else
        {

        }
    }
    public void AddPrefix(InventoryItem item)
    {
        bool genItem = false;
        Prefix pFix = GeneratePrefix();
        foreach (ItemType iType in pFix.iTypes)
        {               
            //CHECKS FOR SHIELD ONLY PREFIXES
            if (iType == ItemType.Weapon)
            {
                //Checking each prefix name
                if( pFix.pName == PrefixName.Reinforced || 
                    pFix.pName == PrefixName.Preserving || 
                    pFix.pName == PrefixName.Shielding || 
                    pFix.pName == PrefixName.Defending || 
                    pFix.pName == PrefixName.Protecting ||
                    pFix.pName == PrefixName.Guarding ||
                    pFix.pName == PrefixName.Disrupting ||
                    pFix.pName == PrefixName.Obstructing ||
                    pFix.pName == PrefixName.Deflecting ||
                    pFix.pName == PrefixName.Repelling ||
                    pFix.pName == PrefixName.Parrying ||
                    pFix.pName == PrefixName.Warding)
                {
                    if(item.itemType == ItemType.Weapon)
                    {

                        if (item.wType == WeaponType.Shield)
                        {
                            item.AddPrefix(pFix);
                            genItem = true;
                        }
                    }
                }
                else if (item.itemType == ItemType.Weapon)
                {
                    item.AddPrefix(pFix);
                    genItem = true;
                }
            }
            else if (iType == item.itemType)
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
    public void AddSuffix(InventoryItem item)
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
        int randomNumber = Random.Range(1, GetPrefixList().Count);
        Prefix pFix = GetPrefixList()[randomNumber];
        return pFix;
    }
    public Suffix GenerateSuffix()
    {
        int randomNumber = Random.Range(1,GetSuffixList().Count);
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

    #endregion

    //ONLY ELEMENTALIST SKILLS AT THE MOMENT
    #region Pull Item from Random Table
    //handItems
    public ItemHands RandomiseHandItem(int lootTier)
    {
        ItemHands newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, handItems2.Count);
            return newItem = handItems2[randomNumber];
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, handItems3.Count);
            return newItem = handItems3[randomNumber];
        }
        else
        {
            int randomNumber = Random.Range(0, handItems1.Count);
            return newItem = handItems1[randomNumber];
        }
    }
    //headItems
    public ItemHead RandomiseHeadItem(int lootTier)
    {
        ItemHead newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, headItems2.Count);
            return newItem = headItems2[randomNumber];
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, headItems3.Count);
            return newItem = headItems3[randomNumber];
        }
        else
        {
            int randomNumber = Random.Range(0, headItems1.Count);
            return newItem = headItems1[randomNumber];
        }
    }
    //chestItems
    public ItemChest RandomiseChestItem(int lootTier)
    {
        ItemChest newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, chestItems2.Count);
            return newItem = chestItems2[randomNumber];
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, chestItems3.Count);
            return newItem = chestItems3[randomNumber];
        }
        else
        {
            int randomNumber = Random.Range(0, chestItems1.Count);
            return newItem = chestItems1[randomNumber];
        }
    }
    //feetItems
    public ItemFeet RandomiseFeetItem(int lootTier)
    {
        ItemFeet newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, feetItems2.Count);
            return newItem = feetItems2[randomNumber];
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, feetItems3.Count);
            return newItem = feetItems3[randomNumber];
        }
        else
        {
            int randomNumber = Random.Range(0, feetItems1.Count);
            return newItem = feetItems1[randomNumber];
        }
    }
    //legItems
    public ItemLegs RandomiseLegItem(int lootTier)
    {
        ItemLegs newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, legItems2.Count);
            return newItem = legItems2[randomNumber];
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, legItems3.Count);
            return newItem = legItems3[randomNumber];
        }
        else
        {
            int randomNumber = Random.Range(0, legItems1.Count);
            return newItem = legItems1[randomNumber];
        }
    }
    //modDexItems
    public CyberneticMod RandomiseModCybernetic(int lootTier)
    {
        CyberneticMod newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, modCyberneticItems2.Count);
            return newItem = modCyberneticItems2[randomNumber];
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, modCyberneticItems3.Count);
            return newItem = modCyberneticItems3[randomNumber];
        }
        else
        {
            int randomNumber = Random.Range(0, modCyberneticItems1.Count);
            return newItem = modCyberneticItems1[randomNumber];
        }
    }
    //modStrItems
    public EnchantmentMod RandomiseModEnchantment(int lootTier)
    {
        EnchantmentMod newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, modEnchantmentItems2.Count);
            return newItem = modEnchantmentItems2[randomNumber];
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, modEnchantmentItems3.Count);
            return newItem = modEnchantmentItems3[randomNumber];
        }
        else
        {
            int randomNumber = Random.Range(0, modEnchantmentItems1.Count);
            return newItem = modEnchantmentItems1[randomNumber];
        }
    }
    //modStaItems
    public GeneticMod RandomiseModGenetic(int lootTier)
    {
        GeneticMod newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, modGeneticItems2.Count);
            return newItem = modGeneticItems2[randomNumber];
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, modGeneticItems3.Count);
            return newItem = modGeneticItems3[randomNumber];
        }
        else
        {
            int randomNumber = Random.Range(0, modGeneticItems1.Count);
            return newItem = modGeneticItems1[randomNumber];
        }
    }
    //modHealItems
    public BioneticMod RandomiseModBionetic(int lootTier)
    {
        BioneticMod newItem;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, modBioneticItems2.Count);
            return newItem = modBioneticItems2[randomNumber];
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, modBioneticItems3.Count);
            return newItem = modBioneticItems3[randomNumber];
        }
        else
        {
            int randomNumber = Random.Range(0, modBioneticItems1.Count);
            return newItem = modBioneticItems1[randomNumber];
        }
    }
    //weapons
    public Weapon RandomiseWeapon(int lootTier)
    {
        Weapon newWeapon;
        if (lootTier == 2)
        {
            int randomNumber = Random.Range(0, weapons2.Count);
            return newWeapon = weapons2[randomNumber];
        }
        else if (lootTier == 3)
        {
            int randomNumber = Random.Range(0, weapons3.Count);
            return newWeapon = weapons3[randomNumber];
        }
        else
        {
            int randomNumber = Random.Range(0, weapons1.Count);
            return newWeapon = weapons1[randomNumber];
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
                return newSkill = RandomElementalistSkill(); //TODO Golemancer
            case 2:
                return newSkill = RandomElementalistSkill();
            case 3:
                return newSkill = RandomElementalistSkill(); //TODO etc
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
        int randomNumber = Random.Range(0, elementalSkills.Count);
        ElementalistSkill newEleSkill;
        return newEleSkill = elementalSkills[randomNumber];
    }
    #endregion
}
