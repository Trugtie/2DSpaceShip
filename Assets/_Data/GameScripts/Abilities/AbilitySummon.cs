using System;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header(" AbilitySummon Elements ")]
    [SerializeField] protected Spawner _spawner;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Summoning();
    }

    protected virtual void Summoning()
    {
        if (!_isReady) return;
        Summon();
    }

    protected virtual void Summon()
    {
        Transform minionPrefab = _spawner.GetRandomPrefab();

        Vector3 spawnPosition = _abilities.AbilityObjectCtrl.SpawnPoints.GetRandomSpawnPoint().position;

        Transform minion = _spawner.Spawn(minionPrefab, spawnPosition, Quaternion.identity);
        minion.gameObject.SetActive(true);
        Active();
    }
}
