using UnityEngine;

[RequireComponent(typeof(JunkSpawner))]
public class JunkSpawnerCtrl : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected JunkSpawner _junkSpawner;
    [SerializeField] protected SpawnPoints _spawnPoints;
    public JunkSpawner JunkSpawner { get => _junkSpawner; }
    public SpawnPoints SpawnPoints { get => _spawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkSpawner();
        LoadSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (_junkSpawner != null) return;
        _junkSpawner = GetComponent<JunkSpawner>();
        Debug.LogWarning(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if (_spawnPoints != null) return;
        _spawnPoints = FindFirstObjectByType<SpawnPoints>();
        Debug.LogWarning(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
