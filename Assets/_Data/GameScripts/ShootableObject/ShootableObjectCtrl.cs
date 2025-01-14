using System;
using UnityEngine;

public abstract class ShootableObjectCtrl : BaseMonobehaviour
{
    protected const string MODEL = "Model";

    [Header(" ShootableObjectCtrl Elements ")]
    [SerializeField] protected Transform _model;
    [SerializeField] protected Despawn _despawn;
    [SerializeField] protected ShootableObjectSO _shootableObjectSO;

    public Transform Model { get => _model; }
    public Despawn Despawn { get => _despawn; }
    public ShootableObjectSO ShootableObjectSO => _shootableObjectSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadDespawn();
        LoadShootableObjectSO();
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

    protected abstract string GetStringFromObjectType();
}
