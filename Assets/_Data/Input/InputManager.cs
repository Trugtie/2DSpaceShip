using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [Header(" Settings ")]
    [SerializeField] private Vector3 _mousePosition;
    public Vector3 MousePosition { get => _mousePosition; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void FixedUpdate()
    {
        GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
