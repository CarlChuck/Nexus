using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionPane : MonoBehaviour
{
    [SerializeField] private List<CharacterSelectionButton> characterList;
    [SerializeField] private SaveSystemManager cSaveManager;
    [SerializeField] private RectTransform gridDepth;
    [SerializeField] private GameObject characterButtonsParent;
    [SerializeField] private GameObject charButtonPrefab;


    public void PopulatePanefromSave()
    {
        //Empty The List
        if (characterList.Count != 0)
        {
            foreach (CharacterSelectionButton cButton in characterList)
            {
                Destroy(cButton.gameObject);
            }
            characterList = new List<CharacterSelectionButton>();
        }

        //Generate List from SaveFile
        foreach (CharacterData cData in cSaveManager.GetList())
        {
            GameObject newButton = Instantiate(charButtonPrefab, characterButtonsParent.transform);
            CharacterSelectionButton cButton = newButton.GetComponent<CharacterSelectionButton>();
            cButton.SetDataObject(cData);
            cButton.SetNameField(cData.GetName());
            cButton.SetLevelField(cData.GetLevel());
            cButton.SetClassField(cData.GetCharClass());
            characterList.Add(cButton);
        }
        UpdateGridDepth();
    }

    private void UpdateGridDepth()
    {
        int cListLength = characterList.Count * 200;

        gridDepth.sizeDelta = new Vector2(0, cListLength);
    }

    public void OnAButtonSelected()
    {
        foreach (CharacterSelectionButton cButton in characterList)
        {
            cButton.OnDeSelect();
        }
    }
}
