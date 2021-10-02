using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLoot : MonoBehaviour
{
    [SerializeField] private Player player = default;
    [SerializeField] private AutoLootType aType = default;
    [SerializeField] private SphereCollider sCol = default;

    public void UpdateLootRadius(float num)
    {
        sCol.radius = num;
    }

    public void LootItem(LootItem loot, Item item)
    {
        switch (aType)
        {
            case AutoLootType.None:
                break;
            case AutoLootType.Common:
                if (item.quality.Equals(Quality.Unique) || item.quality.Equals(Quality.Legendary) || item.quality.Equals(Quality.Rare))
                {
                    TakeItem(loot, item);
                }
                else if (item.quality.Equals(Quality.Masterwork) || item.quality.Equals(Quality.Uncommon) || item.quality.Equals(Quality.Common))
                {
                    TakeItem(loot, item);
                }
                break;
            case AutoLootType.Uncommon:
                if (item.quality.Equals(Quality.Unique) || item.quality.Equals(Quality.Legendary) || item.quality.Equals(Quality.Rare))
                {
                    TakeItem(loot, item);
                }
                else if (item.quality.Equals(Quality.Masterwork) || item.quality.Equals(Quality.Uncommon))
                {
                    TakeItem(loot, item);
                }
                break;
            case AutoLootType.Masterwork:
                if (item.quality.Equals(Quality.Unique) || item.quality.Equals(Quality.Legendary) || item.quality.Equals(Quality.Rare))
                {
                    TakeItem(loot, item);
                }
                else if (item.quality.Equals(Quality.Masterwork))
                {
                    TakeItem(loot, item);
                }
                break;
            case AutoLootType.Rare:
                if (item.quality.Equals(Quality.Unique) || item.quality.Equals(Quality.Legendary) || item.quality.Equals(Quality.Rare))
                {
                    TakeItem(loot, item);
                }
                break;
            case AutoLootType.Legendary:
                if (item.quality.Equals(Quality.Unique)|| item.quality.Equals(Quality.Legendary))
                {
                    TakeItem(loot, item);
                }
                break;
            case AutoLootType.Unique:
                if (item.quality.Equals(Quality.Unique))
                {
                    TakeItem(loot, item);
                }
                break;
        }
    }

    //Toggles the loot threshold for the autoloot system
    public void ToggleLootType()
    {
        switch (aType)
        {
            case AutoLootType.None:
                aType = AutoLootType.Common;
                break;
            case AutoLootType.Common:
                aType = AutoLootType.Uncommon;
                break;
            case AutoLootType.Uncommon:
                aType = AutoLootType.Masterwork;
                break;
            case AutoLootType.Masterwork:
                aType = AutoLootType.Rare;
                break;
            case AutoLootType.Rare:
                aType = AutoLootType.Legendary;
                break;
            case AutoLootType.Legendary:
                aType = AutoLootType.Unique;
                break;
            case AutoLootType.Unique:
                aType = AutoLootType.None;
                break;
        }
    }

    //Takes the item to player inventory and destroys the in world object
    private void TakeItem(LootItem loot, Item item)
    {
        loot.DisableCollider();
        player.inventory.PickUpItem(item);
        Destroy(loot.gameObject, 1);
    }
}
public enum AutoLootType {None, Common, Uncommon, Masterwork, Rare, Legendary, Unique }