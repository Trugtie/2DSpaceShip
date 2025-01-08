using UnityEngine;

public class ItemDespawn : DespawnByDistance
{
    protected override void ResetValue()
    {
        base.ResetValue();
        _limitDistance = 70f;
    }

    public override void DespawnOject()
    {
        ItemSpawner.Instance.Despawn(transform.parent);
    }
}
