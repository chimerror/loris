using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var damageable = collision.gameObject.GetComponent<Damageable>();
            Debug.Assert(damageable != null, "No Damageable on object tagged Enemy!");
            damageable.Damage(damageable.maxHitPoints);
        }
    }
}
