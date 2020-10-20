using UnityEngine;

[CreateAssetMenu(fileName = "New Mission", menuName = "Mission")]
public class Mission : ScriptableObject
{
    public string missionName;
    public Difficulty diff;
    public string missionDescription;
    public string sceneLoad;
    public int progressStage;
    public MissionObjective[] objectives;
}

public enum Difficulty { Common, Uncommon, Masterwork, Rare, Legendary, Unique }