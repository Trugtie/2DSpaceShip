using UnityEngine;

public class UIHotKeyCtrl : BaseMonobehaviour
{
    public static UIHotKeyCtrl Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
}
