using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class SpawnerCtrl : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected Spawner _spawner;
    [SerializeField] protected SpawnPoints _spawnPoints;
    public Spawner Spawner => _spawner;
    public SpawnPoints SpawnPoints => _spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpawner();
        LoadSpawnPoints();
    }

    protected virtual void LoadSpawner()
    {
        if (_spawner != null) return;
        _spawner = GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if (_spawnPoints != null) return;
        _spawnPoints = FindFirstObjectByType<SpawnPoints>();
        Debug.LogWarning(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
