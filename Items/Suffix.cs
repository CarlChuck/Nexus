using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suffix : ScriptableObject
{
    public SuffixName sName;
    public int min;
    public int max;
    public List<ItemType> iTypes;
}
public enum SuffixName { test }