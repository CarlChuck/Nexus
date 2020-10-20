using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStatUpdater : MonoBehaviour
{
    public Text cClass;
    public Text classTitle;
    public Text classDesc;
    public Text classArcheType;
    public Text classBackground;

    public MCharStats charStats;
    public EnumsToString eToString;

    void Update ()
    {
        cClass.text = eToString.CharClassToString(charStats.cClass);

        classTitle.text = cClass.text;

        if (charStats.selectedClass != null)
        {
            classDesc.text = charStats.selectedClass.classDescription;
            classArcheType.text = eToString.CharArcheTypeToString(charStats.selectedClass.aType);
            classBackground.text = eToString.CharBackgroundToString(charStats.selectedClass.aBackground);
        }
    }
}
