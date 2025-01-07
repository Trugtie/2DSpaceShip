using UnityEngine;

public class PlayerCtrl : BaseMonobehaviour
{
    public static PlayerCtrl Instance { get; private set; }

    [Header(" Elements ")]
    [SerializeField] protected ShipCtrl _currentShip;
    [SerializeField] protected PlayerPickup _playerPickup;

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
    }

    protected virtual void LoadPlayerPickup()
    {
        if (_playerPickup != null) return;

        _playerPickup = GetComponentInChildren<PlayerPickup>();

        Debug.LogWarning(transform.name + ": LoadPlayerPickup", gameObject);
    }
}
