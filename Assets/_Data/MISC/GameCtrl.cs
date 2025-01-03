using UnityEngine;

public class GameCtrl : BaseMonobehaviour
{
    public static GameCtrl Instance { get; private set; }

    [Header(" Elements ")]
    [SerializeField] protected Camera _mainCamera;
    public Camera MainCamera { get => _mainCamera; }

    protected override void Awake()
    {
        base.Awake();

        if (Instance != null && Instance == this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMainCamera();
    }

    protected virtual void LoadMainCamera()
    {
        if (_mainCamera != null) return;
        _mainCamera = Camera.main;
        Debug.Log(transform.name + ": LoadMainCamera", gameObject);
    }

    public virtual Vector3 GetMainCameraPosition()
    {
        if (_mainCamera == null)
        {
            Debug.LogWarning("Main Camera Not Found!");
            return Vector3.zero;
        }

        return _mainCamera.transform.position;
    }
}
