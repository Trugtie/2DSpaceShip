using TMPro;
using UnityEngine;


public class TextShipHP : BaseText
{
    [Header(" TextShipHP Elements ")]
    [SerializeField] protected DamgeReceiver _playerDamgeReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerDamgeReceiver();
    }

    protected virtual void LoadPlayerDamgeReceiver()
    {
        if (_playerDamgeReceiver != null) return;
        _playerDamgeReceiver = PlayerCtrl.Instance.CurrentShip.DamgeReceiver;
        Debug.LogWarning(transform.name + ": LoadDamgeReceiver", gameObject);
    }

    protected override void Start()
    {
        _playerDamgeReceiver.OnHpChange += OnHpChangeCallBack;
    }

    protected override void OnDestroy()
    {
        _playerDamgeReceiver.OnHpChange -= OnHpChangeCallBack;
    }

    private void OnHpChangeCallBack()
    {
        UpdateTextHP();
    }

    protected virtual void UpdateTextHP()
    {
        int currentHP = _playerDamgeReceiver.CurrentHP;
        int maxHP = _playerDamgeReceiver.MaxHP;

        _text.SetText($"{currentHP} / {maxHP}");
    }
}
