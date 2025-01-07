using UnityEngine;

public abstract class PlayerAbtract : BaseMonobehaviour
{
    [Header(" Player Abtract")]
    [SerializeField] protected PlayerCtrl _playerCtrl;

    public PlayerCtrl PlayerCtrl => _playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (_playerCtrl != null) return;

        _playerCtrl = GetComponentInParent<PlayerCtrl>();

        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
