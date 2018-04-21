using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab = null;
    public float horizontalRange = 9f;
    public float spawnChance = 0.25f;

    private void Update()
    {
        if (Random.Range(0f, 1f) <= spawnChance)
        {
            GameObject asteroid = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
            float horizontalPosition = Random.Range(-horizontalRange, horizontalRange);
            asteroid.transform.position =
                new Vector3(horizontalPosition, asteroid.transform.position.y, asteroid.transform.position.z);
            asteroid.gameObject.SetActive(true);
        }
    }

}
