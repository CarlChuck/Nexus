using UnityEngine;

[CreateAssetMenu(fileName = "New Class", menuName = "ClassObject")]
public class ClassDataObject : ScriptableObject
{
    new public string name = "New Class";
    public CharClass cClass;
    public string classDescription = "Class Description";
    public Background aBackground;
    public ArcheType aType;
}

public enum Background { Arcane, Tech, Street }

public enum ArcheType { Tank, Support, Control, Healing}
