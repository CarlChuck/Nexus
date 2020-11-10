using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : MonoBehaviour
{
    private int currentLevel;
    private int currentXP;

    public int CurrentLevel()
    {
        return currentLevel;
    }

    public void GainEXP(int value)
    {
        currentXP += value;
    }
}
