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
    }

    public void MenuFunction(MenuFunc mFunc)
    {
        if (mFunc == MenuFunc.CreateCharWindow)
        {
            OnCharacterCreationWindow();
        }
        else if (mFunc == MenuFunc.Play)
        {
            OnPlay();
        }
        else if (mFunc == MenuFunc.Exit)
        {
            OnExitGame();
        }
        else if (mFunc == MenuFunc.CreateCharButton)
        {
            OnCharacterCreateButton();
        }
        else if (mFunc == MenuFunc.MainMenu)
        {
            OnFrontMenu();
        }
        else if (mFunc == MenuFunc.Options)
        {
            OnOptions();
        }
    }
    //charStatsPanel.cClass == CharClass.Blank /*|| charStatsPanel.charName == ""*/) //may reintroduce character name, but probably not, keeping it there just incase
    //TODO enter button greyed out

    private void OnPlay()
    {
         SceneManager.LoadScene("StagingArea");
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
        OnFrontMenu();
        cSaveSystem.CreateCharacter(cCreationPane.charName, cCreationPane.cClass);
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
}
public enum MenuFunc { MainMenu, CreateCharWindow, CreateCharButton, Exit, Play, Options }