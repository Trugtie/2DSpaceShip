using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [Header(" Settings ")]
    [SerializeField] private Vector3 _mousePosition;
    [SerializeField] private float _onFiring;
    public Vector3 MousePosition { get => _mousePosition; }
    public float OnFiring { get => _onFiring; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        GetMouseDown();
    }

    private void FixedUpdate()
    {
        GetMousePos();
    }

    protected virtual void GetMouseDown()
    {
        _onFiring = Input.GetAxis("Fire1");
    }

    protected virtual void GetMousePos()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
