using UnityEngine;

public class ItemAbtract : BaseMonobehaviour
{
    [Header(" Item Abtract ")]
    [SerializeField] protected ItemCtrl _itemCtrl;
    public ItemCtrl ItemCtrl => _itemCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemCtrl();
    }

    protected virtual void LoadItemCtrl()
    {
        if (_itemCtrl != null) return;
        _itemCtrl = GetComponentInParent<ItemCtrl>();
        Debug.LogWarning(transform.name + ": LoadItemCtrl", gameObject);
    }
}
