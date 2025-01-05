using UnityEngine;

public class BulletSpawner : Spawner
{
    public static string BLUE_SMALL_PROJECTILES = "Blue Small Projectile";

    public static BulletSpawner Instance { get; private set; }

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
