using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    [Header(" AbilitySummonEnemy Settings ")]
    [SerializeField] protected int _limitEnemy = 4;
    [SerializeField] protected List<Transform> _enemiesSpawned;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ClearEnemiesDead();
    }

    protected virtual void ClearEnemiesDead()
    {
        foreach (Transform enemy in _enemiesSpawned)
        {
            if (enemy.gameObject.activeSelf == false)
            {
                _enemiesSpawned.Remove(enemy);
                return;
            }
        }
    }

    protected override void Summoning()
    {
        if (_enemiesSpawned.Count >= _limitEnemy) return;
        base.Summoning();
    }

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

    protected override Transform Summon()
    {
        Transform minion = base.Summon();
        minion.parent = Abilities.AbilityObjectCtrl.transform;
        _enemiesSpawned.Add(minion);
        return minion;
    }
}
