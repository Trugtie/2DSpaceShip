using UnityEngine;

public class MothershipDespawn : DespawnByDistance
{
    protected override void ResetValue()
    {
        base.ResetValue();
        _limitDistance = 25f;
    }

    public override void DespawnOject()
    {
        MothershipSpawner.Instance.Despawn(transform.parent);
    }
}
