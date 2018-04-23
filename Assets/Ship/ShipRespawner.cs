using UnityEngine;
using System.Collections;

public class ShipRespawner : FixedRespawner
{
    public override IEnumerator Respawn()
    {
        GameManager.Instance.LoseLife();
        if (GameManager.Instance.Lives <= 0)
        {
            yield return null;
        }
        else
        {
            yield return base.Respawn();
        }
    }
}
