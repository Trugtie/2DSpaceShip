using UnityEngine;

public abstract class AbilityObjectCtrl : ShootableObjectCtrl
{
    [Header(" AbilityObjectCtrl Elements ")]
    [SerializeField] protected SpawnPoints _spawnPoints;
    public SpawnPoints SpawnPoints => _spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (_spawnPoints != null) return;
        _spawnPoints = GetComponentInChildren<SpawnPoints>();
        Debug.LogWarning(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
