using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    public StatBlock owner;
    public StatBlock appliedBy;
    public HexName hexName;
    public float duration;
    public int damageIfDot;
    public DamageStat dStat;
    public bool freeze = false;

    private void Start()
    {
        //TODO add UI element
        name = hexName.ToString();
        duration *= (appliedBy.persistence.GetValue() / 100);

        if (hexName == HexName.Burn)
        {
            owner.HasBurnHex(appliedBy, GetDamageofDot(), GetDamageStat());
        }
        if (hexName == HexName.Electrocute)
        {
            owner.HasElectrocuteHex(appliedBy, GetDamageofDot(), GetDamageStat());
        }
        if (hexName == HexName.Irradiate)
        {
            Debug.Log("Irradiate initiated");
            owner.HasIrradiateHex(appliedBy, GetDamageofDot(), GetDamageStat());
        }
        if (hexName == HexName.Bleed)
        {
            owner.HasBleedHex(appliedBy, GetDamageofDot(), GetDamageStat());
        }
        if (hexName == HexName.Stun)
        {
            owner.HasStunHex();
            owner.OnStunned(duration, freeze);

        }
    }

    private void FixedUpdate()
    {
        duration -= Time.fixedDeltaTime;
        if (duration < 0)
        {
            EndHex();
        }
    }

    public void EndHex()
    {
        //TODO remove UI element
        if (hexName == HexName.Stun)
        {
            owner.OnStunEnd();
        }
        owner.hexes.Remove(owner.GetHex(hexName));
        Destroy(gameObject);
    }

    public int GetDamageStat()
    {
        int damageStat;
        switch (dStat)
        {
            case DamageStat.Strength:
                damageStat = appliedBy.strength.GetValue() + appliedBy.HasPowerBoon() - appliedBy.HasWeakenHex();
                break;
            case DamageStat.Marksmanship:
                damageStat = appliedBy.marksmanship.GetValue() + appliedBy.HasPowerBoon() - appliedBy.HasWeakenHex();
                break;
            case DamageStat.Arcana:
                damageStat = appliedBy.arcana.GetValue() + appliedBy.HasPowerBoon() - appliedBy.HasWeakenHex();
                break;
            default:
                damageStat = appliedBy.strength.GetValue() + appliedBy.HasPowerBoon() - appliedBy.HasWeakenHex();
                break;
        }
        return damageStat;
    }

    public int GetDamageofDot()
    {
        int damage = (damageIfDot + appliedBy.affliction.GetValue()) / 5;
        return damage;
    }
}