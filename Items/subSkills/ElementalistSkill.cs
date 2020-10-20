using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Skill/ElementalistSkill")]
public class ElementalistSkill : Skill
{
    public EleSkill eleSkill;
}

public enum EleSkill { LightningWarp, CrystalSkin, HealingRiver, Fog, Sandstorm, Static, EarthenArmour }
public enum EleType { Fire, Air, Earth, Water }
