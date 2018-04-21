using UnityEngine;
using System.Collections;

public class TimedObject : MonoBehaviour
{
    public float objectLifetime = 1f;

    private void OnEnable()
    {
        StartCoroutine(DestructionCoroutine(objectLifetime));
    }

    private IEnumerator DestructionCoroutine(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }

}
