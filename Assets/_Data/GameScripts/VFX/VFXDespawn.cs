using UnityEngine;

public class VFXDespawn : DespawnByTime
{
    public override void DespawnOject()
    {
        VFXSpawner.Instance.Despawn(transform.parent);
    }
}
