using UnityEngine;

[RequireComponent(typeof(JunkSpawner))]
public class JunkSpawnerCtrl : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected JunkSpawner _junkSpawner;
    [SerializeField] protected JunkSpawnPoints _junkSpawnPoints;
    public JunkSpawner JunkSpawner { get => _junkSpawner; }
    public JunkSpawnPoints JunkSpawnPoints { get => _junkSpawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkSpawner();
        LoadJunkSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (_junkSpawner != null) return;
        _junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadJunkSpawnPoints()
    {
        if (_junkSpawnPoints != null) return;
        _junkSpawnPoints = FindFirstObjectByType<JunkSpawnPoints>();
        Debug.Log(transform.name + ": LoadJunkSpawnPoints", gameObject);
    }
}
