using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    protected override void ResetValue()
    {
        base.ResetValue();
        _limitDistance = 25f;
    }

    public override void DespawnOject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }
}
