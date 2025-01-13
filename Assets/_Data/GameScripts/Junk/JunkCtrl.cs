using Mono.Cecil;
using UnityEngine;

public class JunkCtrl : BaseMonobehaviour
{
    protected const string MODEL = "Model";

    [Header(" Elements ")]
    [SerializeField] protected Transform _model;
    [SerializeField] protected JunkDespawn _junkDespawn;
    [SerializeField] protected ShootableObjectSO _shootableObjectSO;

    public Transform Model { get => _model; }
    public JunkDespawn JunkDespawn { get => _junkDespawn; }
    public ShootableObjectSO ShootableObjectSO => _shootableObjectSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadJunkDespawn();
        LoadShootableObjectSO();
    }

    protected virtual void LoadModel()
    {
        if (_model != null) return;
        _model = transform.Find(MODEL);

        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (_junkDespawn != null) return;
        _junkDespawn = GetComponentInChildren<JunkDespawn>();

        Debug.LogWarning(transform.name + ": LoadJunkDespawn", gameObject);
    }

    protected virtual void LoadShootableObjectSO()
    {
        if (_shootableObjectSO != null) return;

        string resPath = "ShootableObject/Junk/" + transform.name;
        _shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);

        Debug.LogWarning(transform.name + ": ShootableObjectSO " + resPath, gameObject);
    }
}
