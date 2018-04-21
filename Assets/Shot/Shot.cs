using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = .75f;
    public float offscreen = 4.25f;
    public float damage = 15f;

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
        var damageable = collision.gameObject.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.Damage(damage);
            Destroy(gameObject);
        }
    }
}
