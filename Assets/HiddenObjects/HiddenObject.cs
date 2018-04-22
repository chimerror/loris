using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HiddenObject : MonoBehaviour
{
    public bool isTargetItem = false;
    public string printedName = string.Empty;

    private HiddenObjectSpawner _hiddenObjectSpawner;

    private void Awake()
    {
        _hiddenObjectSpawner = GetComponentInParent<HiddenObjectSpawner>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isTargetItem && collision.CompareTag("Player") && Input.GetButton("Fire2"))
        {
            _hiddenObjectSpawner.RemoveHiddenObject(this);
            Ship ship = collision.GetComponent<Ship>();
            Debug.Assert(ship != null, "Ship component not found on object tagged Player");
            ship.PutUpShield();
        }
    }
}
