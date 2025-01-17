using System;
using UnityEngine;

public abstract class ShootableObjectCtrl : BaseMonobehaviour
{
    protected const string MODEL = "Model";

    [Header(" ShootableObjectCtrl Elements ")]
    [SerializeField] protected Transform _model;
    [SerializeField] protected Despawn _despawn;
    [SerializeField] protected ShootableObjectSO _shootableObjectSO;
    [SerializeField] protected ObjectShooting _objectShooting;
    [SerializeField] protected ObjectMovement _objectMovement;
    [SerializeField] protected ObjectLookAtTarget _objectLookAtTarget;
    [SerializeField] protected Spawner _spawner;
    [SerializeField] protected DamgeReceiver _damgeReceiver;
    public Transform Model => _model;
    public Despawn Despawn => _despawn;
    public ShootableObjectSO ShootableObjectSO => _shootableObjectSO;

    public ObjectShooting ObjectShooting => _objectShooting;
    public ObjectMovement ObjectMovement => _objectMovement;
    public ObjectLookAtTarget ObjectLookAtTarget => _objectLookAtTarget;
    public Spawner Spawner => _spawner;
    public DamgeReceiver DamgeReceiver => _damgeReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadDespawn();
        LoadShootableObjectSO();
        LoadObjectShooting();
        LoadObjectMovement();
        LoadObjectLookAtTarget();
        LoadSpawner();
        LoadDamgeReceiver();
    }

    protected virtual void LoadDamgeReceiver()
    {
        if (_damgeReceiver != null) return;
        _damgeReceiver = GetComponentInChildren<DamgeReceiver>();

        Debug.LogWarning(transform.name + ": LoadDamgeReceiver", gameObject);
    }

    protected virtual void LoadSpawner()
    {
        if (_spawner != null) return;
        _spawner = transform?.parent?.parent.GetComponent<Spawner>();

        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadObjectLookAtTarget()
    {
        if (_objectLookAtTarget != null) return;
        _objectLookAtTarget = GetComponentInChildren<ObjectLookAtTarget>();

        Debug.LogWarning(transform.name + ": LoadObjectLookAtTarget", gameObject);
    }

    protected virtual void LoadObjectMovement()
    {
        if (_objectMovement != null) return;
        _objectMovement = GetComponentInChildren<ObjectMovement>();

        Debug.LogWarning(transform.name + ": LoadObjectMovement", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (_model != null) return;
        _model = transform.Find(MODEL);

        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (_despawn != null) return;
        _despawn = GetComponentInChildren<Despawn>();

        Debug.LogWarning(transform.name + ": LoadDespawn", gameObject);
    }

    protected virtual void LoadShootableObjectSO()
    {
        if (_shootableObjectSO != null) return;

        string resPath = $"ShootableObject/{GetStringFromObjectType()}/" + transform.name;
        _shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);

        Debug.LogWarning(transform.name + ": ShootableObjectSO " + resPath, gameObject);
    }

    protected void LoadObjectShooting()
    {
        if (_objectShooting != null) return;
        _objectShooting = GetComponentInChildren<ObjectShooting>();

        Debug.LogWarning(transform.name + ": LoadObjectShooting", gameObject);
    }

    protected abstract string GetStringFromObjectType();
}
