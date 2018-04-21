using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float hitPoints = 100;

    private void Update()
    {
        if (hitPoints < 0f)
        {
            Destroy(gameObject);
        }
    }
}
