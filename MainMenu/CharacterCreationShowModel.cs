using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Manages the Character creation pane, showing the 3d objects 
    and sends message to MenuStatUpdater which updates the class info window
*/

public class CharacterCreationShowModel : MonoBehaviour
{
    [SerializeField] private GameObject golemancerAvatar;
    [SerializeField] private GameObject elementalistAvatar;
    [SerializeField] private GameObject psycAvatar;
    [SerializeField] private GameObject mysticAvatar;
    [SerializeField] private GameObject artificerAvatar;
    [SerializeField] private GameObject apochAvatar;
    [SerializeField] private GameObject crypterAvatar;
    [SerializeField] private GameObject nanoMageAvatar;
    [SerializeField] private GameObject guardianAvatar;
    [SerializeField] private GameObject vigilAvatar;
    [SerializeField] private GameObject shadowAvatar;
    [SerializeField] private GameObject streetDocAvatar;

    [SerializeField] private List<MenuButton> mButtons;

    void Start()
    {
        ResetAllAvatars();
    }

    private void ResetAllAvatars()
    {
        golemancerAvatar.SetActive(false);
        elementalistAvatar.SetActive(false);
        psycAvatar.SetActive(false);
        mysticAvatar.SetActive(false);
        artificerAvatar.SetActive(false);
        apochAvatar.SetActive(false);
        crypterAvatar.SetActive(false);
        nanoMageAvatar.SetActive(false);
        guardianAvatar.SetActive(false);
        vigilAvatar.SetActive(false);
        shadowAvatar.SetActive(false);
        streetDocAvatar.SetActive(false);
    }

    public void ResetAllButtons()
    {
        foreach (MenuButton mButton in mButtons)
        {
            mButton.SetAnimationDeSelected();
        }
    }

    public void UpdateClassDescription()
    {
        //mStatUpdater.OnUpdateClassInfoWindow();
    }

    public void LoadThisAvatar(CharClass mAvatar)
    {
        switch (mAvatar)
        {
            case CharClass.Golemancer:
                OnOpenGolemancer();
                break;
            case CharClass.Elementalist:
                OnOpenElementalist();
                break;
            case CharClass.Psyc:
                OnOpenPsyc();
                break;
            case CharClass.Mystic:
                OnOpenMystic();
                break;
            case CharClass.Artificer:
                OnOpenArtificer();
                break;
            case CharClass.Apoch:
                OnOpenApoch();
                break;
            case CharClass.Crypter:
                OnOpenCrypter();
                break;
            case CharClass.NanoMage:
                OnOpenNanoMage();
                break;
            case CharClass.Guardian:
                OnOpenGuardian();
                break;
            case CharClass.Vigil:
                OnOpenVigil();
                break;
            case CharClass.Shadow:
                OnOpenShadow();
                break;
            case CharClass.StreetDoctor:
                OnOpenStreetDoc();
                break;
        }
    }

    private void OnOpenGolemancer()
    {
        ResetAllAvatars();
        golemancerAvatar.SetActive(true);
    }
    private void OnOpenElementalist()
    {
        ResetAllAvatars();
        elementalistAvatar.SetActive(true);
    }
    private void OnOpenMystic()
    {
        ResetAllAvatars();
        mysticAvatar.SetActive(true);
    }
    private void OnOpenPsyc()
    {
        ResetAllAvatars();
        psycAvatar.SetActive(true);
    }
    private void OnOpenArtificer()
    {
        ResetAllAvatars();
        artificerAvatar.SetActive(true);
    }
    private void OnOpenApoch()
    {
        ResetAllAvatars();
        apochAvatar.SetActive(true);
    }
    private void OnOpenCrypter()
    {
        ResetAllAvatars();
        crypterAvatar.SetActive(true);
    }
    private void OnOpenNanoMage()
    {
        ResetAllAvatars();
        nanoMageAvatar.SetActive(true);
    }
    private void OnOpenGuardian()
    {
        ResetAllAvatars();
        guardianAvatar.SetActive(true);
    }
    private void OnOpenVigil()
    {
        ResetAllAvatars();
        vigilAvatar.SetActive(true);
    }
    private void OnOpenShadow()
    {
        ResetAllAvatars();
        shadowAvatar.SetActive(true);
    }
    private void OnOpenStreetDoc()
    {
        ResetAllAvatars();
        streetDocAvatar.SetActive(true);
    }
}
