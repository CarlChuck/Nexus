using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;
    public string objName;

    public override void interact()
    {
        DialogueSystem.Instance.addNewDialogue(dialogue, objName);
    }
}
