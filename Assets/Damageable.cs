using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Damageable : MonoBehaviour
{
    public float hitPoints = 100;
    public float maxHitPoints = 100;
    public TimedObject damageExplosion = null;
    public TimedObject destroyedExplosion = null;

    private SpriteRenderer _spriteRenderer = null;
    private Respawner _respawner = null;

    public void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _respawner = GetComponent<Respawner>();
    }

    public void OnEnable()
    {
        _spriteRenderer.enabled = true;
    }

    public void Damage(float points)
    {
        hitPoints -= points;
        if (hitPoints <= 0f && destroyedExplosion != null)
        {
            _spriteRenderer.enabled = false;
            destroyedExplosion.gameObject.SetActive(true);
            StartCoroutine(WaitForDestroyedExplosion());
        }
        else if (damageExplosion != null)
        {
            damageExplosion.gameObject.SetActive(true);
        }
    }

    private IEnumerator WaitForDestroyedExplosion()
    {
        yield return new WaitForSeconds(destroyedExplosion.objectLifetime);
        if (_respawner == null)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(_respawner.Respawn());
        }
    }
}
