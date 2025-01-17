using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIItemInventorySpawner : Spawner
{

    public static string UI_INVENTORY_ITEM = "UIInventoryItem";
    public static UIItemInventorySpawner Instance { get; private set; }

    [Header(" UIItemInventorySpawner Elements ")]
    [SerializeField] protected UIIventoryCtrl _uiInventoryCtrl;
    public UIIventoryCtrl UIIventoryCtrl => _uiInventoryCtrl;


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

    protected override void LoadHolder()
    {
        LoadUIIventoryCtrl();

        if (_holder != null) return;
        _holder = _uiInventoryCtrl.Content;
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }

    private void LoadUIIventoryCtrl()
    {
        if (_uiInventoryCtrl != null) return;
        _uiInventoryCtrl = GetComponentInParent<UIIventoryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIIventoryCtrl", gameObject);
    }
}
