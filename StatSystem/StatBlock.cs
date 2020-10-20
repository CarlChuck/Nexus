using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Contains the stats for a character */

public class StatBlock : MonoBehaviour
{
    //Health and Primary Skills
    public Stat vitality;
    public int currentHealth { get; protected set; }
    public Stat armour;
    public Stat strength;
    public Stat marksmanship;
    public Stat arcana;

    //Defence Skills
    public Stat fireResistance;
    public Stat shockResistance;
    public Stat radResistance;
    public Stat physicalResistance;

    //Secondary Skills
    public Stat movement;
    public Stat speed;
    public Stat ferocity;
    public Stat devastation;
    public Stat affliction;
    public Stat persistence;
    public Stat luck;

    //Hidden Skills
    public Stat physDamage;
    public Stat fireDamage;
    public Stat shockDamage;
    public Stat radDamage;

    public List<Boon> boons;
    public List<Hex> hexes;

    public Boon boonTemplate;
    public Hex hexTemplate;

    public GameObject onHitEffect;

    [SerializeField] private float takeDamageTimer;
    [SerializeField] private float takeDamageCooldown;


    // Start with max HP.
    public virtual void Start()
    {
        takeDamageCooldown = 0.2f;
        currentHealth = vitality.GetValue();
        //boonTemplate = Resources.Load("BoonHexes/Boon") as Boon;
        //hexTemplate = Resources.Load("BoonHexes/Hex") as Hex;
    }
    public virtual void Update()
    {
        UpdateTakeDamageTimer();
    }
    public float HealthAsPercentage
    {
        get
        {
            return (float)currentHealth / (float)vitality.GetValue();
        }
    }

    //Apply damage calculation
    public virtual void TakeDamage(StatBlock attacker, int weapDamage, int damageStat, DamageType dType, int dTypeValue, bool hasCrit)
    {
        if (takeDamageTimer < 0)
        {
            int attackerDevastation = attacker.devastation.GetValue();

            if (HasReflectionBoon())
            {
                attacker.TakeDamage(attacker, weapDamage, damageStat, dType, dTypeValue, hasCrit);
                GetBoon(BoonName.Reflection).EndBoon();
            }
            else
            {
                if (HasFeedbackBoon())
                {
                    attacker.TakeDamageFinal(5, attacker);
                }
                int armourValue = armour.GetValue() + HasDefenceBoon();
                int damage = (weapDamage + (weapDamage * (damageStat - armourValue) / 100)) * (dTypeValue / 100);

                if (hasCrit == true)
                {
                    damage = damage + ((damage * attackerDevastation) / 100);
                }

                if (dType == DamageType.Fire)
                {
                    damage = damage - (damage * ((fireResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                    TakeDamageFinal(damage, attacker);
                }
                else if (dType == DamageType.Shock)
                {
                    damage = damage - (damage * ((shockResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                    TakeDamageFinal(damage, attacker);
                }
                else if (dType == DamageType.Physical)
                {
                    damage = damage - (damage * ((physicalResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                    TakeDamageFinal(damage, attacker);
                }
                else if (dType == DamageType.Radiation)
                {
                    damage = damage - (damage * ((radResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                    TakeDamageFinal(damage, attacker);
                }
            }
        }
    }

    //Run damage through Critical Hits formula
    public bool CriticalHitCalc()
    {
        int critChance = ferocity.GetValue() + HasPrecisionBoon();
        if (Random.Range(0, 100) < critChance)
        {
            return true;
        }
        return false;
    }

    // Damage the character
    public virtual void TakeDamageFinal(int damage, StatBlock attacker)
    {
        // limit damage taken within bounds
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        // Subtract final damage from health
        int energyShield = HasShieldingBoon();
        if (energyShield > 0)
        {
            if (energyShield > damage)
            {
                GetBoon(BoonName.Shielding).energyShield -= damage;
            }
            else if (damage >= energyShield)
            {
                damage -= energyShield;
                GetBoon(BoonName.Shielding).EndBoon();
                currentHealth -= damage;
            }
        }
        else
        {
            currentHealth -= damage;
        }
        Debug.Log(transform.name + " takes " + damage + " damage.");

        // If we hit 0. Die.
        if (currentHealth <= 0)
        {
            OnDeath();
        }

        if (HasDazeHex())
        {
            GetHex(HexName.Daze).EndHex();
        }

        ResetTakeDamageCooldown();
        UpdateHealth();

        if (damage > 0)
        {
            OnHitByProjectile();
        }
    }

    public void DealDamage(StatBlock target, int wDamage, DamageStat dStat, DamageType dType)
    {
        int dTypeValue = 100;
        int damageStat = 0;
        bool hasCrit = CriticalHitCalc();

        if (GetBoon(BoonName.Stealth) != null)
        {
            GetBoon(BoonName.Stealth).EndBoon();
        }

        switch (dStat)
        {
            case DamageStat.Strength:
                damageStat = strength.GetValue() + HasPowerBoon() - HasWeakenHex();
                break;
            case DamageStat.Marksmanship:
                damageStat = marksmanship.GetValue() + HasPowerBoon() - HasWeakenHex();
                break;
            case DamageStat.Arcana:
                damageStat = arcana.GetValue() + HasPowerBoon() - HasWeakenHex();
                break;
            default:
                damageStat = strength.GetValue();
                Debug.Log("NO DAMAGE STAT ASSIGNED TO ATTACK");
                break;
        }

        switch (dType)
        {
            case DamageType.Fire:
                dTypeValue = fireDamage.GetValue() + HasRendBoon();
                break;
            case DamageType.Shock:
                dTypeValue = shockDamage.GetValue() + HasRendBoon();
                break;
            case DamageType.Radiation:
                dTypeValue = radDamage.GetValue() + HasRendBoon();
                break;
            case DamageType.Physical:
                dTypeValue = physDamage.GetValue() + HasRendBoon();
                break;
            default:
                dTypeValue = physDamage.GetValue() + HasRendBoon();
                Debug.Log("NO DAMAGE TYPE ASSIGNED TO ATTACK");
                break;
        }
        if (GetHex(HexName.Blind) != null)
        {
            target.TakeDamage(this, 0, damageStat, dType, dTypeValue, hasCrit);
            GetHex(HexName.Blind).EndHex();
        }
        else if (HasIntimidateHex())
        {
            target.TakeDamage(this, 0, damageStat, dType, dTypeValue, hasCrit);
        }
        else
        {
            target.TakeDamage(this, wDamage, damageStat, dType, dTypeValue, hasCrit);
        }

    }

    // Heal the character.
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, vitality.GetValue());
        UpdateHealth();
    }

    public virtual void UpdateHealth()
    {
        //To Override
    }
    public void OnHitByProjectile()
    {
        //GameObject onHitVFX = Instantiate(onHitEffect, gameObject.transform);
        if (onHitEffect != null)
        {
            _ = Instantiate(onHitEffect, gameObject.transform);
        }
    }
    public virtual void OnDeath()
    {
        //To Override
    }
    public virtual void OnStunned(float timer, bool freeze = true)
    {
        //To Override
    }
    public virtual void OnStunEnd()
    {
        //To Override
    }

    //BOON checks, each tailored for their use cases
    public int HasResistanceBoon()
    {
        if (GetBoon(BoonName.Resistance) != null)
        {
            return 20;
        }
        else
        {
            return 0;
        }
    }
    public float HasVelocityBoon()
    {
        if (GetBoon(BoonName.Velocity) != null)
        {
            return 0.66f;
        }
        else
        {
            return 1f;
        }
    }
    public float HasSwiftnessBoon()
    {
        if (GetBoon(BoonName.Swiftness) != null)
        {
            return 33f;
        }
        else
        {
            return 0f;
        }
    }//TODO add to enemy
    public int HasPowerBoon()
    {
        if (GetBoon(BoonName.Power) != null)
        {
            return 20;
        }
        else
        {
            return 0;
        }
    }
    public int HasDefenceBoon()
    {
        if (GetBoon(BoonName.Defence) != null)
        {
            return 20;
        }
        else
        {
            return 0;
        }
    }
    public bool HasReflectionBoon()
    {
        if (GetBoon(BoonName.Reflection) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int HasPrecisionBoon()
    {
        if (GetBoon(BoonName.Precision) != null)
        {
            return 20;
        }
        else
        {
            return 0;
        }
    }
    public int HasShieldingBoon()
    {
        if (GetBoon(BoonName.Shielding) != null)
        {
            return GetBoon(BoonName.Shielding).energyShield;
        }
        else
        {
            return 0;
        }
    }
    public void HasRegenerationBoon(int regenHit = 5, float waitTime = 1f)
    {
        if (GetBoon(BoonName.Regeneration) != null)
        {
            StartCoroutine(RunRegeneration(regenHit, waitTime));
        }
    }
    public int HasRendBoon()
    {
        if (GetBoon(BoonName.Rend) != null)
        {
            return 20;
        }
        else
        {
            return 0;
        }
    }
    public bool HasFeedbackBoon()
    {
        if (GetBoon(BoonName.Feedback) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool HasStealthBoon()
    {
        if (GetBoon(BoonName.Stealth) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }//TODO add custom shader, and enemy AI unable to add this person as a target
    IEnumerator RunRegeneration(int regen, float waitTime)
    {
        Heal(regen);
        yield return new WaitForSeconds(waitTime);
        HasRegenerationBoon(regen);
    }

    //HEX checks, each tailored for their use cases
    public int HasVulnerabilityHex()
    {
        if (GetHex(HexName.Vulnerability) != null)
        {
            return 20;
        }
        else
        {
            return 0;
        }
    }
    public float HasSlowHex()
    {
        if (GetHex(HexName.Slow) != null)
        {
            return 1.5f;
        }
        else
        {
            return 1f;
        }
    }
    public float HasSnareHex()
    {
        if (GetHex(HexName.Snare) != null)
        {
            return 33f;
        }
        else
        {
            return 0f;
        }
    }
    public int HasWeakenHex()
    {
        if (GetHex(HexName.Weaken) != null)
        {
            return 20;
        }
        else
        {
            return 0;
        }
    }
    public bool HasBlindHex()
    {
        if (GetHex(HexName.Blind) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool HasIntimidateHex()
    {
        if (GetHex(HexName.Intimidate) != null)
        {
            if (Random.Range(1, 100) < 25)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public bool HasFearHex()
    {
        if (GetHex(HexName.Fear) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }//TODO add enemy AI state
    public int HasPinHex()
    {
        if (GetHex(HexName.Pin) != null)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }//TODO change movement on enemy
    public bool HasCharmHex()
    {
        if (GetHex(HexName.Charm) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }//TODO add enemy AI state
    public bool HasDazeHex()
    {
        if (GetHex(HexName.Daze) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }//TODO use the stun effect but break on damage
    public bool HasStunHex()
    {
        if (GetHex(HexName.Stun) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }//TODO make a stun effect
    public bool HasTauntHex()
    {
        if (GetHex(HexName.Taunt) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }//TODO add enemy AI target change
    public void HasBurnHex(StatBlock attacker, int weapDamage, int damageStat, float waitTime = 1f)
    {
        if (GetHex(HexName.Burn) != null)
        {
            DamageType dType = DamageType.Fire;
            int dTypeValue = attacker.fireDamage.GetValue() + attacker.HasRendBoon();
            bool hasCrit = attacker.CriticalHitCalc();
            StartCoroutine(RunBurnHex(attacker, weapDamage, damageStat, dType, dTypeValue, hasCrit, waitTime));
        }
    }
    public void HasElectrocuteHex(StatBlock attacker, int weapDamage, int damageStat, float waitTime = 1f)
    {
        if (GetHex(HexName.Electrocute) != null)
        {
            DamageType dType = DamageType.Shock;
            int dTypeValue = attacker.shockDamage.GetValue() + attacker.HasRendBoon();
            bool hasCrit = attacker.CriticalHitCalc();
            StartCoroutine(RunElectrocuteHex(attacker, weapDamage, damageStat, dType, dTypeValue, hasCrit, waitTime));
        }
    }
    public void HasIrradiateHex(StatBlock attacker, int weapDamage, int damageStat, float waitTime = 1f)
    {
        if (GetHex(HexName.Irradiate) != null)
        {
            DamageType dType = DamageType.Radiation;
            int dTypeValue = attacker.radDamage.GetValue() + attacker.HasRendBoon();
            bool hasCrit = attacker.CriticalHitCalc();
            StartCoroutine(RunIrradiateHex(attacker, weapDamage, damageStat, dType, dTypeValue, hasCrit, waitTime));
        }
    }
    public void HasBleedHex(StatBlock attacker, int weapDamage, int damageStat, float waitTime = 1f)
    {
        if (GetHex(HexName.Bleed) != null)
        {
            DamageType dType = DamageType.Physical;
            int dTypeValue = attacker.physDamage.GetValue() + attacker.HasRendBoon();
            bool hasCrit = attacker.CriticalHitCalc();
            StartCoroutine(RunBleedHex(attacker, weapDamage, damageStat, dType, dTypeValue, hasCrit, waitTime));
        }
    }
    IEnumerator RunBurnHex(StatBlock attacker, int weapDamage, int damageStat, DamageType dType, int dTypeValue, bool hasCrit, float waitTime)
    {
        TakeDamage(attacker, weapDamage, damageStat, dType, dTypeValue, hasCrit);
        yield return new WaitForSeconds(waitTime);
        HasBurnHex(attacker, weapDamage, damageStat, waitTime);
    }
    IEnumerator RunElectrocuteHex(StatBlock attacker, int weapDamage, int damageStat, DamageType dType, int dTypeValue, bool hasCrit, float waitTime)
    {
        TakeDamage(attacker, weapDamage, damageStat, dType, dTypeValue, hasCrit);
        yield return new WaitForSeconds(waitTime);
        HasElectrocuteHex(attacker, weapDamage, damageStat, waitTime);
    }
    IEnumerator RunIrradiateHex(StatBlock attacker, int weapDamage, int damageStat, DamageType dType, int dTypeValue, bool hasCrit, float waitTime)
    {
        TakeDamage(attacker, weapDamage, damageStat, dType, dTypeValue, hasCrit);
        yield return new WaitForSeconds(waitTime);
        HasIrradiateHex(attacker, weapDamage, damageStat, waitTime);
    }
    IEnumerator RunBleedHex(StatBlock attacker, int weapDamage, int damageStat, DamageType dType, int dTypeValue, bool hasCrit, float waitTime)
    {
        TakeDamage(attacker, weapDamage, damageStat, dType, dTypeValue, hasCrit);
        yield return new WaitForSeconds(waitTime);
        HasBleedHex(attacker, weapDamage, damageStat, waitTime);
    }

    public void AddBoon(BoonName boonName, StatBlock applier, float dur, int eShield = 20)
    {
        if (GetBoon(boonName) != null)
        {
            Boon boon = GetBoon(boonName);
            if (dur > boon.duration)
            {
                boon.duration = dur;
                boon.appliedBy = applier;
                if (boonName == BoonName.Shielding)
                {
                    boon.energyShield = eShield;
                }
            }
        }
        else
        {
            Boon newBoon = Instantiate(boonTemplate);
            newBoon.boonName = boonName;
            newBoon.duration = dur;
            newBoon.owner = this;
            newBoon.appliedBy = applier;
            if (boonName == BoonName.Shielding)
            {
                newBoon.energyShield = eShield;
            }
            boons.Add(newBoon);
        }
    }
    public void AddHex(HexName hexName, StatBlock attacker, float dur, DamageStat dStat = DamageStat.Strength, int dotDamage = 0)
    {
        if (GetHex(hexName) != null)
        {
            Hex hex = GetHex(hexName);
            if (dur > hex.duration)
            {
                hex.duration = dur;
                hex.appliedBy = attacker;
                hex.dStat = dStat;
                hex.damageIfDot = dotDamage;
            }
        }
        else
        {
            Hex newHex = Instantiate(hexTemplate);
            newHex.duration = dur;
            newHex.owner = this;
            newHex.hexName = hexName;
            newHex.appliedBy = attacker;
            newHex.dStat = dStat;
            newHex.damageIfDot = dotDamage;
            hexes.Add(newHex);
        }
    }

    public void ClearBoons()
    {
        foreach (Boon boon in boons)
        {
            boon.EndBoon();
        }
    }
    public void ClearHexes()
    {
        foreach (Hex hex in hexes)
        {
            hex.EndHex();
        }
    }
    public Boon GetBoon(BoonName bName)
    {
        foreach (Boon boon in boons)
        {
            if (boon.boonName == bName)
            {
                return boon;
            }
        }
        return null;
    }
    public Hex GetHex(HexName hName)
    {
        foreach (Hex hex in hexes)
        {
            if (hex.hexName == hName)
            {
                return hex;
            }
        }
        return null;
    }

    public void UpdateTakeDamageTimer()
    {
        takeDamageTimer -= Time.deltaTime;
    }

    public void ResetTakeDamageCooldown()
    {
        takeDamageTimer = takeDamageCooldown;
    }
}
public enum CharClass { Blank, Golemancer, Elementalist, Psyc, Mystic, Crypter, Apoch, Artificer, NanoMage, Vigil, Shadow, Envoy, StreetDoctor }
public enum BoonName { Blank, Resistance, Velocity, Swiftness, Power, Defence, Reflection, Precision, Shielding, Regeneration, Rend, Feedback, Stealth }
public enum HexName { Blank, Vulnerability, Slow, Snare, Weaken, Blind, Intimidate, Fear, Pin, Charm, Daze, Stun, Taunt, Burn, Electrocute, Irradiate, Bleed }
public enum DamageStat { Strength, Marksmanship, Arcana }