using System;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemySpawner();
    }

    protected virtual void LoadEnemySpawner()
    {
        if (_spawner != null) return;
        _spawner = FindAnyObjectByType<EnemySpawner>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawner", gameObject);
    }
}
