using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCharCreatorButtons : MonoBehaviour
{
    [SerializeField] GameObject golemancerAvatar;
    [SerializeField] GameObject elementalistAvatar;
    [SerializeField] GameObject psycAvatar;
    [SerializeField] GameObject mysticAvatar;
    [SerializeField] GameObject artificerAvatar;
    [SerializeField] GameObject apochAvatar;
    [SerializeField] GameObject crypterAvatar;
    [SerializeField] GameObject nanoMageAvatar;
    [SerializeField] GameObject envoyAvatar;
    [SerializeField] GameObject vigilAvatar;
    [SerializeField] GameObject shadowAvatar;
    [SerializeField] GameObject streetDocAvatar;

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
        envoyAvatar.SetActive(false);
        vigilAvatar.SetActive(false);
        shadowAvatar.SetActive(false);
        streetDocAvatar.SetActive(false);
    }

    public void LoadThisAvatar(CharClass mAvatar)
    {

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
    private void OnOpenEnvoy()
    {
        ResetAllAvatars();
        envoyAvatar.SetActive(true);
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
