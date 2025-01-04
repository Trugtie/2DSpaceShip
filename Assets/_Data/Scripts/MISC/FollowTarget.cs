using UnityEngine;

public class FollowTarget : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected Transform _target;

    [Header(" Settings ")]
    [SerializeField] protected float _followSpeed = 7f;

    protected virtual void FixedUpdate()
    {
        Following();
    }

    protected virtual void Following()
    {
        if (_target == null) return;
        transform.position = Vector3.Lerp(transform.position, _target.position, _followSpeed * Time.fixedDeltaTime);
    }
}
