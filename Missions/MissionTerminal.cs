using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionTerminal : Interactable
{
    #region Singleton
    public static MissionTerminal instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion

    //For UI Element
    public List<MissionItem> missionStorage;
    public List<MissionItem> currentMissions;
    public string objName = "Mission Terminal";
    public GameObject missionTerminalUI;
    public Text missionText;
    public UIButtons uiButtons;
    public MissionVarStore missVarStore;
    public MissionItem selectedMission;

    //For 3d Object
    public MeshRenderer baseRenderer;
    private Material oldMaterial;
    public Material newMaterial;
    public GameObject lightSource;

    private void Start()
    {
        missVarStore = MissionVarStore.instance;
        missionTerminalUI.SetActive(false);
        oldMaterial = baseRenderer.material;
        UpdateMissionList();
    }

    public void UpdateMissionList()
    {
        currentMissions.Clear();
        foreach (MissionItem mission in missionStorage)
        {
            mission.gameObject.SetActive(false);
            if (missVarStore.overallMissionProgress >= mission.progressStage)
            {
                currentMissions.Add(mission);
            }
        }

        foreach (MissionItem mission in currentMissions)
        {
            mission.OnMissionVisible();
        }
    }

    public override void interact()
    {
        missionTerminalUI.SetActive(true);
    }

    public override void OnMouseOver()
    {
        baseRenderer.material = newMaterial;
        lightSource.SetActive(true);
    }

    public override void OnMouseExit()
    {
        baseRenderer.material = oldMaterial;
        lightSource.SetActive(false);
    }

    public void OnSelect()
    {
        //Set the correct active text box
        foreach (MissionItem mission in currentMissions)
        {
            mission.missionTextObject.SetActive(false);
        }
        selectedMission.missionTextObject.SetActive(true);

        //Set the variablestore objectives
        missVarStore.ClearObjectives();
        foreach (MissionObjective mission in selectedMission.missionObject.objectives)
        {
            missVarStore.objectives.Add(mission);
        }
    }

    public void EnterMission()
    {
        CloseWindow();
        uiButtons.activateHubButton();
        SceneManager.LoadScene(selectedMission.sceneLoad);
    }

    public void CloseWindow()
    {
        missionTerminalUI.SetActive(false);
    }
}
