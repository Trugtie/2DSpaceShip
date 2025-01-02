using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Spawner : BaseMonobehaviour
{
    private const string PREFABS = "Prefabs";

    [Header(" Elements ")]
    [SerializeField] protected List<Transform> _prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (_prefabs.Count > 0) return;

        Transform prefabsObj = transform.Find(PREFABS);

        foreach (Transform prefab in prefabsObj)
        {
            _prefabs.Add(prefab);
        }

        HidePrefabs();

        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in _prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);

        if (prefab == null)
        {
            Debug.LogWarning("Prefab Not Found: " + prefabName);
            return null;
        }

        Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
        return newPrefab;
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in _prefabs)
        {
            if (prefabName == prefab.name) return prefab;
        }

        return null;
    }
}
