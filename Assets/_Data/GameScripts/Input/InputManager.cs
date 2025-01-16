using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [Header(" Settings ")]
    [SerializeField] private Vector3 _mousePosition;
    [SerializeField] private float _onFiring;
    private Vector4 _direction;
    public Vector3 MousePosition => _mousePosition;
    public float OnFiring => _onFiring;
    public Vector4 Direction => _direction;

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
        GetDirectionByKeyDown();
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

    protected virtual void GetDirectionByKeyDown()
    {
        _direction.x = Input.GetKeyDown(KeyCode.A) ? 1 : 0;
        if (_direction.x == 0) _direction.x = Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;

        _direction.y = Input.GetKeyDown(KeyCode.D) ? 1 : 0;
        if (_direction.y == 0) _direction.y = Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;

        _direction.z = Input.GetKeyDown(KeyCode.W) ? 1 : 0;
        if (_direction.z == 0) _direction.z = Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;

        _direction.w = Input.GetKeyDown(KeyCode.S) ? 1 : 0;
        if (_direction.w == 0) _direction.w = Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;

        //if (_direction.x == 1) Debug.Log("Left");
        //if (_direction.y == 1) Debug.Log("Right");
        //if (_direction.z == 1) Debug.Log("Up");
        //if (_direction.w == 1) Debug.Log("Down");
    }
}
