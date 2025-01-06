using UnityEngine;

public class VFXSpawner : Spawner
{
    public static string EXPLODE_VFX_1 = "ExplodeVFX_1";
    public static string IMPACT_1 = "Impact_1";

    public static VFXSpawner Instance { get; private set; }

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
