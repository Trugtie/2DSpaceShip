using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected List<Transform> _spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (_spawnPoints.Count > 0) return;

        foreach (Transform child in transform)
        {
            _spawnPoints.Add(child);
        }

        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }

    public virtual Transform GetRandomSpawnPoint()
    {
        if (_spawnPoints.Count == 0)
        {
            Debug.LogWarning("Spawn Point List Empty!");
            return null;
        }

        Transform point = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

        return point;
    }
}
