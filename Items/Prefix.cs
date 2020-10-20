using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefix : ScriptableObject
{
    public PrefixName pName;
    public int min;
    public int max;
    public List<ItemType> iTypes;
}
public enum PrefixName { test }