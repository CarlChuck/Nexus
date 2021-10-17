using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementalistMechanic : ClassMechanic
{
    public Stat element;
    public int elementAmount;
    public Element currentElement;
    public int elementRegeneration;

    public ElementalistClassUI theElementalistUICanvas;
    private Inventory inv;

    private float skill1Timer;
    private float skill1Cooldown;
    private float skill2Timer;
    private float skill2Cooldown;
    private float eliteSkillTimer;
    private float eliteSkillCooldown;
    private float attuneTimer;
    private float attuneCooldown;

    public float ElementAsPercentage
    {
        get
        {
            return (float)elementAmount / (float)element.GetValue();
        }
    }

    public override void StartClassMechanic()
    {
        element = new Stat{ baseValue = 100 };
        elementAmount = 0;
        elementRegeneration = 1;
        BeginRegenerationFrame();
        UIManager.instance.OnStartMechanic();
        theElementalistUICanvas = UIManager.instance.GetElementalistUI() as ElementalistClassUI;
        inv = Inventory.instance;
        Player.instance.AddGlobalCoolDown();
        OnButton7();
    }
    public override void UpdateClassTimers(float time)
    {
        skill1Timer -= time;
        skill2Timer -= time;
        eliteSkillTimer -= time;
        attuneTimer -= time;
    }

    #region UIFill
    public override void UpdateClassMechanic()
    {
        float elementFill = ElementAsPercentage;
        theElementalistUICanvas.currenElementBar.fillAmount = elementFill;
    }
    public override void UpdateClassAbilityFills()
    {
        float fillAmount1 = skill1Timer / skill1Cooldown;
        if (fillAmount1 <= 0)
        {
            fillAmount1 = 0;
        }
        float fillAmount2 = skill2Timer / skill2Cooldown;
        if (fillAmount2 <= 0)
        {
            fillAmount2 = 0;
        }
        float fillAmount3 = eliteSkillTimer / eliteSkillCooldown;
        if (fillAmount3 <= 0)
        {
            fillAmount3 = 0;
        }
        float fillAmount4 = attuneTimer / attuneCooldown;
        if (fillAmount4 <= 0)
        {
            fillAmount4 = 0;
        }
        theElementalistUICanvas.SetUtilityOneFill(fillAmount1);
        theElementalistUICanvas.SetUtilityTwoFill(fillAmount2);
        theElementalistUICanvas.SetEliteFill(fillAmount3);
        theElementalistUICanvas.SetAttunementFill(fillAmount4);
    }
    #endregion

    #region Cooldowns
    public override void AddGlobalCooldownToClassSkills(float globalTimer, float globalCooldown)
    {
        if (globalTimer > skill1Timer)
        {
            skill1Cooldown = globalCooldown;
            skill1Timer = globalCooldown;
        }
        if (globalTimer > skill2Timer)
        {
            skill2Cooldown = globalCooldown;
            skill2Timer = globalCooldown;
        }
        if (globalTimer > eliteSkillTimer)
        {
            eliteSkillCooldown = globalCooldown;
            eliteSkillTimer = globalCooldown;
        }
        if (globalTimer > attuneTimer)
        {
            attuneCooldown = globalCooldown;
            attuneTimer = globalCooldown;
        }
    }
    public void AddElementalistSkill1Cooldown()
    {
        if (inv.eleSkill1 != null)
        {
            skill1Cooldown = inv.eleSkill1.skillCooldown;
        }
        else
        {
            skill1Cooldown = 0.1f;
        }
        skill1Timer = skill1Cooldown * Player.instance.HasVelocityBoon() * Player.instance.HasSlowHex();
    }
    public void AddElementalistSkill2Cooldown()
    {
        if (inv.eleSkill1 != null)
        {
            skill2Cooldown = inv.eleSkill2.skillCooldown;
        }
        else
        {
            skill2Cooldown = 0.1f;
        }
        skill2Timer = skill2Cooldown * Player.instance.HasVelocityBoon() * Player.instance.HasSlowHex();
    }
    public void AddElementalistEliteSkillCooldown()
    {
        if (inv.eleSkill1 != null)
        {
            eliteSkillCooldown = inv.eleEliteSkill.skillCooldown;
        }
        else
        {
            eliteSkillCooldown = 0.1f;
        }
        eliteSkillTimer = eliteSkillCooldown * Player.instance.HasVelocityBoon() * Player.instance.HasSlowHex();
    }
    #endregion

    #region ElementRegen
    public void BeginRegenerationFrame()
    {
        StartCoroutine(RegenerateElements());
    }    
    IEnumerator RegenerateElements()
    {
        if (elementAmount < element.GetValue())
        {
            elementAmount += elementRegeneration;
        }

        yield return new WaitForSeconds(0.3f);
        BeginRegenerationFrame();
    }

    #endregion

    #region AddRemoveElement
    public void AddElement(int value)
    {
        elementAmount += value;
    }
    public void ExpendElement(int value)
    {
        elementAmount -= value;
    }

    #endregion

    #region Controls
    public override void OnButton5()
    {
        if (inv.eleSkill1 != null)
        {
            EleSkill eSkill = inv.eleSkill1.eleSkill;
            int damage = inv.eleSkill1.damage;
            DoAbility(eSkill, damage);
            Player.instance.AddGlobalCoolDown();
            AddElementalistSkill1Cooldown();
        }

    }
    public override void OnButton6()
    {
        if (inv.eleSkill2 != null)
        {
            EleSkill eSkill = inv.eleSkill2.eleSkill;
            int damage = inv.eleSkill2.damage;
            DoAbility(eSkill, damage);
            Player.instance.AddGlobalCoolDown();
            AddElementalistSkill2Cooldown();
        }
    }
    public override void OnButton7()
    {
        if (eAttunement != AttunementType.ElementalistAir)
        {
            eAttunement = AttunementType.ElementalistAir;
            Player.instance.AddGlobalCoolDown();
            elementAmount = 0;
            theElementalistUICanvas.SetElementAir();
        }
        //TODO Animation
        //Ability Burst
    }
    public override void OnButton8()
    {
        if (eAttunement != AttunementType.ElementalistEarth)
        {
            eAttunement = AttunementType.ElementalistEarth;
            Player.instance.AddGlobalCoolDown();
            elementAmount = 0;
            theElementalistUICanvas.SetElementEarth();
        }
        //TODO Animation
        //Ability Burst
    }
    public override void OnButton9()
    {
        if (eAttunement != AttunementType.ElementalistFire)
        {
            eAttunement = AttunementType.ElementalistFire;
            Player.instance.AddGlobalCoolDown();
            elementAmount = 0;
            theElementalistUICanvas.SetElementFire();
        }
        //TODO Animation
        //Ability Burst
    }
    public override void OnButton10()
    {
        if (eAttunement != AttunementType.ElementalistWater)
        {
            eAttunement = AttunementType.ElementalistWater;
            Player.instance.AddGlobalCoolDown();
            elementAmount = 0;
            theElementalistUICanvas.SetElementWater();
        }
        //TODO Animation
        //Ability Burst
    }
    public override void OnButton11()
    {
        //Nothing for Ele
    }
    public override void OnButton12()
    {
        if (inv.eleEliteSkill != null)
        {
            EleEliteSkill eSkill = inv.eleEliteSkill.eleEliteSkill;
            int damage = inv.eleSkill1.damage;
            DoAbility(eSkill, damage);
            Player.instance.AddGlobalCoolDown();
            AddElementalistEliteSkillCooldown();
        }
    }
    #endregion

    #region DoAbility
    public void DoAbility(EleSkill eleSkill, int damage)
    {
        switch (eleSkill)
        {
            case EleSkill.LightningWarp:
                //Abilities.instance.LightningWarp(damage);
                break;
            case EleSkill.CrystalSkin:
                //Abilities.instance.CrystalSkin(damage);
                break;
            case EleSkill.HealingRiver:
                //Abilities.instance.HealingRiver(damage);
                break;
            case EleSkill.Fog:
                //Abilities.instance.Fog(damage);
                break;
            case EleSkill.Sandstorm:
                //Abilities.instance.Sandstorm(damage);
                break;
            case EleSkill.Static:
                //Abilities.instance.Static(damage);
                break;
            case EleSkill.EarthenArmour:
                //Abilities.instance.EarthenArmour(damage);
                break;
        }
    }
    public void DoAbility(EleEliteSkill eleEliteSkill, int damage)
    {
        switch (eleEliteSkill)
        {
            case EleEliteSkill.ElementalRay:
                //Abilities.instance.LightningWarp(damage);
                break;
        }
    }
    #endregion
}
public enum Element { Air, Earth, Fire, Water }
