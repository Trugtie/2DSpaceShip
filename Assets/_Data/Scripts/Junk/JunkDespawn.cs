using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    protected override void ResetValue()
    {
        base.ResetValue();
        _limitDistance = 25f;
    }

    public override void DespawnOject()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }
}
