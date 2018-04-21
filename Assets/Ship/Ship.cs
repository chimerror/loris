using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float HorizontalSpeed = 0.25f;
    public float VerticalSpeed = 0.25f;
    public float HorizontalWall = 10f;
    public float VerticalWall = 10f;

	private void Update ()
    {
        Vector3 positionVector = transform.position;
        positionVector.x += HorizontalSpeed * Input.GetAxis("Horizontal");
        positionVector.x = Mathf.Clamp(positionVector.x, -HorizontalWall, HorizontalWall);
        positionVector.y += VerticalSpeed * Input.GetAxis("Vertical");
        positionVector.y = Mathf.Clamp(positionVector.y, -VerticalWall, VerticalWall);
        transform.position = positionVector;
	}
}
