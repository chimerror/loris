using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Respawner : MonoBehaviour
{
    public float respawnDelay = 2f;

    private SpriteRenderer _spriteRenderer = null;

    public virtual IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);
        _spriteRenderer.enabled = true;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
