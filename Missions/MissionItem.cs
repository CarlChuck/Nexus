using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MissionItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Difficulty diff;
    public string sceneLoad;
    public int progressStage;
    public GameObject missionTextObject;
    public TextMeshProUGUI missionText;
    private Sprite basePic;
    public Sprite mouseOverPic; 
    public Mission missionObject;
    MissionTerminal missions;
    LootSystemManager lootSys;


    public void Start()
    {
        missions = MissionTerminal.instance;
        lootSys = LootSystemManager.instance;
        missionTextObject.SetActive(false);
        sceneLoad = missionObject.sceneLoad;
        progressStage = missionObject.progressStage;
        basePic = gameObject.GetComponent<Image>().sprite;
        diff = missionObject.diff;
        missionText.text = missionObject.missionDescription;
    }

    public void OnMissionVisible()
    {
        gameObject.SetActive(true);
    }

    public void SelectMission()
    {
        missions.selectedMission = this;
        //lootSys.LootTier = setLootLevel();
    }

    public void OnPointerEnter(PointerEventData pointerData)
    {
        gameObject.GetComponent<Image>().sprite = mouseOverPic;
    }

    public void OnPointerExit(PointerEventData pointerData)
    {
        gameObject.GetComponent<Image>().sprite = basePic;
    }

    public void OnPointerDown(PointerEventData pointerData)
    {
        SelectMission();
        //TODO Keep sprite on selection.
    }

    public void OnPointerUp(PointerEventData pointerData)
    {
        missions.OnSelect();
    }

    public int setLootLevel()
    {
        switch (diff)
        {
            case Difficulty.Common:
                return 1;
            case Difficulty.Uncommon:
                return 2;
            case Difficulty.Masterwork:
                return 3;
            case Difficulty.Rare:
                return 4;
            case Difficulty.Legendary:
                return 5;
            case Difficulty.Unique:
                return 6;
            default:
                return 1;
        }
    }
}

