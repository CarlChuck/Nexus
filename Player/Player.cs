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
        if (cClass == CharClass.Blank)
        {
            NewCharacter();
        }
        base.Start();

        wManager = WeaponManager.instance;
        inventory = Inventory.instance;

        globalCoolDown = 0.1f;
        globalTimer = 0;
        DontDestroyOnLoad(this);
        UpdateHealth();
        PlayerNaturalRegen();
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

    public override void TakeDamage(StatBlock attacker, float fDamage, float sDamage, float rDamage, float pDamage)
    {
        base.TakeDamage(attacker, fDamage, sDamage, rDamage, pDamage);
    }

    void NewCharacter()
    {
        MCharStats mCharStats = GameObject.FindGameObjectWithTag("varStorage").GetComponent<MCharStats>();
        charName = mCharStats.charName;
        cClass = mCharStats.cClass;
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
        physDamage.baseValue = 100;
        fireDamage.baseValue = 100;
        shockDamage.baseValue = 100;
        radDamage.baseValue = 100;
        fireResistance.baseValue = 10;
        shockResistance.baseValue = 10;
        radResistance.baseValue = 10;
        physicalResistance.baseValue = 10;
        if (cClass == CharClass.Elementalist)
        {
            gameObject.AddComponent<ElementalistMechanic>();
            classMechanic = GetComponent<ElementalistMechanic>();
        }
        classMechanic.StartClassMechanic();
        savePoint = AScene.Tutorial;


        Destroy(mCharStats.gameObject);
    }

    public override void OnDeath()
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
    public void PlayerNaturalRegen()
    {
        int pRegen = vitality.baseValue / 100;
        Debug.Log(pRegen);
        StartCoroutine(RunPlayerNaturalRegen(pRegen));

    }
    IEnumerator RunPlayerNaturalRegen(int regen)
    {
        if (currentHealth > 0 && currentHealth < vitality.baseValue)
        {
            Heal(regen);
        }
        yield return new WaitForSeconds(1f);
        PlayerNaturalRegen();
    }
}