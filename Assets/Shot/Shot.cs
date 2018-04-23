using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = .75f;
    public float offscreen = 4.25f;
    public float damage = 15f;
    public List<string> tagsToIgnore = new List<string>();

	private void Update()
    {
        if (Mathf.Abs(transform.position.y) >= offscreen)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tagsToIgnore.Any(t => collision.gameObject.CompareTag(t)))
        {
            return;
        }

        var damageable = collision.gameObject.GetComponent<Damageable>();
        if (damageable != null)
        {
            var spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            Debug.Assert(spriteRenderer != null, "Could not get SpriteRenderer from Damageable");

            if (spriteRenderer.enabled)
            {
                damageable.Damage(damage);
                Destroy(gameObject);
            }
        }
    }
}
