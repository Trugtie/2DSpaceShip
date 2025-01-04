using UnityEngine;

public class JunkCtrl : BaseMonobehaviour
{
    protected const string MODEL = "Model";

    [Header(" Elements ")]
    [SerializeField] protected Transform _model;
    [SerializeField] protected JunkDespawn _junkDespawn;
    public Transform Model { get => _model; }
    public JunkDespawn JunkDespawn { get => _junkDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadJunkDespawn();
    }

    protected virtual void LoadModel()
    {
        if (_model != null) return;
        _model = transform.Find(MODEL);

        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (_junkDespawn != null) return;
        _junkDespawn = GetComponentInChildren<JunkDespawn>();

        Debug.Log(transform.name + ": LoadJunkDespawn", gameObject);
    }
}
