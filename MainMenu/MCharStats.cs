using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCharStats : MonoBehaviour
{
    public string charName;
    public CharClass cClass;
    public ClassDataObject selectedClass;

    public GameObject classDescPanel;
    
    #region classes
    public ClassDataObject dGolemancer;
    public ClassDataObject dElementalist;
    public ClassDataObject dPsion;
    public ClassDataObject dMystic;
    public ClassDataObject dArtificer;
    public ClassDataObject dApoch;
    public ClassDataObject dCrypter;
    public ClassDataObject dNanoMage;
    public ClassDataObject dEnvoy;
    public ClassDataObject dVigil;
    public ClassDataObject dShadow;
    public ClassDataObject dStreetDoctor;
    #endregion

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void SetClass(int cC)
    {
        classDescPanel.SetActive(true);
        switch (cC)
        {
            case 1:
                cClass = CharClass.Golemancer;
                selectedClass = dGolemancer;
                break;
            case 2:
                cClass = CharClass.Elementalist;
                selectedClass = dElementalist;
                break;
            case 3:
                cClass = CharClass.Psyc;
                selectedClass = dPsion;
                break;
            case 4:
                cClass = CharClass.Mystic;
                selectedClass = dMystic;
                break;
            case 5:
                cClass = CharClass.Crypter;
                selectedClass = dCrypter;
                break;
            case 6:
                cClass = CharClass.Apoch;
                selectedClass = dApoch;
                break;
            case 7:
                cClass = CharClass.Artificer;
                selectedClass = dArtificer;
                break;
            case 8:
                cClass = CharClass.NanoMage;
                selectedClass = dNanoMage;
                break;
            case 9:
                cClass = CharClass.Vigil;
                selectedClass = dVigil;
                break;
            case 10:
                cClass = CharClass.Shadow;
                selectedClass = dShadow;
                break;
            case 11:
                cClass = CharClass.Envoy;
                selectedClass = dEnvoy;
                break;
            case 12:
                cClass = CharClass.StreetDoctor;
                selectedClass = dStreetDoctor;
                break;
        }
    }

    public void SetName(Text cName)
    {
        charName = cName.text;
    }
}
