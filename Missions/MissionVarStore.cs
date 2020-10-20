using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionVarStore : MonoBehaviour
{
    public int overallMissionProgress; //TODO
    public List<MissionObjective> objectives;
    public bool complete;
    private MissionTerminal missions;

    #region Singleton
    public static MissionVarStore instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public void Start()
    {
        missions = MissionTerminal.instance;
    }

    public void ClearObjectives()
    {
        objectives.Clear();
    }

    public void OnEnter()
    {
        missions.EnterMission();
        //TODO activate mission progress UI.
    }

    public void OnComplete()
    {
        //TODO activate mission complete UI with reward window.
    }
}
