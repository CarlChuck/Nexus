using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject frontMenu;
    [SerializeField] GameObject charPanel;
    [SerializeField] GameObject charCreatePanel;
    [SerializeField] MCharStats charStatsPanel;
    [SerializeField] GameObject warningPanel;
    [SerializeField] Animator cameraAnimator;
    [SerializeField] MenuLighting mLighting;

    private void Start()
    {
        frontMenu.gameObject.SetActive(true);
        charPanel.gameObject.SetActive(false);
        charCreatePanel.gameObject.SetActive(false);
        warningPanel.gameObject.SetActive(false);
    }
    public void MenuFunction(MenuFunc mFunc)
    {
        if (mFunc == MenuFunc.CharSelect)
        {
            CharSelect();
        }
        else if (mFunc == MenuFunc.CreateChar)
        {
            CreateCharacter();
        }
        else if (mFunc == MenuFunc.EnterGame)
        {
            EnterGame();
        }
        else if (mFunc == MenuFunc.ExitGame)
        {
            ExitGame();
        }
        else if (mFunc == MenuFunc.MainMenu)
        {
            MMenu();
        }
    }

    public void EnterGame()
    {
        if (charStatsPanel.cClass == CharClass.Blank /*|| charStatsPanel.charName == ""*/) //may reintroduce character name, but probably not, keeping it there just incase
        {
            warningPanel.gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("StagingArea");
        }
    }

    public void MMenu()
    {
        frontMenu.gameObject.SetActive(true);
        charPanel.gameObject.SetActive(false);
        charCreatePanel.gameObject.SetActive(false);
        SetAnimationTagsToFalse();
        cameraAnimator.SetBool("SelectToFront", true);
        mLighting.ActivateFrontMenuLighting();
    }

    public void CharSelect()
    {
        frontMenu.gameObject.SetActive(false);
        charPanel.gameObject.SetActive(true);
        SetAnimationTagsToFalse();
        cameraAnimator.SetBool("FrontToSelect", true);
        cameraAnimator.SetBool("CreationToSelect", true);
        mLighting.ActivateSelectLighting();
    }

    public void CreateCharacter()
    {
        charPanel.gameObject.SetActive(false);
        charCreatePanel.gameObject.SetActive(true);
        SetAnimationTagsToFalse();
        cameraAnimator.SetBool("SelectToCreation", true);
        mLighting.ActivateCreationLighting();
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    public void Options()
    {

    }

    private void SetAnimationTagsToFalse()
    {
        cameraAnimator.SetBool("FrontToSelect", false);
        cameraAnimator.SetBool("SelectToFront", false);
        cameraAnimator.SetBool("SelectToCreation", false);
        cameraAnimator.SetBool("CreationToSelect", false);
    }
}
public enum MenuFunc { MainMenu, CharSelect, CreateChar, ExitGame, PlayMusic, SwitchMusic, EnterGame, Options }