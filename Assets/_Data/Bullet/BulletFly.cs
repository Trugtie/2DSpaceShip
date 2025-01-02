using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] protected float _bulletSpeed = 10f;
    [SerializeField] protected Vector3 _direction = Vector3.right;

    private void Update()
    {
        Fly();
    }

    protected virtual void Fly()
    {
        transform.parent.Translate(_direction * _bulletSpeed * Time.deltaTime);
    }
}
