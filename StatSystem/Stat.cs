using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Base class for all stats */

[System.Serializable]
public class Stat
{

    public int baseValue;   // Starting value

    // Keep a list of all the modifiers on this stat
    private List<int> modifiers = new List<int>();

    // Add all modifiers together and return the result
    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }
    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }

    public bool PositiveModified()
    {
        if (GetValue() > baseValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool NegativeModified()
    {
        if (GetValue() < baseValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}