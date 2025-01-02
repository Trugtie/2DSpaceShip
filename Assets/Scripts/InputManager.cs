using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    [Header(" Settings ")]
    [SerializeField] public Vector3 _mousePosition;

    private void Awake()
    {
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
