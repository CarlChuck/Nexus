using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Animator cameraAnimator;
    private SaveSystemManager cSaveSystem;
    public CharacterCreationPane cCreationPane = default;
    public CharacterSelectionPane cSelectionPane = default;
    public CharacterCreationShowModel mAvatarButtons = default;


    #region Singleton
    public static MainMenu instance;

    public void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        cSaveSystem = SaveSystemManager.instance;
        cSaveSystem.LoadList();
        cSelectionPane.PopulatePanefromSave();
    }

    public void MenuFunction(MenuFunc mFunc)
    {
        switch (mFunc)
        {
            case MenuFunc.CreateCharWindow:
                OnCharacterCreationWindow();
                break;
            case MenuFunc.CreateCharButton:
                OnCharacterCreateButton();
                break;
            case MenuFunc.Play:
                OnPlay();
                break;
            case MenuFunc.Exit:
                OnExitGame();
                break;
            case MenuFunc.MainMenu:
                OnFrontMenu();
                break;
            case MenuFunc.Options:
                OnOptions();
                break;
            case MenuFunc.DeleteCharacter:
                OnDeleteCharacter();
                break;
        }
    }

    private void OnPlay()
    {
         SceneManager.LoadScene("PlayerUIOverlay");
    }

    private void OnFrontMenu()
    {
        cSaveSystem.LoadList();
        cSelectionPane.PopulatePanefromSave();
        cameraAnimator.SetBool("Creation", false);
        cameraAnimator.SetBool("Options", false);
    }

    private void OnCharacterCreationWindow()
    {
        cameraAnimator.SetBool("Creation", true);
        cameraAnimator.SetBool("Options", false);
    }
    private void OnCharacterCreateButton()
    {
        if (IsNameNotBlank(cCreationPane.charName) && !IsNameTaken(cCreationPane.charName))
        {
            OnFrontMenu();
            cSaveSystem.CreateCharacter(cCreationPane.charName, cCreationPane.cClass);
            cSelectionPane.PopulatePanefromSave();
        }
        else
        {
            //TODO attention to CharName 
        }
    }

    private void OnExitGame()
    {
        Application.Quit();
    }

    private void OnOptions()
    {
        cameraAnimator.SetBool("Creation", false);
        cameraAnimator.SetBool("Options", true);
    }

    private void OnDeleteCharacter()
    {
        cSaveSystem.DeleteCharacter();
        cSelectionPane.PopulatePanefromSave();

    }

    public bool IsNameNotBlank(string charName)
    {
        if (charName == "")
        {
            return false;
        }
        return true;
    }

    private bool IsNameTaken(string cName)
    {
        foreach (CharacterData cData in SaveSystemManager.instance.GetCharacterList())
        {
            if (cData.GetName() == cName)
            {
                return true;
            }
        }
        return false;
    }
}
public enum MenuFunc { MainMenu, CreateCharWindow, CreateCharButton, Exit, Play, Options, DeleteCharacter }