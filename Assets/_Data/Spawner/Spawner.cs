using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const string PREFABS = "Prefabs";

    [Header(" Elements ")]
    [SerializeField] protected List<Transform> _prefabs;

    private void Reset()
    {
        LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        Transform prefabsObj = transform.Find(PREFABS);

        foreach (Transform prefab in prefabsObj)
        {
            _prefabs.Add(prefab);
        }

        HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in _prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

}
