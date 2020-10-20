using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Skill")]
public class Skill : Item
{
    public CharClass classRequired;
    public float cooldown;
    public int damage;
    public int boonDuration;
    public int hexDuration;
}
