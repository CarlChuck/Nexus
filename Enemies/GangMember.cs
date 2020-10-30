using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//reference for animator is eAnimator
public class GangMember : Enemy
{
    private EnemyWeaponMounts eWeaps;
    public GangMemberType gType;
    public RagdollEffect rDoll;
    [SerializeField] private Weapon equippedWeap;

    public override void Start()
    {
        base.Start();
        eWeaps = gameObject.GetComponent<EnemyWeaponMounts>();
        rDoll = gameObject.GetComponent<RagdollEffect>();
        if (gType == GangMemberType.Melee)
        {
            eAnimator.SetBool("MeleeREquipped", true);
        }
        else if (gType == GangMemberType.Rifle)
        {
            eAnimator.SetBool("RifleEquipped", true);
        }

    }

    public override void Update()
    {
        base.Update();
        UpdateAnimator();
    }

    public override void EnemyAbilityOne()
    {

        if (gType == GangMemberType.Melee)
        {
            //TODO Sound
            eAnimator.SetTrigger("MeleeRSwipe");

            CreateProjectile(projectile, this, emitter, damageStat, null, null, 0, 0, false, 0, true, false, false, false, 0, 20);
        }
        else if (gType == GangMemberType.Rifle)
        {
            //TODO Sound
            eAnimator.SetTrigger("RifleShoot");
            CreateProjectile(projectile, this, emitter, damageStat, null, null, 0, 0, false, 0, true, false, false, false, 30, 20);
            eWeaps.FireRWeapon();
        }
        //TODO attacks
    }
    
    public override void OnDeath()
    {
        base.OnDeath();
        eAnimator.enabled = false;
        rDoll.StartExplosiveRigidBody();
    }

    public override void OnDeathExtra()
    {
        base.OnDeathExtra();
        rDoll.RagdollThroughFloor();
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z * 1.8f;
        eAnimator.SetFloat("ForwardMovement", speed);
    }

    public Projectile CreateProjectile(Projectile proj, StatBlock attacker, Transform emitter, DamageStat dStat,
   BoonName[] boons = null, HexName[] hexes = null, float boonDur = 0, float hexDur = 0, bool freeze = false, int passthrough = 0, bool causeDam = true,
   bool toPush = false, bool toPull = false, bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        Projectile projectileInstance = Instantiate(proj, emitter.position, emitter.rotation);
        projectileInstance.StartProjectile(attacker, equippedWeap, dStat, emitter.forward, hexes, boons, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);

        return projectileInstance;
    }
}
public enum GangMemberType {Rifle, Melee }