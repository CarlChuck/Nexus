using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Bionetic")]
public class BioneticMod : Item
{
    [Header("BIONETIC")]
    [SerializeField] private BioneticEffect bEffect;
    public int duration = 0;
    public int amount = 0; //percentage of health healed, or percent of damage converted to health
    public float cooldown = 5f;

}
public enum BioneticEffect {Heal, HealOverTime, AoEHeal, Leech }