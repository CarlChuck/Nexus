using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject frontMenu;
    public GameObject charPanel;
    public GameObject charCreatePanel;
    public MCharStats charStatsPanel;
    public GameObject warningPanel;


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
    }

    public void CharSelect()
    {
        frontMenu.gameObject.SetActive(false);
        charPanel.gameObject.SetActive(true);
    }

    public void CreateCharacter()
    {
        charPanel.gameObject.SetActive(false);
        charCreatePanel.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    public void Options()
    {

    }
}
public enum MenuFunc { MainMenu, CharSelect, CreateChar, ExitGame, PlayMusic, SwitchMusic, EnterGame, Options }
