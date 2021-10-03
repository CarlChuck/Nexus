using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationPane : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI classTitle;
    [SerializeField] private TextMeshProUGUI classDesc;
    [SerializeField] private TextMeshProUGUI classArcheType;
    [SerializeField] private TextMeshProUGUI classBackground;
    [SerializeField] private GameObject backgroundObj;
    [SerializeField] private GameObject archetypeObj;

    [SerializeField] private EnumsToString eToString;

    public string charName;
    public CharClass cClass;
    private ClassDataObject selectedClass;

    [SerializeField] private GameObject classDescPanel;

    #region classes
    [SerializeField] private ClassDataObject dGolemancer;
    [SerializeField] private ClassDataObject dElementalist;
    [SerializeField] private ClassDataObject dPsyc;
    [SerializeField] private ClassDataObject dMystic;
    [SerializeField] private ClassDataObject dArtificer;
    [SerializeField] private ClassDataObject dApoch;
    [SerializeField] private ClassDataObject dCrypter;
    [SerializeField] private ClassDataObject dNanoMage;
    [SerializeField] private ClassDataObject dGuardian;
    [SerializeField] private ClassDataObject dVigil;
    [SerializeField] private ClassDataObject dShadow;
    [SerializeField] private ClassDataObject dStreetDoctor;
    #endregion

    private void Start()
    {
        classTitle.text = "";
        classDesc.text = "";
        classArcheType.text = "";
        classBackground.text = "";
        backgroundObj.SetActive(false);
        archetypeObj.SetActive(false);
    }

    public void OnUpdateClassInfoWindow()
    {
        if (selectedClass != null)
        {
            classTitle.text = eToString.CharClassToString(cClass);
            classDesc.text = selectedClass.classDescription;
            backgroundObj.SetActive(true);
            archetypeObj.SetActive(true);
            classArcheType.text = eToString.CharArcheTypeToString(selectedClass.aType);
            classBackground.text = eToString.CharBackgroundToString(selectedClass.aBackground);
        }
    }

    public void SetClass(CharClass cC)
    {
        classDescPanel.SetActive(true);
        cClass = cC;
        switch (cC)
        {
            case CharClass.Golemancer:
                selectedClass = dGolemancer;
                break;
            case CharClass.Elementalist:
                selectedClass = dElementalist;
                break;
            case CharClass.Psyc:
                selectedClass = dPsyc;
                break;
            case CharClass.Mystic:
                selectedClass = dMystic;
                break;
            case CharClass.Artificer:
                selectedClass = dArtificer;
                break;
            case CharClass.Apoch:
                selectedClass = dApoch;
                break;
            case CharClass.Crypter:
                selectedClass = dCrypter;
                break;
            case CharClass.NanoMage:
                selectedClass = dNanoMage;
                break;
            case CharClass.Guardian:
                selectedClass = dGuardian;
                break;
            case CharClass.Vigil:
                selectedClass = dVigil;
                break;
            case CharClass.Shadow:
                selectedClass = dShadow;
                break;
            case CharClass.StreetDoctor:
                selectedClass = dStreetDoctor;
                break;
        }
    }

    public void SetName(TMP_InputField cName)
    {
        charName = cName.text;
    }

}
