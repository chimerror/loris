using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Ship : MonoBehaviour
{
    public float HorizontalSpeed = 0.25f;
    public float VerticalSpeed = 0.25f;
    public float HorizontalWall = 10f;
    public float VerticalWall = 10f;

    public Shot shotPrefab = null;
    public float shotDelay = 0.75f;

    private SpriteRenderer _spriteRenderer = null;
    private bool _shootDelayOver = true;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!_spriteRenderer.enabled)
        {
            return;
        }

        Vector3 positionVector = transform.position;
        positionVector.x += HorizontalSpeed * Input.GetAxis("Horizontal");
        positionVector.x = Mathf.Clamp(positionVector.x, -HorizontalWall, HorizontalWall);
        positionVector.y += VerticalSpeed * Input.GetAxis("Vertical");
        positionVector.y = Mathf.Clamp(positionVector.y, -VerticalWall, VerticalWall);
        transform.position = positionVector;

        if (Input.GetButtonDown("Fire1") || (Input.GetButton("Fire1") && _shootDelayOver))
        {
            CreateShot();
        }
    }

    private void CreateShot()
    {
        Shot shot = Instantiate(shotPrefab, shotPrefab.transform.position, Quaternion.identity);
        shot.gameObject.SetActive(true);
        _shootDelayOver = false;
        StartCoroutine(ShootDelay());
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shotDelay);
        _shootDelayOver = true;
    }
}
