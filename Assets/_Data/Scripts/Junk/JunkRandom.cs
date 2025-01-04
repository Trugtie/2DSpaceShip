using UnityEngine;

[RequireComponent(typeof(JunkSpawnerCtrl))]
public class JunkRandom : BaseMonobehaviour
{
    [Header(" Elements")]
    [SerializeField] protected JunkSpawnerCtrl _junkSpawnerCtrl;

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

    protected override void Start()
    {
        JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform randomSpawnPoint = _junkSpawnerCtrl.JunkSpawnPoints.GetRandomSpawnPoint();
        Vector3 spawnPos = randomSpawnPoint.position;
        Quaternion rotation = Quaternion.identity;

        Transform junkTransfom = _junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.ASTEROID_1, spawnPos, rotation);
        junkTransfom.gameObject.SetActive(true);

        Invoke(nameof(JunkSpawning), 1f);
    }
}
