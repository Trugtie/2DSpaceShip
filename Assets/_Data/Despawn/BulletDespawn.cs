using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    protected override void DespawnOject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
