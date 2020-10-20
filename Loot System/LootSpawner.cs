﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    public int rarity = 1;

    public void DropLoot()
    {
        LootSystemManager lootSys = LootSystemManager.instance;
        lootSys.DropLoot(rarity, gameObject.transform.position);
    }
}
