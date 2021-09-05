using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterData : MonoBehaviour
{
    private string characterName;
    private CharClass charClass;
    private int level;
    private int xp;
    private AScene savePoint;

    public void CreateNew(string cName, CharClass cClass)
    {
        characterName = cName;
        charClass = cClass;
        level = 1;
        savePoint = AScene.Tutorial;
    }

    public void UpdateLevel(int newLevel, int newXp)
    {
        level = newLevel;
        xp = newXp;
    }

    public void UpdateSavePoint(AScene scene)
    {
        savePoint = scene;
    }

}
