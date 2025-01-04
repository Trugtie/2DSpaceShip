using UnityEngine;

public class ParentObjectFly : BaseMonobehaviour
{
    [Header(" Settings ")]
    [SerializeField] protected float _flySpeed = 10f;
    [SerializeField] protected Vector3 _direction = Vector3.right;

    protected override void ResetValue()
    {
        base.ResetValue();
        _flySpeed = 10f;
        _direction = Vector3.right;
    }

    private void Update()
    {
        Fly();
    }

    protected virtual void Fly()
    {
        transform.parent.Translate(_direction * _flySpeed * Time.deltaTime);
    }
}
