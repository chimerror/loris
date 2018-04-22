using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
public class LifeBar : MonoBehaviour
{
    public Ship ship;
    public float barScale = 2f;

    private RectTransform _rectTransform;
    private Damageable _shipDamageable;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _shipDamageable = ship.GetComponent<Damageable>();
    }

    public void Update()
    {
        _rectTransform.sizeDelta = new Vector2(_shipDamageable.hitPoints * barScale, _rectTransform.sizeDelta.y);
    }
}
