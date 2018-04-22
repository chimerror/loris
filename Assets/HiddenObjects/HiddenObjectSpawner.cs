using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class HiddenObjectSpawner : MonoBehaviour
{
    public float horizontalRange = 8f;
    public float verticalRange = 4f;
    public int _objectsVisible = 5;
    public float targetObjectPercentage = 0.25f;
    public int minimumTargetObjects = 3;
    public int maximumTargetObjects = 8;
    public int objectsToAlter = 2;

    private HiddenObject[] _hiddenObjectPrefabs = null;
    private List<HiddenObject> _visibleObjects = new List<HiddenObject>();
    private List<HiddenObject> _targetObjects = new List<HiddenObject>();

    public ReadOnlyCollection<HiddenObject> TargetObjects
    {
        get
        {
            return _targetObjects.AsReadOnly();
        }
    }

    public void AddTargetObject()
    {
        if (_targetObjects.Count >= maximumTargetObjects)
        {
            return;
        }

        int newTargetObjectIndex;
        HiddenObject newTargetObject;
        do
        {
            newTargetObjectIndex = Random.Range(0, _visibleObjects.Count - 1);
            newTargetObject = _visibleObjects[newTargetObjectIndex];
        } while (_targetObjects.Contains(newTargetObject));

        newTargetObject.isTargetItem = true;
        _targetObjects.Add(newTargetObject);
    }

    public void RemoveHiddenObject(HiddenObject hiddenObject)
    {
        hiddenObject.gameObject.SetActive(false);
        _visibleObjects.Remove(hiddenObject);
        _targetObjects.Remove(hiddenObject);
    }

    private void Awake()
    {
        _hiddenObjectPrefabs = GetComponentsInChildren<HiddenObject>(true);
    }

    private void Update()
    {
        while (_visibleObjects.Count < _objectsVisible)
        {
            int newObjectIndex;
            HiddenObject newObject;
            do
            {
                newObjectIndex = Random.Range(0, _hiddenObjectPrefabs.Length - 1);
                newObject = _hiddenObjectPrefabs[newObjectIndex];
            } while (_visibleObjects.Contains(newObject));

            float horizontalPosition = Random.Range(-horizontalRange, horizontalRange);
            float verticalPosition = Random.Range(-verticalRange, verticalRange);
            newObject.transform.position =
                new Vector3(horizontalPosition, verticalPosition, newObject.transform.position.z);

            if (_targetObjects.Count < minimumTargetObjects || Random.Range(0f, 1f) < targetObjectPercentage)
            {
                newObject.isTargetItem = true;
                _targetObjects.Add(newObject);

                if (_visibleObjects.Count > 0)
                {
                    for (int currAlteredObject = 0; currAlteredObject < objectsToAlter; currAlteredObject++)
                    {
                        float horizontalAlteredPosition = Random.Range(-horizontalRange, horizontalRange);
                        float verticalAlteredPosition = Random.Range(-verticalRange, verticalRange);
                        int objectToAlterIndex = Random.Range(0, _visibleObjects.Count - 1);
                        HiddenObject objectToAlter = _visibleObjects[objectToAlterIndex];
                        objectToAlter.transform.position =
                            new Vector3(horizontalAlteredPosition, verticalAlteredPosition, objectToAlter.transform.position.z);
                    }
                }
            }
            else
            {
                newObject.isTargetItem = false;
            }

            _visibleObjects.Add(newObject);
            newObject.gameObject.SetActive(true);

        }
    }
}
