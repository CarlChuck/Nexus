﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : StatBlock
{
    //References
    public Rigidbody rb;
    public Transform emitter;
    private LootSystemManager lootSys;
    public Animator eAnimator;
    [SerializeField] private GameObject enemyUI = default;


    //For AI
    public float perceptionRange = 35f;
    private Transform target;
    private NavMeshAgent agent;
    private AIstate state = AIstate.Passive;

    public bool frozen = false;
    [SerializeField] private GameObject freezePrefab = default;

    //Properties
    public float attackSpeed = 1f;
    private float coolDown = 0f;
    private bool isKinematicOn = true;
    private int xpValue;
    private EnemyQuality enemyRarity = EnemyQuality.Normal;

    //Weapon
    public Projectile projectile;
    public int damage = 10;
    public DamageType dType = DamageType.Fire;
    public AudioClip attackSound;
    public AudioSource source;
    public DamageStat damageStat;

    public override void Start()
    {
        base.Start();
        rb = gameObject.GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = projectile.range /2;
        lootSys = LootSystemManager.instance;
        target = Player.instance.player.transform;//TODO AI target selection
        xpValue = GenerateXPValue();
    }

    //AI Behaviour
    public override void Update()
    {
        base.Update();
        if (state != AIstate.Dead)
        {
            agent.speed = (speed.GetValue() - HasSnareHex() + HasSwiftnessBoon()) / 20;
            if (HasStunHex())
            {
                agent.speed = 0;
            }
            float distanceToTarget = Vector3.Distance(target.position, transform.position);
            coolDown -= Time.deltaTime;

            if (state == AIstate.Passive)
            {
                if (distanceToTarget <= perceptionRange)
                {
                    state = AIstate.Aggressive;
                }
            }
            if (state == AIstate.Aggressive)
            {
                if (distanceToTarget <= (perceptionRange))
                {
                    FaceTarget();
                    agent.SetDestination(target.position);
                    if (distanceToTarget <= agent.stoppingDistance)
                    {
                        FaceTarget();
                        Attack();
                    }
                }
                else
                {
                    state = AIstate.Passive;
                }
            }
            if (state == AIstate.Stun)
            {
                agent.SetDestination(transform.position);
            }
            rb.AddForce(Physics.gravity);
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void Attack()
    {
        if (coolDown <= 0f)
        {
            coolDown = 1f / attackSpeed;
            EnemyAbilityOne();
        }
    }

    public override void TakeDamage(StatBlock attacker, float thermDamage, float cryoDamage, float shockDamage, float radDamage, float psiDamage, float dimensionDamage,
        float kineticDamage, float poisonDamage, float bioDamage, float corruptionDamage)
    {
        if (state != AIstate.Dead)
        {
            base.TakeDamage(attacker, thermDamage, cryoDamage, shockDamage, radDamage, psiDamage, dimensionDamage, kineticDamage, poisonDamage, bioDamage, corruptionDamage);
        }
    }

    public override void TakeDamageFinal(StatBlock attacker, int damage)
    {
        base.TakeDamageFinal(attacker, damage);
        AddHex(HexName.Stun, attacker, 0.1f);
        EnemyKnockback(damage * 600, attacker);
    }

    public override void OnDeath()
    {
        int rarity = 0;
        if (enemyRarity == EnemyQuality.Weak || enemyRarity == EnemyQuality.Normal)
        {
            rarity = 1;
        }
        else if (enemyRarity == EnemyQuality.Uncommon)
        {
            rarity = 2;
        }
        else if (enemyRarity == EnemyQuality.Tough)
        {
            rarity = 3;
        }
        else if (enemyRarity == EnemyQuality.Rare)
        {
            rarity = 4;
        }
        else if (enemyRarity == EnemyQuality.Heroic)
        {
            rarity = 5;
        }
        else if (enemyRarity == EnemyQuality.Unique)
        {
            rarity = 6;
        }
        agent.isStopped = true;
        agent.enabled = false;
        if (state != AIstate.Dead)
        {
            lootSys.DropLoot(rarity, gameObject.transform);
            CameraController camera = FindObjectOfType<CameraController>();
            camera.shake(0.2f, 0.2f);
            state = AIstate.Dead;
            StartCoroutine(BodyDecay(6));
        }
        enemyUI.SetActive(false);
        GiveXP();
    }

    //To add extra effects in the time to decay, such as removing ragdoll.
    public override void OnDeathExtra()
    {
        //to override
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, perceptionRange);
    }

    public virtual void EnemyAbilityOne()
    {
        //to Override
    }

    public override void OnStunned(float timer, bool freeze)
    {
        if (state != AIstate.Dead)
        {
            state = AIstate.Stun;
            if (frozen == true)
            {
                frozen = false;
                GameObject vfxFrozen = Instantiate(freezePrefab, gameObject.transform);
                vfxFrozen.GetComponent<SelfDestruct>().StartKillTimer(timer);
                vfxFrozen.GetComponent<FreezeEffect>().SetFreezeTime(timer);
                Debug.Log(vfxFrozen);
            }
        }
    }

    public override void OnStunEnd()
    {
        if (state != AIstate.Dead)
        {
            state = AIstate.Passive; //TODO
        }
    }

    public void OnPush(float timer)
    {
        if (state != AIstate.Dead)
        {
            StartCoroutine(IsKinematicChange(timer));
        }
    }

    IEnumerator IsKinematicChange(float timer)
    {
        rb.isKinematic = false;
        isKinematicOn = false;
        yield return new WaitForSeconds(timer);
        rb.isKinematic = true;
        isKinematicOn = true;
    }

    public void EnemyKnockback(float force, StatBlock attackerDirection)
    {
        if (state != AIstate.Dead)
        {
            Rigidbody rbToPush = rb;
            Vector3 direction = rb.position - attackerDirection.transform.position;
            float distance = direction.magnitude;

            OnPush(0.2f);//To switch on rigidbody
            rbToPush.AddForce(direction.normalized * force);
        } 
    }

    IEnumerator BodyDecay(float wTime)
    {
        yield return new WaitForSeconds(wTime);
        rb.isKinematic = false;
        rb.SetDensity(5);
        rb.detectCollisions = false;
        OnDeathExtra();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    private void GiveXP()
    {
        Player.instance.xp.GainEXP(xpValue);
    }

    private int GenerateXPValue()
    {
        int xp = 5;
        float multiplier = 1f;
        int runningLevel = level;
        if (enemyRarity == EnemyQuality.Weak)
        {
            multiplier = 0.5f;
        }
        else if (enemyRarity == EnemyQuality.Normal)
        {
            multiplier = 1f;
        }
        else if (enemyRarity == EnemyQuality.Uncommon)
        {
            multiplier = 2f;
        }
        else if (enemyRarity == EnemyQuality.Tough)
        {
            multiplier = 4f;
        }
        else if (enemyRarity == EnemyQuality.Rare)
        {
            multiplier = 8f;
        }
        else if (enemyRarity == EnemyQuality.Heroic)
        {
            multiplier = 10f;
        }
        else if (enemyRarity == EnemyQuality.Unique)
        {
            multiplier = 20f;
        }

        if (level <= 5)
        {
            for (int i = 0; i <= level; i++)
            {
                xp = (int)(xp * 1.2f);
            }
        }
        else if (level > 5)
        {
            xp = 10;
            for (int i = 0; i <= level - 5; i++)
            {
                xp = (int)(xp * 1.05f);
            }
        }
        return (int)(xp * multiplier);
    }
    public enum AIstate {Passive, Aggressive, Search, Contact, Attack, Stun, Fear, Dead }
}
public enum EnemyQuality {Weak, Normal, Uncommon, Tough, Rare, Heroic, Unique }