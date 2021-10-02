using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterData : MonoBehaviour
{
    [SerializeField] private string characterName;
    public CharClass charClass;
    [SerializeField] private  int level;
    [SerializeField] private int xp;
    public AScene savePoint;

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

    public string GetName()
    {
        return characterName;
    }

    public CharClass GetCharClass()
    {
        return charClass;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetXP()
    {
        return xp;
    }

    public AScene GetScene()
    {
        return savePoint;
    }
}
