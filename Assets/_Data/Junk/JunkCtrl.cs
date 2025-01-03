using UnityEngine;

[RequireComponent(typeof(JunkSpawner))]
public class JunkCtrl : BaseMonobehaviour
{
    [Header(" Elements ")]
    [SerializeField] protected JunkSpawner _junkSpawner;
    public JunkSpawner JunkSpawner { get => _junkSpawner; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkSpawner();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (_junkSpawner != null) return;
        _junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }
}
