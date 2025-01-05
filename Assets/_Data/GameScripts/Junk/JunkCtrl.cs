using Mono.Cecil;
using UnityEngine;

public class JunkCtrl : BaseMonobehaviour
{
    protected const string MODEL = "Model";

    [Header(" Elements ")]
    [SerializeField] protected Transform _model;
    [SerializeField] protected JunkDespawn _junkDespawn;
    [SerializeField] protected JunkSO _junkSO;

    public Transform Model { get => _model; }
    public JunkDespawn JunkDespawn { get => _junkDespawn; }
    public JunkSO JunkSO => _junkSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadJunkDespawn();
        LoadJunkSO();
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

    protected virtual void LoadJunkSO()
    {
        if (_junkSO != null) return;

        string resPath = "Junk/" + transform.name;
        _junkSO = Resources.Load<JunkSO>(resPath);

        Debug.LogWarning(transform.name + ": LoadJunkSO " + resPath, gameObject);
    }
}
