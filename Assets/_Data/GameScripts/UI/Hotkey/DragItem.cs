using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : BaseMonobehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header(" DragItem Elements ")]
    [SerializeField] protected Transform _realParent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRealParent();
    }

    private void LoadRealParent()
    {
        if (_realParent != null) return;
        _realParent = transform.parent;
        Debug.LogWarning(transform.name + ": LoadRealParent", gameObject);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(UIHotKeyCtrl.Instance.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = InputManager.Instance.MousePosition;
        mousePosition.z = 0;
        transform.position = mousePosition;
        Debug.Log("Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_realParent);
    }
}
