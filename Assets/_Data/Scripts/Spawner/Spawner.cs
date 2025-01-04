using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public abstract class Spawner : BaseMonobehaviour
{
    private const string PREFABS = "Prefabs";
    private const string HOLDER = "Holder";

    [Header(" Elements ")]
    [SerializeField] protected List<Transform> _prefabs;
    [SerializeField] protected List<Transform> _poolObjs;
    [SerializeField] protected Transform _holder;

    [SerializeField] protected int _spawnedCount;
    public int SpawnedCount { get => _spawnedCount; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHolder();
        LoadPrefabs();
    }

    protected virtual void LoadHolder()
    {
        if (_holder != null) return;

        _holder = transform.Find(HOLDER);

        Debug.Log(transform.name + ": LoadHodler", gameObject);
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

        Transform newPrefab = GetObjFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.parent = _holder;
        _spawnedCount++;

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

    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach (Transform poolObj in _poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                _poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        _poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        _spawnedCount--;
    }
}
