using System;
using UnityEngine;

public class ObjectMoveForward : ObjectMovement
{
    [Header(" ObjectMoveForward Elements ")]
    [SerializeField] protected Transform _forwardTarget;

    protected override void FixedUpdate()
    {
        SetForwardTarget();
        base.FixedUpdate();
    }

    private void Init()
    {
        if (transform.childCount > 0) return;

        GameObject forwardTargetGameObject = new GameObject();
        forwardTargetGameObject.name = "Forward Target";
        forwardTargetGameObject.transform.parent = transform;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadForwardTarget();
    }

    private void LoadForwardTarget()
    {
        if (_forwardTarget != null) return;

        Init();

        _forwardTarget = transform.GetChild(0);
        _forwardTarget.localPosition = Vector3.right;

        Debug.LogWarning(transform.name + ": LoadForwardTarget", gameObject);
    }

    protected void SetForwardTarget()
    {
        _targetPosition = _forwardTarget.position;
        _targetPosition.z = 0;
    }
}
