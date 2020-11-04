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

    public override void TakeDamage(StatBlock attacker, float thermDamage, float cryoDamage, float shockDamage, float radDamage, float psiDamage, float dimensionDamage,
        float kineticDamage, float poisonDamage, float bioDamage, float corruptionDamage)
    {
        base.TakeDamage(attacker, thermDamage, cryoDamage, shockDamage, radDamage, psiDamage, dimensionDamage, kineticDamage, poisonDamage, bioDamage, corruptionDamage);
    }

    public override void TakeDamageFinal(StatBlock attacker, int damage)
    {
        Debug.Log("boom");
        base.TakeDamageFinal(attacker, damage);
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
