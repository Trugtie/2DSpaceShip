using UnityEngine;

public class HPBarSpawner : Spawner
{
    public static string HP_BAR = "HP Bar";

    public static HPBarSpawner Instance { get; private set; }

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
