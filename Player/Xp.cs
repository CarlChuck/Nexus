using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : MonoBehaviour
{
    private int currentLevel;
    private int currentXP;
    private int nextLevelXP;

    public int CurrentLevel()
    {
        return currentLevel;
    }

    public void GainEXP(int value)
    {
        currentXP += value;
        if (currentXP > nextLevelXP)
        {
            currentLevel += 1;
            Player.instance.OnLevelUp();
            SetNextLevelXP();
        }
    }

    private void SetNextLevelXP()
    {
        if (currentLevel <= 5)
        {
            nextLevelXP += 500;
        }
        else if (currentLevel <= 10)
        {
            nextLevelXP += 1000;
        }
        else if (currentLevel <= 20)
        {
            nextLevelXP += 2000;
        }
        else if (currentLevel <= 30)
        {
            nextLevelXP += 5000;
        }
        else if (currentLevel <= 40)
        {
            nextLevelXP += 10000;
        }
        else if (currentLevel <= 50)
        {
            nextLevelXP += 25000;
        }
        else if (currentLevel <= 60)
        {
            nextLevelXP += 50000;
        }
        else if (currentLevel <= 70)
        {
            nextLevelXP += 100000;
        }
        else if (currentLevel <= 80)
        {
            nextLevelXP += 250000;
        }
        else if (currentLevel <= 90)
        {
            nextLevelXP += 500000;
        }
        else if(currentLevel <= 100)
        {
            nextLevelXP += 1000000;
        }
        else
        {
            nextLevelXP += 10000000;
        }
    }
}
