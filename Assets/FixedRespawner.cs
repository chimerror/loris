using UnityEngine;
using System.Collections;

public class FixedRespawner : Respawner
{
    public Transform spawnPoint = null;

    public override IEnumerator Respawn()
    {
        yield return base.Respawn();
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
        }
    }

}
