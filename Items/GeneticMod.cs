using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Genetic")]
public class GeneticMod : Item
{
    [Header("GENETIC")]
    [SerializeField] private GeneticType gType;
    public int amount;

    public GeneticType GetGeneticType()
    {
        return gType;
    }
}
public enum GeneticType {Regeneration, Feedback, Leech, XpGain, Luck, Armour }