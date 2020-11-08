using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Cybernetic")]
public class CyberneticMod : Item
{
    [Header("CYBERNETIC")]
    [SerializeField] private CyberneticType cType;
    public int duration = 0;
    public float cooldown = 0;

    public CyberneticType GetCyberneticType()
    {
        return cType;
    }
}
public enum CyberneticType {Dodge, AttkSpeed, CorruptResist, Armour }