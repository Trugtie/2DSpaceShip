using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : BaseMonobehaviour, IDropHandler
{
    public virtual void OnDrop(PointerEventData eventData)
    {
        GameObject dragObject = eventData.pointerDrag;
        DragItem dragItem = dragObject.GetComponent<DragItem>();
        dragItem.SetRealParent(transform);
    }
}
