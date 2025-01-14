using UnityEngine;

[RequireComponent(typeof(SpawnerCtrl))]
public class SpawnerRandom : BaseMonobehaviour
{
    [Header(" Elements")]
    [SerializeField] protected SpawnerCtrl _spawnerCtrl;

    [Header(" Settings ")]
    [SerializeField] protected float _spawnDelayTime;
    protected float _spawnDelayTimer;

    [SerializeField] protected int _spawnCountLimit;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpawnerCtrl();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _spawnDelayTime = 2f;
        _spawnCountLimit = 30;
    }


    protected virtual void LoadSpawnerCtrl()
    {
        if (_spawnerCtrl != null) return;
        _spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpawnerCtrl", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        Spawning();
    }

    protected virtual void Spawning()
    {
        if (IsReachSpawnLimit()) return;

        _spawnDelayTimer += Time.fixedDeltaTime;
        if (_spawnDelayTimer < _spawnDelayTime) return;
        _spawnDelayTimer = 0;

        Transform randomSpawnPoint = _spawnerCtrl.SpawnPoints.GetRandomSpawnPoint();
        Vector3 spawnPos = randomSpawnPoint.position;
        Quaternion rotation = Quaternion.identity;

        Transform prefab = _spawnerCtrl.Spawner.GetRandomPrefab();
        Transform junkTransfom = _spawnerCtrl.Spawner.Spawn(prefab, spawnPos, rotation);
        junkTransfom.gameObject.SetActive(true);
    }

    protected virtual bool IsReachSpawnLimit()
    {
        int currentJunk = _spawnerCtrl.Spawner.SpawnedCount;

        return currentJunk >= _spawnCountLimit;
    }
}
