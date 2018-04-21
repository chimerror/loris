using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Damageable))]
public abstract class Respawner : MonoBehaviour
{
    public float respawnDelay = 2f;

    private SpriteRenderer _spriteRenderer = null;
    private Damageable _damageable = null;

    public virtual IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);
        _damageable.hitPoints = _damageable.maxHitPoints;
        _spriteRenderer.enabled = true;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _damageable = GetComponent<Damageable>();
    }
}
