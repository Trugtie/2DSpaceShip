using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    public override void DespawnOject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
