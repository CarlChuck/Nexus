using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Damage statistics
    private int damage;
    private DamageStat damageStat;
    private StatBlock attacker;
    private DamageType dType;
    private WhoToDamage whoToDam;
    private Weapon weaponUsed;

    //Projectile movement
    private Vector3 spawnPosition;
    public Vector3 direction;
    public float range;
    private int speed;

    //Optional Extras
    [SerializeField] private GameObject onImpact = default;
    [SerializeField] private Transform toSeparate = default;
    [SerializeField] private Transform vfxToSeperate = default;
    [SerializeField] private Gravity grav = default;
    [SerializeField] private float gravForce = 0;
    private bool causeDamage = true;
    private int passthrough = 0;
    private HexName[] hexes;
    private BoonName[] boons;
    private float boonDuration;
    private float hexDuration;
    private bool push = false;
    private bool pull = false;
    private bool persistent = false;
    private bool freeze = false;

    //Sets projectile and begins
    public void StartProjectile(StatBlock attk, Weapon weap, DamageStat dStat, Vector3 dir, HexName[] inHexes = null, BoonName[] inBoons = null, float boonDur = 0f, float hexDur = 0f, 
        bool toFreeze = false, int passthr = 0, bool causeDam  = true, bool toPush = false, bool toPull = false, bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        speed = inSpeed;
        range = inRange;
        attacker = attk;
        direction = dir;
        hexes = inHexes;
        boons = inBoons;
        boonDuration = boonDur;
        hexDuration = hexDur;
        freeze = toFreeze;
        passthrough = passthr;
        causeDamage = causeDam;
        push = toPush;
        pull = toPull;
        persistent = persist;
        weaponUsed = weap;
        damageStat = dStat;


        if (attk is Player || attk is Ally)
        {
            whoToDam = WhoToDamage.Enemy;
        }
        else
        {
            whoToDam = WhoToDamage.PlayerOrAlly;
        }

        spawnPosition = transform.position;
        if (push == true || pull == true)
        {
            if (gameObject.GetComponent<Gravity>() != null)
            {
                grav = gameObject.GetComponent<Gravity>();
                grav.gravityForce = gravForce;
                grav.duration = hexDuration;
                if (push == true)
                {
                    grav.knockback = true;
                }
            }
        }

        if (range < 1)
        {
            if (persistent == false)
            {
                StartCoroutine(Delay(0.02f));
            }
            else if (persistent == true)
            {
                if (onImpact != null)
                {
                    if (onImpact.GetComponent<Projectile>())
                    {
                        StartCoroutine(Delay(0.02f));
                    }
                    else
                    {
                        if (boonDuration > hexDuration)
                        {
                            StartCoroutine(Delay(boonDuration));
                        }
                        else
                        {
                            StartCoroutine(Delay(hexDuration));
                        }
                    }
                }
                else
                {
                    if (boonDuration > hexDuration)
                    {
                        StartCoroutine(Delay(boonDuration));
                    }
                    else
                    {
                        StartCoroutine(Delay(hexDuration));
                    }
                }
            }
        }
    }


    public float GetRange()
    {
        return range;
    }

    //ends projectile after range moved, or time spent in world
    private void Update()
    {
        if (range >= 1)
        {
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().MovePosition(transform.position + direction * Time.deltaTime * speed);
            }
            if (Vector3.Distance(spawnPosition, transform.position) >= range)
            {
                EndProjectile();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.GetComponent<StatBlock>())
        {
            StatBlock target = collision.transform.GetComponent<StatBlock>();
            if (collision.transform.GetComponent<Enemy>())
            {
                if (whoToDam == WhoToDamage.Enemy)
                {
                    Impact(target);
                    if (hexes != null)
                    {
                        foreach (HexName hex in hexes)
                        {
                            if (hex == HexName.Stun && freeze == true)
                            {
                                Enemy enemy = target as Enemy;
                                enemy.frozen = true;
                            }
                        }
                        ApplyHexes(hexes, target, attacker, hexDuration, damageStat, damage);

                    }
                }
                else if (whoToDam == WhoToDamage.PlayerOrAlly)
                {
                    if (boons != null)
                    {
                        ApplyBoons(boons, target, attacker, boonDuration, damage);
                    }
                }
            }
            else if (collision.transform.GetComponent<Player>())
            {
                PlayerController pControl = null;
                if (collision.GetComponent<PlayerController>())
                {
                    pControl = collision.GetComponent<PlayerController>();
                }

                if (whoToDam == WhoToDamage.PlayerOrAlly)
                {
                    if (pControl != null)
                    {
                        if (pControl.dodgeBool == true)
                        {

                        }
                        else
                        {
                            Impact(target);
                        }
                    }
                    else
                    {
                        Impact(target);
                    }
                }
                else if (whoToDam == WhoToDamage.Enemy)
                {
                    if (boons != null)
                    {
                        ApplyBoons(boons, target, attacker, boonDuration, damage);
                    }
                }
            }
            else if (collision.transform.GetComponent<Ally>())
            {
                if (whoToDam == WhoToDamage.PlayerOrAlly)
                {
                    Impact(target);
                }
                else if (whoToDam == WhoToDamage.Enemy)
                {
                    if (boons != null)
                    {
                        ApplyBoons(boons, target, attacker, boonDuration, damage);
                    }
                }                
            }
            else if (collision.transform.GetComponent<Destructible>())
            {
                if (whoToDam == WhoToDamage.Enemy)
                {
                    Impact(target);
                }
            }
        }
        
        else if (collision.gameObject.layer == 18)
        {
            Debug.Log(collision.gameObject.layer);
            if (persistent == false && range > 1)
            {
                EndProjectile();
            }
        }
    }

    private void Impact(StatBlock target)
    {
        if (toSeparate != null)
        {
            toSeparate.parent = null;
        }
        if (vfxToSeperate != null)
        {
            vfxToSeperate.parent = null;
        }
        if (causeDamage == true)
        {
            attacker.DealDamage(target, damageStat, weaponUsed);
        }
        else
        {
            if (persistent == false && range > 1)
            {
                EndProjectile();
            }
        }
        if (passthrough < 1)
        {
            if (persistent == false && range > 1)
            {
                EndProjectile();
            }
        }
        else if (passthrough > 0)
        {
            int randomNum = Random.Range(0, 100);
            if (randomNum < passthrough)
            {
                if (onImpact != null)
                {
                    Transform currentLoc = gameObject.transform;
                    Instantiate(onImpact.gameObject, currentLoc.position, currentLoc.rotation);
                }
            }
            else
            {
                EndProjectile();
            }
        }
    }

    public void EndProjectile()
    {

        if (onImpact != null)
        {
            ImpactCol();
        }
        if (toSeparate != null)
        {
            toSeparate.parent = null;
        }
        if (vfxToSeperate != null)
        {
            vfxToSeperate.parent = null;
        }
        Destroy(gameObject);
    }

    public void ImpactCol()
    {
        Transform currentLoc = gameObject.transform;
        GameObject impactObj = Instantiate(onImpact, currentLoc.position, currentLoc.rotation);
        if (impactObj.GetComponent<Projectile>())
        {
            impactObj.GetComponent<Projectile>().StartProjectile(attacker, weaponUsed, damageStat, direction, hexes, boons, boonDuration, 
                hexDuration, freeze, passthrough, true, push, pull, persistent, 0f, 0);
        }
        //TODO add bounce
    }

    public void ApplyBoons(BoonName[] boons, StatBlock target, StatBlock applier, float dur, int shield)
    {
        foreach (BoonName boon in boons)
        {
            target.AddBoon(boon, applier, dur, shield);
        }
    }
    public void ApplyHexes(HexName[] hexes, StatBlock target, StatBlock applier, float dur, DamageStat dStat = DamageStat.Strength, int dotDamage = 0)
    {
        foreach (HexName hex in hexes)
        {
            target.AddHex(hex, applier, dur, dStat, dotDamage);
        }
    }

    IEnumerator Delay(float wTime)
    {
        yield return new WaitForSeconds(wTime);
        EndProjectile();
    }
}
public enum WhoToDamage { Enemy, PlayerOrAlly }