using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIItemInventorySpawner : Spawner
{

    public static string UI_INVENTORY_ITEM = "UIInventoryItem";
    public static UIItemInventorySpawner Instance { get; private set; }

    [Header(" UIItemInventorySpawner Elements ")]
    [SerializeField] protected UIInventoryCtrl _uiInventoryCtrl;
    public UIInventoryCtrl UIIventoryCtrl => _uiInventoryCtrl;


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
        _uiInventoryCtrl = GetComponentInParent<UIInventoryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIIventoryCtrl", gameObject);
    }

    public virtual void ClearItems()
    {
        foreach (Transform child in _holder)
        {
            Despawn(child);
        }
    }

    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItemPrefab = Spawn(UI_INVENTORY_ITEM, Vector3.zero, Quaternion.identity);
        uiItemPrefab.localScale = Vector3.one;

        UIInventoryItem uiItem = uiItemPrefab.GetComponent<UIInventoryItem>();
        uiItem.ShowItem(item);

        uiItemPrefab.gameObject.SetActive(true);
    }
}
