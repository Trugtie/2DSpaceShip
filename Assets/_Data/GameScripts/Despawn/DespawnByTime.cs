using UnityEngine;

public class DespawnByTime : Despawn
{
    [Header(" Settings ")]
    [SerializeField] protected float _maxTime;
    [SerializeField] protected float _timer;

    protected override bool CanDespawn()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer > _maxTime)
        {
            _timer = 0;
            return true;
        }

        return false;
    }
}
