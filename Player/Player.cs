using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class Player : StatBlock
{
    private MainControls mControls;

    #region Singleton

    public static Player instance;

    private void Awake()
    {
        instance = this; 
        mControls = new MainControls();
    }

    #endregion

    public string charName;
    public CharClass cClass;
    public AScene savePoint;

    public UIManager uManager;
    public WeaponManager wManager;
    public Inventory inventory;
    public Animator anim;
    public GameObject player;
    public TwoBoneIKConstraint rhIK;
    public TwoBoneIKConstraint lhIK;
    public Xp xp;

    public bool inventoryOpen = false;

    //Class Mechanics
    public ClassMechanic classMechanic;

    //timers and cooldown
    private float globalCoolDown;
    public float globalTimer;
    private float weapon1CoolDown;
    public float weapon1Timer;
    private float weapon2CoolDown;
    public float weapon2Timer;
    private float weapon3CoolDown;
    public float weapon3Timer;
    private float weapon4CoolDown;
    public float weapon4Timer;

    //Health Numbers;
    //[SerializeField] private Text currentHealthText = default;
    //[SerializeField] private Text maxHealthText = default;

    //Emitters
    public Transform rightEmitter;
    public Transform leftEmitter;
    public Transform centreEmitter;

    //AudioSource
    public AudioSource aSource;

    public override void Start()
    {
        base.Start();

        wManager = WeaponManager.instance;
        inventory = Inventory.instance;
        level = xp.CurrentLevel();
        globalCoolDown = 0.1f;
        globalTimer = 0;
        UpdateHealth();
        DontDestroyOnLoad(this);
    }

    public override void Update()
    {
        base.Update();
        UpdateTimers();
        UpdateWeaponCoolDownfills(); 
        classMechanic.UpdateClassMechanic();
        classMechanic.UpdateClassAbilityFills();   
    }
    public void FixedUpdate()
    {
        //UpdateTimers();
        //UpdateWeaponCoolDownfills();
        //classMechanic.UpdateClassMechanic();
        //classMechanic.UpdateClassAbilityFills();

    }
    private void UpdateTimers()
    {
        float time = Time.deltaTime;
        globalTimer -= time;
        weapon1Timer -= time;
        weapon2Timer -= time;
        weapon3Timer -= time;
        weapon4Timer -= time;
        classMechanic.UpdateClassTimers(time);
    }

    public MainControls GetControls()
    {
        return mControls;
    }

    public override void TakeDamage(StatBlock attacker, float thermDamage, float cryoDamage, float shockDamage, float radDamage, float psiDamage, float dimensionDamage,
        float kineticDamage, float poisonDamage, float bioDamage, float corruptionDamage)
    {
        base.TakeDamage(attacker, thermDamage, cryoDamage, shockDamage, radDamage, psiDamage, dimensionDamage, kineticDamage, poisonDamage, bioDamage, corruptionDamage);
    }

    public void ActivateCharacter(string cName, CharClass charClass, AScene aScene, int xp, int level)
    {
        charName = cName;
        cClass = charClass;
        savePoint = aScene;
        vitality.baseValue = 100;
        armour.baseValue = 10;
        strength.baseValue = 10;
        marksmanship.baseValue = 10;
        arcana.baseValue = 10;
        movement.baseValue = 100;
        speed.baseValue = 10;
        ferocity.baseValue = 10;
        devastation.baseValue = 50;
        affliction.baseValue = 10;
        persistence.baseValue = 100;
        leech.baseValue = 0;
        regen.baseValue = 0;
        feedback.baseValue = 0;
        thermalDamage.baseValue = 100;
        cryoDamage.baseValue = 100;
        shockDamage.baseValue = 100;
        radiationDamage.baseValue = 100;
        psiDamage.baseValue = 100;
        dimensionDamage.baseValue = 100;
        kineticDamage.baseValue = 100;
        psiDamage.baseValue = 100;
        poisonDamage.baseValue = 100;
        bioDamage.baseValue = 100;
        corruptionDamage.baseValue = 100;
        thermalResistance.baseValue = 10;
        cryoResistance.baseValue = 10;
        shockResistance.baseValue = 10;
        radiationResistance.baseValue = 10;
        psiResistance.baseValue = 10;
        dimensionResistance.baseValue = 10;
        kineticResistance.baseValue = 10;
        poisonResistance.baseValue = 10;
        bioResistance.baseValue = 10;
        corruptionResistance.baseValue = 10;

        switch (cClass)
        {
            case CharClass.Golemancer:
                //TODO
                break;
            case CharClass.Elementalist:
                gameObject.AddComponent<ElementalistMechanic>();
                classMechanic = GetComponent<ElementalistMechanic>();
                break;
            case CharClass.Psyc:
                //TODO
                break;
            case CharClass.Mystic:
                //TODO
                break;
            case CharClass.Artificer:
                //TODO
                break;
            case CharClass.Apoch:
                //TODO
                break;
            case CharClass.Crypter:
                //TODO
                break;
            case CharClass.NanoMage:
                //TODO
                break;
            case CharClass.Guardian:
                //TODO
                break;
            case CharClass.Vigil:
                //TODO
                break;
            case CharClass.Shadow:
                //TODO
                break;
            case CharClass.StreetDoctor:
                //TODO
                break;
        }
        classMechanic.StartClassMechanic();
    }

    public override void OnDeath()
    {
        
    }

    public void OnLevelUp()
    {


    }
    public override void UpdateHealth()
    {
        base.UpdateHealth();
        float fillAmount = HealthAsPercentage;
        //currentHealthText.text = currentHealth.ToString();
        //maxHealthText.text = vitality.GetValue().ToString();
        uManager.SetHealthBar(fillAmount);
    }

    private void UpdateWeaponCoolDownfills()
    {
        float fillAmount1 = weapon1Timer / weapon1CoolDown;
        if (fillAmount1 <= 0)
        {
            fillAmount1 = 0;
        }
        float fillAmount2 = weapon2Timer / weapon2CoolDown;
        if (fillAmount2 <= 0)
        {
            fillAmount2 = 0;
        }
        float fillAmount3 = weapon3Timer / weapon3CoolDown;
        if (fillAmount3 <= 0)
        {
            fillAmount3 = 0;
        }
        float fillAmount4 = weapon4Timer / weapon4CoolDown;
        if (fillAmount4 <= 0)
        {
            fillAmount4 = 0;
        }
        uManager.SetWeapOneFill(fillAmount1);
        uManager.SetWeapTwoFill(fillAmount2);
        uManager.SetWeapThreeFill(fillAmount3);
        uManager.SetWeapFourFill(fillAmount4);
    }
    public void AddGlobalCoolDown()
    {
        globalTimer = globalCoolDown;
        float globalCoolDownModified = globalCoolDown * HasVelocityBoon() * HasSlowHex();
        if (globalTimer > weapon1Timer)
        {
            weapon1CoolDown = globalCoolDownModified;
            weapon1Timer = globalCoolDownModified;
        }
        if (globalTimer > weapon2Timer)
        {
            weapon2CoolDown = globalCoolDownModified;
            weapon2Timer = globalCoolDownModified;
        }
        if (globalTimer > weapon3Timer)
        {
            weapon3CoolDown = globalCoolDownModified;
            weapon3Timer = globalCoolDownModified;
        }
        if (globalTimer > weapon4Timer)
        {
            weapon4CoolDown = globalCoolDownModified;
            weapon4Timer = globalCoolDownModified;
        }
        classMechanic.AddGlobalCooldownToClassSkills(globalTimer, globalCoolDownModified);
    }
    public void AddWeaponCooldown(int weap)
    {
        switch (weap)
        {
            case 1:
                if (inventory.rHand != null)
                {
                    weapon1CoolDown = inventory.rHand.cooldown;
                }
                else
                {
                    weapon1CoolDown = globalCoolDown;
                }
                weapon1Timer = weapon1CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon2Timer = weapon1CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon3Timer = weapon1CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon4Timer = weapon1CoolDown * HasVelocityBoon() * HasSlowHex();
                break;
            case 2:
                if (inventory.rHand != null)
                {
                    weapon2CoolDown = inventory.rHand.cooldown;
                }
                else
                {
                    weapon2CoolDown = globalCoolDown;
                }
                weapon1Timer = weapon2CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon2Timer = weapon2CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon3Timer = weapon2CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon4Timer = weapon2CoolDown * HasVelocityBoon() * HasSlowHex();
                break;
            case 3:
                if (inventory.rHand != null)
                {
                    weapon3CoolDown = inventory.lHand.cooldown;
                }
                else
                {
                    weapon3CoolDown = globalCoolDown;
                }
                weapon1Timer = weapon3CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon2Timer = weapon3CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon3Timer = weapon3CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon4Timer = weapon3CoolDown * HasVelocityBoon() * HasSlowHex();
                break;
            case 4:
                if (inventory.rHand != null)
                {
                    weapon4CoolDown = inventory.lHand.cooldown;
                }
                else
                {
                    weapon4CoolDown = globalCoolDown;
                }
                weapon1Timer = weapon4CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon2Timer = weapon4CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon3Timer = weapon4CoolDown * HasVelocityBoon() * HasSlowHex();
                weapon4Timer = weapon4CoolDown * HasVelocityBoon() * HasSlowHex();
                break;
            default:
                break;
        }
    }

    public void ForceMovement(Vector3 newLoc)
    {
        gameObject.transform.position = newLoc;
    }

}