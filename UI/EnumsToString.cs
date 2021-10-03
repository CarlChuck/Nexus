using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumsToString : MonoBehaviour
{
    public string CharClassToString(CharClass cClass)
    {
        switch (cClass)
        {
            case CharClass.Golemancer:
                return "Golemancer";
            case CharClass.Elementalist:
                return "Elementalist";
            case CharClass.Psyc:
                return "Psyc";
            case CharClass.Mystic:
                return "Mystic";
            case CharClass.Crypter:
                return "Crypter";
            case CharClass.Artificer:
                return "Artificer";
            case CharClass.Apoch:
                return "Apoch";
            case CharClass.NanoMage:
                return "Nano Mage";
            case CharClass.Vigil:
                return "Vigil";
            case CharClass.Shadow:
                return "Shadow";
            case CharClass.Guardian:
                return "Guardian";
            case CharClass.StreetDoctor:
                return "Street Doctor";
            default:
                return "Blank";
        }

    }

    public string CharArcheTypeToString(ArcheType aType)
    {
        switch (aType)
        {
            case ArcheType.Tank:
                return "Tank";
            case ArcheType.Control:
                return "Control";
            case ArcheType.Support:
                return "Support";
            case ArcheType.Healing:
                return "Healing";
            default:
                return "Error";
        }
    }

    public string CharBackgroundToString(Background aBackground)
    {
        switch (aBackground)
        {
            case Background.Arcane:
                return "Arcane";
            case Background.Tech:
                return "Technology";
            case Background.Street:
                return "Streets";
            default:
                return "Error";
        }
    }
}
