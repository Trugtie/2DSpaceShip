using UnityEngine;

public abstract class JunkAbstract : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected JunkCtrl _junkCtrl;
    public JunkCtrl JunkCtrl { get => _junkCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (_junkCtrl != null) return;

        _junkCtrl = transform.parent.GetComponent<JunkCtrl>();

        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }
}
