using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Cybernetic")]
public class CyberneticMod : Item
{
    [Header("CYBERNETIC")]
    public CyberneticType cType;
    public int duration = 0;
    public float cooldown = 0;

}
public enum CyberneticType {Dodge, AttkSpeed, CorruptResist, Armour }