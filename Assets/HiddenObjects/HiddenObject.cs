using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Scoreable))]
public class HiddenObject : MonoBehaviour
{
    public bool isTargetItem = false;
    public string printedName = string.Empty;

    private HiddenObjectSpawner _hiddenObjectSpawner;
    private Animator _animator;

    public void HighlightObject()
    {
        _animator.SetTrigger("Highlight");
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _hiddenObjectSpawner = GetComponentInParent<HiddenObjectSpawner>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetButtonDown("Fire2"))
        {
            Ship ship = collision.GetComponent<Ship>();
            Debug.Assert(ship != null, "Ship component not found on object tagged Player");
            if (isTargetItem)
            {
                StartCoroutine(HighlightCoroutine());
                var scoreable = GetComponent<Scoreable>();
                GameManager.Instance.ScorePoints(scoreable.score);
                ship.PutUpShield();
            }
            else
            {
                ship.PutDownShield();
            }
        }
    }

    private IEnumerator HighlightCoroutine()
    {
        HighlightObject();
        yield return new WaitForSeconds(2f);
        _hiddenObjectSpawner.RemoveHiddenObject(this);
    }
}
