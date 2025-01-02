using System.Collections.Generic;
using UnityEngine;

public class Spawner : BaseMonobehaviour
{
    private const string PREFABS = "Prefabs";

    public static Spawner Instance { get; private set; }

    [Header(" Elements ")]
    [SerializeField] protected List<Transform> _prefabs;

    protected override void Awake()
    {
        base.Awake();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

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

    public virtual Transform Spawn(Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = _prefabs[0];
        Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
        return newPrefab;
    }

}
