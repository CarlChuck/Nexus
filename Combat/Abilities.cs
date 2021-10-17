using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    #region Singleton
    public static Abilities instance;

    public void Start()
    {
        Abilities.instance = this;
    }
    #endregion

    #region Projectiles
    public GolemancerProjectiles goleProj;
    public ElementalistProjectiles eleProj;
    public PsycProjectiles psycProj;
    public MysticProjectiles mysticProj;
    public ArtificerProjectiles artiProj;
    public ApochProjectiles apochProj;
    public CrypterProjectiles cryptProj;
    public NanoMageProjectiles nanoProj;
    public EnvoyProjectiles envoyProj;
    public VigilProjectiles vigilProj;
    public ShadowProjectiles shadowProj;
    public StreetDocProjectiles streetProj;

    #endregion

    #region Golemancer

    #endregion

    #region Elementalist
    //Wand 1
    public void CrystalSwarm(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.8f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Bleed;
        //ConeShot3(eleProj.crystalSwarm, player, emitter, damage, dType, dStat, null, hexes, 0f, 2f);
        RaiseElement(player, value);
    }
    public void LightningBolt(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.6f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Stun;
        //CreateProjectile(eleProj.lightningBolt, player, emitter, damage, dType, dStat, null, hexes, 0f, 1f);
        RaiseElement(player, value);
    }
    public void FireBolts(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.8f;

        //ConeShot3(eleProj.fireBolts, player, emitter, damage, dType, dStat, null);
        RaiseElement(player, value);
    }
    public void WaterBolt(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.5f;

        //CreateProjectile(eleProj.waterBolt, player, emitter, damage, dType, dStat, null);
        player.Heal(5);
        RaiseElement(player, value);
    }

    //Wand 2
    public void CrystalWave(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.5f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Bleed;
        //PbAoEShot(eleProj.crystalWave, player, emitter, damage, dType, attackSound, source, dStat, null, hexes, 0f, 2f);
        RaiseElement(player, value);
    }
    public void ChainLightning(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.8f;

        //CreateProjectile(eleProj.chainLightning, player, emitter, damage, dType, dStat, null);
        RaiseElement(player, value);
    }
    public void PyroclasticSurge(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.8f;

        //PbAoEShot(eleProj.pyroclasticSurge, player, emitter, damage, dType, attackSound, source, dStat);
        RaiseElement(player, value);
    }
    public void WaterBlast(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Stun;
        //CreateProjectile(eleProj.waterBlast, player, emitter, damage, dType, dStat, null, hexes, 0f, 4f);
        RaiseElement(player, value);
    }

    //Wand 3
    public void RockLance(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.8f;

        //CreateProjectile(eleProj.rockLance, player, emitter, damage, dType, dStat);
        RaiseElement(player, value);
    }
    public void AirBurst(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.2f;

        //CreateProjectile(eleProj.airBurst, player, emitter, damage, dType, dStat, null);
        //TODO add knockback on hit, rather than generic gravity push
        RaiseElement(player, value);
    }
    public void FireBall(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.6f;

        float speed = 20f;//TODO
        //GroundTargetShot(eleProj.fireball, player, emitter, speed, damage, dType, dStat);
        RaiseElement(player, value);
    }
    public void GlacialSpike(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.8f;

        //CreateProjectile(eleProj.glacialSpike, player, emitter, damage, dType, dStat);
        RaiseElement(player, value);
    }

    //Wand 4
    public void Earthquake(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.5f;

        Projectile newProj = CreateProjectile(eleProj.earthquake, player, weap, emitter, dStat, multiplier);
        Pbaoe(player, newProj);
        RaiseElement(player, value);
    }
    public void Cyclone(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;

        Projectile newProj = CreateProjectile(eleProj.cyclone, player, weap, emitter, dStat, multiplier, null, null, 2f);
        WornEffect(player, newProj);
        RaiseElement(player, value);
    }
    public void Firestorm(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.8f;
        //TODO Special
    }
    public void Permafrost(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.6f;

        Projectile newProj = CreateProjectile(eleProj.permafrost, player, weap, emitter, dStat, multiplier);
        Pbaoe(player, newProj);
        RaiseElement(player, value);
    }

    //Heavy Pistol 1
    public void EarthRound(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.6f;
        AudioClip aClip = Resources.Load<AudioClip>("Sound/HPistol_EarthRound");
        Player.instance.aSource.PlayOneShot(aClip);

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Snare;
        SingleShot(eleProj.earthRound, player, weap, emitter, dStat, multiplier, null, hexes, 0f, 2f, false, 100);
        RaiseElement(player, value);
    }
    public void LightningRound(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;
        AudioClip aClip = Resources.Load<AudioClip>("Sound/HPistol_LightningRound");
        Player.instance.aSource.PlayOneShot(aClip);

        SingleShot(eleProj.lightningRound, player, weap, emitter, dStat, multiplier, null, null, 0f, 0f, false, 30, true);
        RaiseElement(player, value);
    }
    public void FlameRound(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;
        AudioClip aClip = Resources.Load<AudioClip>("Sound/HPistol_FireRound");
        Player.instance.aSource.PlayOneShot(aClip);

        SingleShot(eleProj.flameRound, player, weap, emitter, dStat, multiplier, null, null, 0f, 0f, false, 0, true);
        RaiseElement(player, value);
    }
    public void IceRound(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.4f;
        AudioClip aClip = Resources.Load<AudioClip>("Sound/HPistol_IceRound");
        Player.instance.aSource.PlayOneShot(aClip);

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Snare;
        ConeShot3(eleProj.iceRound, player, weap, emitter, dStat, multiplier, null, hexes, 0f, 2f);
        RaiseElement(player, value);
    }

    //Heavy Pistol 2
    public void MeteorShot(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.5f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Bleed;
        SingleShot(eleProj.meteorShot, player, weap, emitter, dStat, multiplier, null, hexes, 0f, 3f, false, 0, false);
        RaiseElement(player, value);
    }
    public void LightningPulse(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.5f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Stun;
        SingleShot(eleProj.lightningPulse, player, weap, emitter, dStat, multiplier, null, hexes, 0f, 1f, false, 0, false);
        RaiseElement(player, value);
    }
    public void Conflagration(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Burn;
        SingleShot(eleProj.conflagration, player, weap, emitter, dStat, multiplier, null, hexes, 0f, 2f);
        RaiseElement(player, value);
    }
    public void FrostSpear(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.6f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Stun;
        SingleShot(eleProj.frostSpear, player, weap, emitter, dStat, multiplier, null, hexes, 0f, 1f, true, 100);
        RaiseElement(player, value);
    }

    //Heavy Pistol 3
    public void CrystalRound(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.6f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Snare;
        SingleShot(eleProj.crystalRound, player, weap, emitter, dStat, multiplier, null, hexes, 0f, 4f, false, 0, false);
        RaiseElement(player, value);
    }
    public void AirRound(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.8f;

        GroundTargetShot(eleProj.airRound, player, weap, emitter, dStat, 30f, multiplier, null, null, 0f, 0f, false, 0, false, true);
        RaiseElement(player, value);
    }
    public void MagmaRound(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.7f;

        SingleShot(eleProj.magmaRound, player, weap, emitter, dStat, multiplier, null, null, 0f, 0f, false, 0, false);
        RaiseElement(player, value);
    }
    public void WaterRound(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.6f;
        //TODO
        int healAmount = 10;
        player.Heal(healAmount);
        SingleShot(eleProj.waterRound, player, weap, emitter, dStat, multiplier);
        RaiseElement(player, value);
    }

    //Heavy Pistol 4
    public void GravitonCrystal(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Pin;
        GroundTargetShot(eleProj.gravitonRound, player, weap, emitter, dStat, multiplier, 30f, null, hexes, 0f, 2f, false, 0, false, false, false, true);
        RaiseElement(player, value);
    }
    public void StaticForce(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.8f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Stun;
        SingleShot(eleProj.staticForce, player, weap, emitter, dStat, multiplier, null, hexes, 0f, 1f);
        RaiseElement(player, value);
    }
    public void FlameBlast(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.5f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Burn;
        GroundTargetShot(eleProj.flameBlast, player, weap, emitter, dStat, multiplier, 30f, null, hexes, 0f, 2f, false, 0, false);
        RaiseElement(player, value);
    }
    public void VapourRound(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.6f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Blind;
        SingleShot(eleProj.vapourRound, player, weap, emitter, dStat, multiplier, null, hexes, 0f, 4f, false, 0, false);
        RaiseElement(player, value);
    }

    //Focus 3
    public void MagneticPulse(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0f;

        Projectile newProj = CreateProjectile(eleProj.magneticPulse, player, weap, emitter, dStat, multiplier);
        Pbaoe(player, newProj);
        //newProj.pull = true;//TODO
        RaiseElement(player, value);
    }
    public void GustOfWind(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0f;

        Projectile newProj = CreateProjectile(eleProj.gustOfWind, player, weap, emitter, dStat, multiplier);
        Pbaoe(player, newProj);
        //newProj.push = true;//TODO
        RaiseElement(player, value);
    }
    public void RingOfFire(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0.5f;

        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Burn;
        BoonName[] boons = new BoonName[1];
        boons[0] = BoonName.Rend;
        GroundTargetSpawn(eleProj.ringOfFire, player, weap, emitter, dStat, multiplier, boons, hexes, 10f, 10f);
        RaiseElement(player, value);
    }
    public void CleansingFog(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;
    }

    //Focus 4
    public void GraniteAura(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0f;

        BoonName[] boons = new BoonName[1];
        boons[0] = BoonName.Defence;
        Projectile newProj = CreateProjectile(eleProj.graniteAura, player, weap, emitter, dStat, multiplier, boons, null, 10f);
        WornEffect(player, newProj);
        RaiseElement(player, value);
    }
    public void ShockingAura(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0f;

        BoonName[] boons = new BoonName[1];
        boons[0] = BoonName.Precision;
        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Stun;
        Projectile newProj = CreateProjectile(eleProj.shockingAura, player, weap, emitter, dStat, multiplier, boons, hexes, 10f, 1f);
        WornEffect(player, newProj);
        RaiseElement(player, value);
    }
    public void FlamingAura(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0f;

        BoonName[] boons = new BoonName[1];
        boons[0] = BoonName.Feedback;
        HexName[] hexes = new HexName[1];
        hexes[0] = HexName.Burn;
        Projectile newProj = CreateProjectile(eleProj.flamingAura, player, weap, emitter, dStat, multiplier, boons, hexes, 10f, 2f);
        WornEffect(player, newProj);
        RaiseElement(player, value);
    }
    public void MistAura(Player player, InventoryItem weap, Transform emitter)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 0f;

        BoonName[] boons = new BoonName[1];
        boons[0] = BoonName.Regeneration;
        Projectile newProj = CreateProjectile(eleProj.mistAura, player, weap, emitter, dStat, multiplier, boons, null, 10f);
        WornEffect(player, newProj);
        RaiseElement(player, value);
    }

    //Utilities
    public void LightningWarp(Player player, InventoryItem weap)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;

        if (CheckElement(value, player) == true)
        {
            Projectile teleportEnter = CreateProjectile(eleProj.lightningWarp, player, weap, player.centreEmitter, dStat, multiplier);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                Vector3 landingPoint = new Vector3(hit.point.x, 0.5f, hit.point.z);
                StartCoroutine(MoveToTarget(player.gameObject, landingPoint, 0.1f, 300f));
                Projectile teleportExit = CreateProjectile(eleProj.lightningWarp, player, weap, player.centreEmitter, dStat, multiplier);
            }
            LowerElement(player, value);
        }
    }
    public void CrystalSkin(Player player, InventoryItem weap)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;

        if (CheckElement(value, player) == true)
        {
            BoonName[] boons = new BoonName[1];
            boons[0] = BoonName.Shielding;
            Projectile newProj = CreateProjectile(eleProj.crystalSkin, player, weap, player.centreEmitter, dStat, multiplier, boons, null, 10f);
            Pbaoe(player, newProj);
            LowerElement(player, value);
        }
    }
    public void HealingRiver(Player player, InventoryItem weap)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;

        int amountToHeal = 10; //TODO
        if (CheckElement(value, player) == true)
        {
            player.Heal(amountToHeal);
            Projectile newProj = CreateProjectile(eleProj.healingRiver, player, weap, player.centreEmitter, dStat, multiplier); //add particle effect
            Pbaoe(player, newProj);
            LowerElement(player, value);
        }
    }
    public void Fog(Player player, InventoryItem weap)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;

        if (CheckElement(value, player) == true)
        {
            HexName[] hexes = new HexName[1];
            hexes[0] = HexName.Irradiate;
            GroundTargetSpawn(eleProj.fog, player, weap, player.centreEmitter, dStat, multiplier, null, hexes, 0f, 4f);
            LowerElement(player, value);
        }
    }
    public void Sandstorm(Player player, InventoryItem weap)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;

        if (CheckElement(value, player) == true)
        {
            HexName[] hexes = new HexName[1];
            hexes[0] = HexName.Blind;
            GroundTargetSpawn(eleProj.sandstorm, player, weap, player.centreEmitter, dStat, multiplier, null, hexes, 0f, 2f);
            LowerElement(player, value);
        }
    }
    public void Static(Player player, InventoryItem weap)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;

        if (CheckElement(value, player) == true)
        {
            BoonName[] boons = new BoonName[1];
            boons[0] = BoonName.Swiftness;
            Projectile newProj = CreateProjectile(eleProj.staticProj, player, weap, player.centreEmitter, dStat, multiplier, boons, null, 6f);
            Pbaoe(player, newProj);
            LowerElement(player, value);
        }
    }
    public void VolcanicRay(Player player, InventoryItem weap)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;

        if (CheckElement(value, player) == true)
        {
            HexName[] hexes = new HexName[2];
            hexes[0] = HexName.Burn;
            hexes[1] = HexName.Bleed;
            ChannelAttack(eleProj.volcanicRay, player, weap, player.centreEmitter, dStat, multiplier, null, hexes, 0f, 1f);
            LowerElement(player, value);
        }
    }
    public void EarthenArmour(Player player, InventoryItem weap)
    {
        int value = 10;
        DamageStat dStat = DamageStat.Arcana;
        float multiplier = 1f;

        if (CheckElement(value, player) == true)
        {
            BoonName[] boons = new BoonName[1];
            boons[0] = BoonName.Resistance;
            Projectile newprojectile = CreateProjectile(eleProj.earthenArmour, player, weap, player.centreEmitter, dStat, multiplier, boons, null, 20f);
            WornEffect(player, newprojectile);
            LowerElement(player, value);
        }
    }


    public void LowerElement(Player player, int value)
    {
        ElementalistMechanic eleMechanic = player.classMechanic as ElementalistMechanic;
        eleMechanic.ExpendElement(value);
    }    
    public void RaiseElement(Player player, int value)
    {
        ElementalistMechanic eleMechanic = player.classMechanic as ElementalistMechanic;
        eleMechanic.AddElement(value);
    }
    public bool CheckElement(int statAmount, Player player)
    {
        ElementalistMechanic eleMechanic = player.classMechanic as ElementalistMechanic;
        if (eleMechanic.elementAmount >= statAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region Psyc

    #endregion

    #region Mystic

    #endregion

    #region Artificer

    #endregion

    #region Apoch

    #endregion

    #region Crypter

    #endregion

    #region Nano Mage

    #endregion

    #region Envoy

    #endregion

    #region Vigil

    #endregion

    #region Shadow

    #endregion

    #region Street Doc

    #endregion



    #region CoreAbilityFunctions


    //keeps a projectile parented to player
    public void WornEffect(Player player, Projectile proj)
    {
        proj.transform.parent = player.transform;
        proj.transform.localPosition = Vector3.zero;
        //proj.persistent = true;
    }

    //centres a projectile on player
    public void Pbaoe(StatBlock source, Projectile proj)
    {
        Vector3 translation = new Vector3(0, 0.2f, 0);
        proj.transform.position = source.transform.position + translation;
    }

    //Shoots 5 projectiles out in a cone
    public void ConeShot(Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, float boonDur = 0, float hexDur = 0,
        bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        Projectile projectileInstanceA = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceA.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(-10, Vector3.up);
        projectileInstanceA.direction = projectileInstanceA.gameObject.transform.forward;

        Projectile projectileInstanceB = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceB.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(-5, Vector3.up);
        projectileInstanceB.direction = projectileInstanceB.gameObject.transform.forward;

        Projectile projectileInstanceC = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceC.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(0, Vector3.up);
        projectileInstanceC.direction = projectileInstanceC.gameObject.transform.forward;

        Projectile projectileInstanceD = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceD.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(5, Vector3.up);
        projectileInstanceD.direction = projectileInstanceD.gameObject.transform.forward;

        Projectile projectileInstanceE = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceE.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(10, Vector3.up);
        projectileInstanceE.direction = projectileInstanceE.gameObject.transform.forward;
    }
    
    //Shoots 3 projectiles in cone
    public void ConeShot3(Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, float boonDur = 0, float hexDur = 0, 
        bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        Projectile projectileInstanceA = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceA.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(-8, Vector3.up);
        projectileInstanceA.direction = projectileInstanceA.gameObject.transform.forward;

        Projectile projectileInstanceB = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceB.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(0, Vector3.up);
        projectileInstanceB.direction = projectileInstanceB.gameObject.transform.forward;

        Projectile projectileInstanceC = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceC.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(8, Vector3.up);
        projectileInstanceC.direction = projectileInstanceC.gameObject.transform.forward;
    }

    //spawns projectile and shoots it at the cursor, and stops at cursor
    public void GroundTargetShot(Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float speed, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, float boonDur = 0, 
        float hexDur = 0, bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        Player player = Player.instance;
        MainControls mControls = player.GetControls();

        int layerMask = 1 << 20;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mControls.PlayerControls.Look.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            //fix raycast layer


            Vector3 targetPos = new Vector3(hit.point.x, emitter.position.y, hit.point.z);
            Projectile newProjectile = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, 
                passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
            StartCoroutine(MoveToTarget(newProjectile.gameObject, targetPos, 1f, speed));
        }
    }

    //spawns projectile at cursor
    public void GroundTargetSpawn(Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, float boonDur = 0, float hexDur = 0, 
        bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 targetPos = new Vector3(hit.point.x, 1.0f, hit.point.z);
            Projectile projectileInstance = Instantiate(proj, targetPos, emitter.rotation);
            projectileInstance.StartProjectile(attacker, weap, dStat, emitter.forward, damageMultiplier, hexes, boons, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);

        }
    }

    //fires stream of projectiles
    public void ChannelAttack(Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, float boonDur = 0, float hexDur = 0, 
        bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        StartCoroutine(ChannelAttack(0.03f, proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed));
    }

    //fires single shot in mouse cursor direction
    public void SingleShot(Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, float boonDur = 0, float hexDur = 0, 
        bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
    }

    //fires a burst of 3 projectiles in succession
    public void BurstShot(Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, float boonDur = 0, float hexDur = 0, 
        bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        StartCoroutine(ProjAttackBurst(0.08f, proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed));
    }

    //fires a spray of 4 projectiles that fans out like a cone, but in succession
    public void SprayShot(Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, float boonDur = 0, float hexDur = 0, 
        bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        StartCoroutine(ProjSprayBurst(0.1f, proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed));
    }

    //fires a burst of 5 projectiles in succession
    public void FullAutoShot(Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, float boonDur = 0, float hexDur = 0, 
        bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        StartCoroutine(ProjAttackAuto(0.09f, proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed));
    }


    //Coroutines for the above
    IEnumerator MoveToTarget(GameObject objectToMove, Vector3 targetPos, float seconds, float speed)
    {
        if (objectToMove != null)
        {
            float elapsedTime = 0;
            while (elapsedTime < seconds)
            {
                if (objectToMove != null)
                {
                    objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, targetPos, speed * Time.deltaTime);
                }
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                if (objectToMove != null)
                {
                    if (Vector3.Distance(objectToMove.transform.position, targetPos) < 1f)
                    {
                        if (objectToMove.GetComponent<Projectile>())
                        {
                            objectToMove.GetComponent<Projectile>().EndProjectile();
                        }
                    }
                }
            }
        }
    }
    IEnumerator ChannelAttack(float wTime, Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, 
        float boonDur = 0, float hexDur = 0, bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, 
        bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
    }    
    IEnumerator ProjAttackBurst(float wTime, Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, 
        float boonDur = 0, float hexDur = 0, bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, 
        bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
    }
    IEnumerator ProjAttackAuto(float wTime, Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, 
        float boonDur = 0, float hexDur = 0, bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, 
        bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        yield return new WaitForSeconds(wTime);

        CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
    }

    IEnumerator ProjSprayBurst(float wTime, Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, 
        float boonDur = 0, float hexDur = 0, bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, 
        bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        Projectile projectileInstanceA = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze,
            passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceA.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(-10, Vector3.up);
        projectileInstanceA.direction = projectileInstanceA.gameObject.transform.forward;
        yield return new WaitForSeconds(wTime);

        Projectile projectileInstanceB = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze,
            passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceB.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(-5, Vector3.up);
        projectileInstanceB.direction = projectileInstanceB.gameObject.transform.forward;
        yield return new WaitForSeconds(wTime);

        Projectile projectileInstanceC = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze,
            passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceC.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(0, Vector3.up);
        projectileInstanceC.direction = projectileInstanceC.gameObject.transform.forward;
        yield return new WaitForSeconds(wTime);

        Projectile projectileInstanceD = CreateProjectile(proj, attacker, weap, emitter, dStat, damageMultiplier, boons, hexes, boonDur, hexDur, freeze, 
            passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);
        projectileInstanceD.gameObject.transform.rotation = emitter.rotation * Quaternion.AngleAxis(5, Vector3.up);
        projectileInstanceD.direction = projectileInstanceD.gameObject.transform.forward;
    }

    //Create Projectile Function
    public Projectile CreateProjectile(Projectile proj, StatBlock attacker, InventoryItem weap, Transform emitter, DamageStat dStat, float damageMultiplier, BoonName[] boons = null, HexName[] hexes = null, 
        float boonDur = 0, float hexDur = 0, bool freeze = false, int passthrough = 0, bool causeDam = true, bool toPush = false, bool toPull = false, 
        bool persist = false, float inRange = 30f, int inSpeed = 40)
    {
        Projectile projectileInstance = Instantiate(proj, emitter.position, emitter.rotation);
        projectileInstance.StartProjectile(attacker, weap, dStat, emitter.forward, damageMultiplier, hexes, boons, boonDur, hexDur, freeze, passthrough, causeDam, toPush, toPull, persist, inRange, inSpeed);

        return projectileInstance;
    }

    #endregion
}
