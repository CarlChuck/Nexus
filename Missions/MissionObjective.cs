using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MissionObjective", menuName = "MissionObjective")]
public class MissionObjective : ScriptableObject
{
    [SerializeField] private string description;
    private bool complete;

    private void Start()
    {
        complete = false;
    }

    public void OnComplete()
    {
        complete = true;
    }

    public bool IsComplete()
    {
        return complete;
    }
}
