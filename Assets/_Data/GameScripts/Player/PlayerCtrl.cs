using System;
using UnityEngine;

public class PlayerCtrl : BaseMonobehaviour
{
    public static PlayerCtrl Instance { get; private set; }

    [Header(" Elements ")]
    [SerializeField] protected ShipCtrl _currentShip;
    [SerializeField] protected PlayerPickup _playerPickup;
    [SerializeField] protected PlayerAbility _playerAbility;

    public PlayerAbility PlayerAbility => _playerAbility;
    public ShipCtrl CurrentShip => _currentShip;
    public PlayerPickup PlayerPickup => _playerPickup;

    protected override void Awake()
    {
        base.Awake();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerPickup();
        LoadPlayerAbility();
    }

    protected virtual void LoadPlayerAbility()
    {
        if (_playerAbility != null) return;

        _playerAbility = GetComponentInChildren<PlayerAbility>();

        Debug.LogWarning(transform.name + ": LoadPlayerAbility", gameObject);
    }

    protected virtual void LoadPlayerPickup()
    {
        if (_playerPickup != null) return;

        _playerPickup = GetComponentInChildren<PlayerPickup>();

        Debug.LogWarning(transform.name + ": LoadPlayerPickup", gameObject);
    }
}
