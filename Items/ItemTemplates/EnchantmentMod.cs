using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Enchantment")]
public class EnchantmentMod : Item
{
    [Header("ENCHANTMENTS")]
    [SerializeField] private EnchantmentType eType;
    public int amount;

}
public enum EnchantmentType {ElementRegen }