using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections.ObjectModel;

public class TargetList : MonoBehaviour
{
    public HiddenObjectSpawner hiddenObjectSpawner;
    public Text targetItemPrefab;

    private List<Text> _availableTargetItems = new List<Text>();

    private void Update()
    {
        ReadOnlyCollection<HiddenObject> targetObjects = hiddenObjectSpawner.TargetObjects;
        while (_availableTargetItems.Count < targetObjects.Count)
        {
            Text targetItem = Instantiate(targetItemPrefab, transform);
            _availableTargetItems.Add(targetItem);
            targetItem.gameObject.SetActive(true);
        }

        while (_availableTargetItems.Count > targetObjects.Count)
        {
            Text objectBeingRemoved = _availableTargetItems[0];
            _availableTargetItems.RemoveAt(0);
            Destroy(objectBeingRemoved.gameObject);
        }

        for (int currentTargetItem = 0; currentTargetItem < _availableTargetItems.Count; currentTargetItem++)
        {
            _availableTargetItems[currentTargetItem].text = targetObjects[currentTargetItem].printedName;
        }
    }
}
