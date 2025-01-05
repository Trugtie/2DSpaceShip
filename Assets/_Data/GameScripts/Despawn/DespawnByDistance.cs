using UnityEngine;

public class DespawnByDistance : Despawn
{
    [Header(" Elements ")]
    [SerializeField] protected Camera _mainCamera;

    [Header(" Settings ")]
    [SerializeField] protected float _limitDistance = 30f;
    [SerializeField] protected float _currentDistance = 0f;

    protected override void LoadComponents()
    {
        LoadCamera();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _limitDistance = 30f;
    }

    protected virtual void LoadCamera()
    {
        if (_mainCamera != null) return;

        _mainCamera = Camera.main;

        Debug.LogWarning(transform.parent.name + ": LoadCamera", gameObject);
    }

    protected override bool CanDespawn()
    {
        _currentDistance = Vector3.Distance(transform.parent.position, _mainCamera.transform.position);
        if (_currentDistance > _limitDistance) return true;
        return false;
    }
}
