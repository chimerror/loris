using UnityEngine;
using System.Collections;
using System.Collections.ObjectModel;

public class DamageableShip : Damageable
{
    public HiddenObjectSpawner hiddenObjectSpawner = null;

    protected override void OnDamageableDestroyed()
    {
        base.OnDamageableDestroyed();
        ReadOnlyCollection<HiddenObject> targetObjects = hiddenObjectSpawner.TargetObjects;

        int highlightedObjectIndex = Random.Range(0, targetObjects.Count);
        HiddenObject highlightedObject = targetObjects[highlightedObjectIndex];
        highlightedObject.HighlightObject();
    }
}
