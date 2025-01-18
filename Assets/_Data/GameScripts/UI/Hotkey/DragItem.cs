using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : BaseMonobehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header(" DragItem Elements ")]
    [SerializeField] protected Transform _realParent;
    [SerializeField] protected Image _dragItemImage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDragItemImage();
    }

    protected virtual void LoadDragItemImage()
    {
        if (_dragItemImage != null) return;
        _dragItemImage = GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadDragItemImage", gameObject);
    }

    public virtual void SetRealParent(Transform newParent)
    {
        _realParent = newParent;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _realParent = transform.parent;
        transform.SetParent(UIHotKeyCtrl.Instance.transform);
        _dragItemImage.raycastTarget = false;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = InputManager.Instance.MousePosition;
        mousePosition.z = 0;
        transform.position = mousePosition;
        Debug.Log("Drag");
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_realParent);
        _dragItemImage.raycastTarget = true;
    }
}
