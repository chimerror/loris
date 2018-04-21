using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float HorizontalSpeed = 2.5f;
    public float VerticalSpeed = 2.5f;

	private void Update ()
    {
        Vector3 positionVector = transform.position;
        positionVector.x += HorizontalSpeed * Input.GetAxis("Horizontal");
        positionVector.y += VerticalSpeed * Input.GetAxis("Vertical");
        transform.position = positionVector;
	}
}
