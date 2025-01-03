using UnityEngine;

public class JunkSpawner : Spawner
{
    public static string ASTEROID_1 = "Asteroid_1";

    public static JunkSpawner Instance { get; private set; }

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
