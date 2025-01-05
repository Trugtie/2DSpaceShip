using UnityEngine;

public abstract class Despawn : BaseMonobehaviour
{
    protected virtual void FixedUpdate()
    {
        Despawning();
    }

    protected void Despawning()
    {
        if (!CanDespawn()) return;

        DespawnOject();
    }

    protected abstract bool CanDespawn();

    public virtual void DespawnOject()
    {
        Destroy(transform.parent.gameObject);
    }
}
