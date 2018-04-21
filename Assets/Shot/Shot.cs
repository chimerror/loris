using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = .75f;
    public float offscreen = 4.25f;

	private void Update()
    {
        if (transform.position.y >= offscreen)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }
	}
}
