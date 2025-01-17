using System;
using System.Transactions;
using UnityEngine;

public class EnemySpawner : Spawner
{
    public static EnemySpawner Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        AddHPBarToNewEnemy(newEnemy);
        return newEnemy;
    }

    protected virtual void AddHPBarToNewEnemy(Transform newEnemy)
    {
        ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHPBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HP_BAR, newEnemy.position, Quaternion.identity);
        HPBar hpBar = newHPBar.GetComponent<HPBar>();
        hpBar.SetShootableObjectCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);

        newHPBar.gameObject.SetActive(true);
    }
}
