using UnityEngine;
using System.Collections;

public class DamageableEnemy : Damageable
{
    public HiddenObjectSpawner hiddenObjectSpawner = null;

    protected override void OnDamageableDestroyed()
    {
        base.OnDamageableDestroyed();
        hiddenObjectSpawner.AddTargetObject();
    }
}
