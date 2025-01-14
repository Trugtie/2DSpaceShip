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
}
