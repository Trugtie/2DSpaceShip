using UnityEngine;

public class JunkCtrl : BaseMonobehaviour
{
    protected const string MODEL = "Model";

    [Header(" Elements ")]
    [SerializeField] protected Transform _model;
    public Transform Model { get => _model; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (_model != null) return;

        _model = transform.Find(MODEL);

        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}
