using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemManager : MonoBehaviour
{
    public List<CharacterData> cList;
    [SerializeField] private GameObject characterDataContainerPrefab;
    public CharacterData currentCharacter;

    #region Singleton
    public static SaveSystemManager instance;
    public void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    #region MenuInteractions
    public void CreateCharacter(string cName, CharClass cClass)
    {
        GameObject newChar = Instantiate(characterDataContainerPrefab, gameObject.transform);
        CharacterData cData = newChar.GetComponent<CharacterData>();
        cData.CreateNew(cName, cClass);
        AddCharacterToList(cData);
        SaveList();
    }

    public void SelectCharacter(CharacterData cData)
    {
        currentCharacter = cData;
    }

    public void AddCharacterToList(CharacterData cData)
    {
        cList.Add(cData);
    }

    public List<CharacterData> GetList()
    {
        return cList;
    }

    public void DeleteCharacter()
    {
        if (currentCharacter != null)
        {
            cList.Remove(currentCharacter);
            Destroy(currentCharacter.gameObject);
            currentCharacter = null;
            SaveList();
        }
    }
    #endregion

    #region Load/Save List
    public void SaveList()
    {
        ES3.Save<List<CharacterData>>("CharacterList", cList);
    }

    public void LoadList() 
    {
        cList = ES3.Load<List<CharacterData>>("CharacterList");
    }
    #endregion


}
