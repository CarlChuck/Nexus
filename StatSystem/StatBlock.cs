using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Contains the stats for a character */

public class StatBlock : MonoBehaviour
{
    public int level;
    #region Stat Variables
    //Health and Primary Skills
    public Stat vitality;
    public int currentHealth { get; protected set; }
    public int armourIncreasePercentage;
    public int totalArmour;
    public Stat armour;
    public Stat block;
    public Stat strength;
    public Stat marksmanship;
    public Stat arcana;

    //Secondary Skills
    public Stat movement;
    public Stat speed;
    public Stat ferocity;
    public Stat devastation;
    public Stat affliction;
    public Stat persistence;
    public Stat luck;
    public int xpModifier;
    public Stat leech;
    public Stat regen;
    public Stat feedback;

    //Resistances
    public Stat thermalResistance;
    public Stat cryoResistance;
    public Stat shockResistance;
    public Stat radiationResistance;
    public Stat psiResistance;
    public Stat dimensionResistance;
    public Stat kineticResistance;
    public Stat poisonResistance;
    public Stat bioResistance;
    public Stat corruptionResistance;

    //Hidden Skills
    public Stat thermalDamage;
    public Stat cryoDamage;
    public Stat shockDamage;
    public Stat radiationDamage;
    public Stat psiDamage;
    public Stat dimensionDamage;
    public Stat kineticDamage;
    public Stat poisonDamage;
    public Stat bioDamage;
    public Stat corruptionDamage;
    #endregion

    #region prefabs/variables
    public List<Boon> boons;
    public List<Hex> hexes;

    public Boon boonTemplate;
    public Hex hexTemplate;

    public GameObject onHitEffect;
    [SerializeField] private GameObject FloatingDamage;

    [SerializeField] private float takeDamageTimer;
    [SerializeField] private float takeDamageCooldown;
    #endregion

    #region Initialisation and Update
    // Start with max HP.
    public virtual void Start()
    {
        takeDamageCooldown = 0.2f;
        currentHealth = vitality.GetValue();
        armourIncreasePercentage = 0;
        NaturalRegen();
        level = 1;
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
    public void SetTotalArmour()
    {
        totalArmour = (armour.GetValue() + ((armour.GetValue() / 100) * armourIncreasePercentage)) + ((strength.GetValue()) * 5);
    }
    #endregion

    #region Damage Calculation
    //To Deal Damage
    public void DealDamage(StatBlock target, DamageStat dStat, Weapon weap, float multiplier)
    {
        //Get Weapon Damage and Critical
        bool hasCrit = CriticalHitCalc();
        float thermal = Random.Range(weap.finalThermalMin, weap.finalThermalMax + 1);
        float cryo = Random.Range(weap.finalCryoMin, weap.finalCryoMax + 1);
        float shock = Random.Range(weap.finalShockMin, weap.finalShockMax + 1);
        float radiation = Random.Range(weap.finalRadMin, weap.finalRadMax + 1);
        float psi = Random.Range(weap.finalPsiMin, weap.finalPsiMax + 1);
        float dimensional = Random.Range(weap.finalDimensionMin, weap.finalDimensionMax + 1);
        float kinetic = Random.Range(weap.finalKineticMin, weap.finalKineticMax + 1);
        float poison = Random.Range(weap.finalPoisonMin, weap.finalPoisonMax + 1);
        float bio = Random.Range(weap.finalBioMin, weap.finalBioMax + 1);
        float corruption = Random.Range(weap.finalCorruptionMin, weap.finalCorruptionMax + 1);

        if (hasCrit == true)
        {
            thermal += thermal * (devastation.GetValue() / 100);
            cryo += cryo * (devastation.GetValue() / 100);
            shock += shock * (devastation.GetValue() / 100);
            radiation += radiation * (devastation.GetValue() / 100);
            psi += psi * (devastation.GetValue() / 100);
            dimensional += dimensional * (devastation.GetValue() / 100);
            kinetic += kinetic * (devastation.GetValue() / 100);
            poison += poison * (devastation.GetValue() / 100);
            bio += bio * (devastation.GetValue() / 100);
            corruption += corruption * (devastation.GetValue() / 100);
        }

        if (GetBoon(BoonName.Stealth) != null)
        {
            GetBoon(BoonName.Stealth).EndBoon();
        }

        //Add Stat Damage
        int damageStat = 0;
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
        }
        float finalThermal = (thermal + (thermal * (damageStat / 100) * ((thermalDamage.GetValue() + HasRendBoon()) / 100))) * multiplier;
        float finalCryo = (cryo + (cryo * (damageStat / 100) * ((cryoDamage.GetValue() + HasRendBoon()) / 100))) * multiplier;
        float finalShock = (shock + (shock * (damageStat / 100) * ((shockDamage.GetValue() + HasRendBoon()) / 100))) * multiplier;
        float finalRadiation = (radiation + (radiation * (damageStat / 100) * ((radiationDamage.GetValue() + HasRendBoon()) / 100))) * multiplier;
        float finalPsi = (psi + (psi * (damageStat / 100) * ((psiDamage.GetValue() + HasRendBoon()) / 100))) * multiplier;
        float finalDimensional = (dimensional + (dimensional * (damageStat / 100) * ((dimensionDamage.GetValue() + HasRendBoon()) / 100))) * multiplier;
        float finalKinetic = (kinetic + (kinetic * (damageStat / 100) * ((kineticDamage.GetValue() + HasRendBoon()) / 100))) * multiplier;
        float finalPoison = (poison + (poison * (damageStat / 100) * ((poisonDamage.GetValue() + HasRendBoon()) / 100))) * multiplier;
        float finalBio = (bio + (bio * (damageStat / 100) * ((bioDamage.GetValue() + HasRendBoon()) / 100))) * multiplier;
        float finalCorruption = (corruption + (corruption * (damageStat / 100) * ((corruptionDamage.GetValue() + HasRendBoon()) / 100))) * multiplier;

        //Apply Damage, and get HexBlind HexIntimidate miss chance
        if (GetHex(HexName.Blind) != null)
        {
            target.TakeDamage(target, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            GetHex(HexName.Blind).EndHex();
        }
        else if (HasIntimidateHex())
        {
            target.TakeDamage(target, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
        else
        {
            target.TakeDamage(target, finalThermal, finalCryo, finalShock, finalRadiation, finalPsi, finalDimensional, finalKinetic, finalPoison, finalBio, finalCorruption);
        }

    }

    //To Recieve Damage
    public virtual void TakeDamage(StatBlock attacker, float thermDamage, float cryoDamage, float shockDamage, float radDamage, float psiDamage, float dimensionDamage, 
        float kineticDamage, float poisonDamage, float bioDamage, float corruptionDamage)
    {

        if (takeDamageTimer < 0)
        {
            float thermal = thermDamage;
            float cryo = cryoDamage;
            float shock = shockDamage;
            float radiation = radDamage;
            float psi = psiDamage;
            float dimensional = dimensionDamage;
            float kinetic = kineticDamage;
            float poison = poisonDamage;
            float bio = bioDamage;
            float corruption = corruptionDamage;
            float damage;

            if (HasReflectionBoon())
            {
                attacker.TakeDamage(attacker, thermal, cryo, shock, radiation, psi, dimensional, kinetic, poison, bio, corruption);
                GetBoon(BoonName.Reflection).EndBoon();
            }
            else
            {
                if (feedback.GetValue() >= 1)
                {
                    attacker.TakeDamageFinal(attacker, feedback.GetValue() + HasFeedbackBoon());
                }
                int armourValue = armour.GetValue() + HasDefenceBoon();

                thermal -= (thermal * ((thermalResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                cryo -= (cryo * ((thermalResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                shock -= (shock * ((thermalResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                radiation -= (radiation * ((thermalResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                psi -= (psi * ((thermalResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                dimensional -= (dimensional * ((thermalResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                kinetic -= (kinetic * ((thermalResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                poison -= (poison * ((thermalResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                bio -= (bio * ((thermalResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));
                corruption -= (corruption * ((thermalResistance.GetValue() + HasResistanceBoon() - HasVulnerabilityHex()) / 100));


                damage = (thermal + cryo + shock + radiation + psi + dimensional + kinetic + poison + bio + corruption);
                damage -= damage * ArmourMitigation(attacker.level);
                TakeDamageFinal(attacker, (int)damage);
            }
        }
    }

    //Damage the character
    public virtual void TakeDamageFinal(StatBlock attacker, int damage)
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
        TakeDamageFeedback(damage);

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

        LeechEffect(attacker, damage);
    }

    //Method to trigger events on taking damage (such as damage numbers flying up off enemies)
    public virtual void TakeDamageFeedback(int damage)
    {
        FloatingDamageText(damage);
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

    public float ArmourMitigation(int attackerLevel)
    {
        float mitigation = totalArmour / ((attackerLevel * 50) + totalArmour);

        return mitigation;
    }

    private void LeechEffect(StatBlock attacker, int damage)
    {
        float leechAmount = (damage / 100) * attacker.leech.GetValue();
        attacker.Heal((int)leechAmount);
    }
    #endregion

    #region Healing And Health
    // Heal the character.
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, vitality.GetValue());
        UpdateHealth();
    }
    public void NaturalRegen()
    {
        int pRegen = regen.GetValue();

        if (HasRegenerationBoon())
        {
            pRegen = regen.GetValue() + (vitality.GetValue() / 200);
        }

        StartCoroutine(RunNaturalRegen(pRegen));

    }
    IEnumerator RunNaturalRegen(int regen)
    {
        if (currentHealth > 0 && currentHealth < vitality.baseValue)
        {
            Heal(regen);
        }
        yield return new WaitForSeconds(1f);
        NaturalRegen();
    }

    public virtual void UpdateHealth()
    {
        //To Override
    }
    #endregion

    #region OnHit OnDeath etc
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
        OnDeathExtra();
        //To Override
    }
    public virtual void OnDeathExtra()
    {
        //to override
    }
    private void FloatingDamageText(int damNum)
    {
        GameObject damageNumber = Instantiate(FloatingDamage, transform.position, Quaternion.identity, transform);
        FloatingDamage fDam = damageNumber.GetComponent<FloatingDamage>();
        fDam.OnActivate(damNum);
    }
    public virtual void OnStunned(float timer, bool freeze = true)
    {
        //To Override
    }
    public virtual void OnStunEnd()
    {
        //To Override
    }
    #endregion

    #region BOON checks, each tailored for their use cases
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
    public bool HasRegenerationBoon()
    {
        if (GetBoon(BoonName.Regeneration) != null)
        {
            return true;
        }
        else 
        { 
            return false; 
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
    public int HasFeedbackBoon()
    {
        if (GetBoon(BoonName.Feedback) != null)
        {
            return level;
        }
        else
        {
            return 0;
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

    #endregion

    #region HEX checks, each tailored for their use cases
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
    public void HasBurnHex(StatBlock attacker, int weapDamage, float waitTime = 1f)
    {
        if (GetHex(HexName.Burn) != null)
        {
            StartCoroutine(RunBurnHex(attacker, weapDamage, waitTime));
        }
    }
    public void HasChillHex(StatBlock attacker, int weapDamage, float waitTime = 1f)
    {
        if (GetHex(HexName.Chill) != null)
        {
            StartCoroutine(RunChillHex(attacker, weapDamage, waitTime));
        }
    }
    public void HasElectrocuteHex(StatBlock attacker, int weapDamage, float waitTime = 1f)
    {
        if (GetHex(HexName.Electrocute) != null)
        {
            StartCoroutine(RunElectrocuteHex(attacker, weapDamage, waitTime));
        }
    }
    public void HasIrradiateHex(StatBlock attacker, int weapDamage, float waitTime = 1f)
    {
        if (GetHex(HexName.Irradiate) != null)
        {
            StartCoroutine(RunIrradiateHex(attacker, weapDamage, waitTime));
        }
    }
    public void HasDeteriorateHex(StatBlock attacker, int weapDamage, float waitTime = 1f)
    {
        if (GetHex(HexName.Deteriorate) != null)
        {
            StartCoroutine(RunDeteriorateHex(attacker, weapDamage, waitTime));
        }
    }
    public void HasPhaseHex(StatBlock attacker, int weapDamage, float waitTime = 1f)
    {
        if (GetHex(HexName.Phase) != null)
        {
            StartCoroutine(RunPhaseHex(attacker, weapDamage, waitTime));
        }
    }
    public void HasBleedHex(StatBlock attacker, int weapDamage, float waitTime = 1f)
    {
        if (GetHex(HexName.Bleed) != null)
        {
            StartCoroutine(RunBleedHex(attacker, weapDamage, waitTime));
        }
    }
    public void HasDiseaseHex(StatBlock attacker, int weapDamage, float waitTime = 1f)
    {
        if (GetHex(HexName.Disease) != null)
        {
            StartCoroutine(RunDiseaseHex(attacker, weapDamage, waitTime));
        }
    }
    public void HasVirusHex(StatBlock attacker, int weapDamage, float waitTime = 1f)
    {
        if (GetHex(HexName.Virus) != null)
        {
            StartCoroutine(RunVirusHex(attacker, weapDamage, waitTime));
        }
    }
    public void HasCorruptHex(StatBlock attacker, int weapDamage, float waitTime = 1f)
    {
        if (GetHex(HexName.Corrupt) != null)
        {
            StartCoroutine(RunCorruptHex(attacker, weapDamage, waitTime));
        }
    }
    IEnumerator RunBurnHex(StatBlock attacker, int weapDamage, float waitTime)
    {
        TakeDamage(attacker, weapDamage, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        yield return new WaitForSeconds(waitTime);
        HasBurnHex(attacker, weapDamage,  waitTime);
    }
    IEnumerator RunChillHex(StatBlock attacker, int weapDamage, float waitTime)
    {
        TakeDamage(attacker, 0, weapDamage, 0, 0, 0, 0, 0, 0, 0, 0);
        yield return new WaitForSeconds(waitTime);
        HasBurnHex(attacker, weapDamage, waitTime);
    }
    IEnumerator RunElectrocuteHex(StatBlock attacker, int weapDamage,  float waitTime)
    {
        TakeDamage(attacker, 0, 0, weapDamage, 0, 0, 0, 0, 0, 0, 0);
        yield return new WaitForSeconds(waitTime);
        HasElectrocuteHex(attacker, weapDamage, waitTime);
    }
    IEnumerator RunIrradiateHex(StatBlock attacker, int weapDamage, float waitTime)
    {
        TakeDamage(attacker, 0, 0, 0, weapDamage, 0, 0, 0, 0, 0, 0);
        yield return new WaitForSeconds(waitTime);
        HasIrradiateHex(attacker, weapDamage, waitTime);
    }
    IEnumerator RunDeteriorateHex(StatBlock attacker, int weapDamage, float waitTime)
    {
        TakeDamage(attacker, 0, 0, 0, 0, weapDamage, 0, 0, 0, 0, 0);
        yield return new WaitForSeconds(waitTime);
        HasBurnHex(attacker, weapDamage, waitTime);
    }
    IEnumerator RunPhaseHex(StatBlock attacker, int weapDamage, float waitTime)
    {
        TakeDamage(attacker, 0, 0, 0, 0, 0, weapDamage, 0, 0, 0, 0);
        yield return new WaitForSeconds(waitTime);
        HasBurnHex(attacker, weapDamage, waitTime);
    }
    IEnumerator RunBleedHex(StatBlock attacker, int weapDamage, float waitTime)
    {
        TakeDamage(attacker, 0, 0, 0, 0, 0, 0, weapDamage, 0, 0, 0);
        yield return new WaitForSeconds(waitTime);
        HasBleedHex(attacker, weapDamage, waitTime);
    }
    IEnumerator RunDiseaseHex(StatBlock attacker, int weapDamage, float waitTime)
    {
        TakeDamage(attacker, 0, 0, 0, 0, 0, 0, 0, weapDamage, 0, 0);
        yield return new WaitForSeconds(waitTime);
        HasBurnHex(attacker, weapDamage, waitTime);
    }
    IEnumerator RunVirusHex(StatBlock attacker, int weapDamage, float waitTime)
    {
        TakeDamage(attacker, 0, 0, 0, 0, 0, 0, 0, 0, weapDamage, 0);
        yield return new WaitForSeconds(waitTime);
        HasBurnHex(attacker, weapDamage, waitTime);
    }
    IEnumerator RunCorruptHex(StatBlock attacker, int weapDamage, float waitTime)
    {
        TakeDamage(attacker, 0, 0, 0, 0, 0, 0, 0, 0, 0, weapDamage);
        yield return new WaitForSeconds(waitTime);
        HasBurnHex(attacker, weapDamage, waitTime);
    }
    #endregion

    #region Hex/Boon Management
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
    #endregion

    #region Timers
    public void UpdateTakeDamageTimer()
    {
        takeDamageTimer -= Time.deltaTime;
    }

    public void ResetTakeDamageCooldown()
    {
        takeDamageTimer = takeDamageCooldown;
    }
    #endregion       
}
public enum CharClass { Blank, Golemancer, Elementalist, Psyc, Mystic, Crypter, Apoch, Artificer, NanoMage, Vigil, Shadow, Envoy, StreetDoctor }
public enum BoonName { Blank, Resistance, Velocity, Swiftness, Power, Defence, Reflection, Precision, Shielding, Regeneration, Rend, Feedback, Stealth }
public enum HexName { Blank, Vulnerability, Slow, Snare, Weaken, Blind, Intimidate, Fear, Pin, Charm, Daze, Stun, Taunt, Burn, Chill, 
                        Electrocute, Irradiate, Deteriorate, Phase, Bleed, Disease, Virus, Corrupt }
public enum DamageStat { Strength, Marksmanship, Arcana }