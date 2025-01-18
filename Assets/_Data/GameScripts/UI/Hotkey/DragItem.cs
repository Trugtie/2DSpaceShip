using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : BaseMonobehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
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
        Debug.Log("End Drag");
    }
}
