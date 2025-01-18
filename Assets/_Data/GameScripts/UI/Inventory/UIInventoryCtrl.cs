using System;
using UnityEngine;

public class UIInventoryCtrl : BaseMonobehaviour
{
    private const string SCROLL_VIEW = "Scroll View";
    private const string CONTENT = "Content";
    private const string VIEWPORT = "Viewport";

    [Header(" UIIventoryCtrl Elements ")]
    [SerializeField] protected Transform _content;
    [SerializeField] protected UIItemInventorySpawner _uiItemInventorySpawner;

    public Transform Content => _content;
    public UIItemInventorySpawner UIItemInventorySpawner => _uiItemInventorySpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadContent();
        LoadUIItemInventorySpawner();
    }

    protected virtual void LoadUIItemInventorySpawner()
    {
        if (_uiItemInventorySpawner != null) return;
        _uiItemInventorySpawner = GetComponentInChildren<UIItemInventorySpawner>();
        Debug.LogWarning(transform.name + ": LoadUIItemInventorySpawner", gameObject);
    }

    protected virtual void LoadContent()
    {
        if (_content != null) return;
        _content = transform.Find(SCROLL_VIEW).Find(VIEWPORT).Find(CONTENT);
        Debug.LogWarning(transform.name + ": LoadContent", gameObject);
    }
}
