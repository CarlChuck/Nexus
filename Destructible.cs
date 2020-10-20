using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : StatBlock
{
    [SerializeField] private LootSpawner lootSpawn = default;
    [SerializeField] private Fracture fracture = default;
    [SerializeField] private BoxCollider bCollider = default;

    public override void Start()
    {
        base.Start();
    }

    public override void TakeDamage(StatBlock attacker, int weapDamage, int damageStat, DamageType dType, int dTypeValue, bool hasCrit)
    {
        base.TakeDamage(attacker, weapDamage, damageStat, dType, dTypeValue, hasCrit);
    }

    public override void TakeDamageFinal(int damage, StatBlock attacker)
    {
        Debug.Log("boom");
        base.TakeDamageFinal(damage, attacker);
    }

    public override void OnDeath()
    {
        Destroy(bCollider);
        fracture.OnDestruction();
        CameraController camera = FindObjectOfType<CameraController>();
        camera.shake(0.1f, 0.1f);
        lootSpawn.DropLoot();
    }
}
