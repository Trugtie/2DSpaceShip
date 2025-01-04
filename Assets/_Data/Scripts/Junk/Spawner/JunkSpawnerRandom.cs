using UnityEngine;

[RequireComponent(typeof(JunkSpawnerCtrl))]
public class JunkSpawnerRandom : BaseMonobehaviour
{
    [Header(" Elements")]
    [SerializeField] protected JunkSpawnerCtrl _junkSpawnerCtrl;

    [Header(" Settings ")]
    [SerializeField] protected float _spawnDelayTime;
    [SerializeField] protected float _spawnDelayTimer;
    [SerializeField] protected int _spawnCountLimit;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkSpawnerCtrl();
    }

    protected virtual void LoadJunkSpawnerCtrl()
    {
        if (_junkSpawnerCtrl != null) return;
        _junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadJunkSpawnerCtrl", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (IsReachSpawnLimit()) return;

        _spawnDelayTimer += Time.fixedDeltaTime;
        if (_spawnDelayTimer < _spawnDelayTime) return;
        _spawnDelayTimer = 0;

        Transform randomSpawnPoint = _junkSpawnerCtrl.JunkSpawnPoints.GetRandomSpawnPoint();
        Vector3 spawnPos = randomSpawnPoint.position;
        Quaternion rotation = Quaternion.identity;

        Transform junkTransfom = _junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.ASTEROID_1, spawnPos, rotation);
        junkTransfom.gameObject.SetActive(true);
    }

    protected virtual bool IsReachSpawnLimit()
    {
        int currentJunk = _junkSpawnerCtrl.JunkSpawner.SpawnedCount;

        return currentJunk >= _spawnCountLimit;
    }
}
