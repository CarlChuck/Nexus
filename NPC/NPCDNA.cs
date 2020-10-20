using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UMA.CharacterSystem;

public class NPCDNA : MonoBehaviour
{
    //private DynamicCharacterAvatar avatar;
    //private Dictionary<string, DnaSetter> npcDNA;

    [SerializeField] private DNAScriptObj dnaObj;

    void Start()
    {
        //avatar = GetComponent<DynamicCharacterAvatar>();
    }

    private void StartDNA()
    {
        /*npcDNA = avatar.GetDNA();
        foreach (KeyValuePair<string, DnaSetter> dnaEntry in dnaObj.dna)
        {
            float dnaValue = dnaEntry.Value.Value;
            npcDNA[dnaEntry.Key].Set(dnaValue);
        }*/
    }
}
