using UnityEngine;

public class JunkFly : ParentObjectFly
{
    [SerializeField] protected float _cameraRandomPosBound;

    protected override void ResetValue()
    {
        base.ResetValue();
        _flySpeed = 1f;
        _direction = Vector3.right;
        _cameraRandomPosBound = 10f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        GetFlyDirection();
    }

    protected virtual void GetFlyDirection()
    {
        Vector3 objPos = transform.parent.position;
        Vector3 mainCameraPos = GameCtrl.Instance.GetMainCameraPosition();

        mainCameraPos.x = Random.Range(-_cameraRandomPosBound, _cameraRandomPosBound);
        mainCameraPos.y = Random.Range(-_cameraRandomPosBound, _cameraRandomPosBound);

        Vector3 direction = (mainCameraPos - objPos).normalized;

        LookAtDirection(direction);

        Debug.DrawLine(objPos, mainCameraPos + direction * 7, Color.red, Mathf.Infinity);

    }

    protected void LookAtDirection(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.parent.rotation = Quaternion.Euler(0, 0, angle);
    }
}
