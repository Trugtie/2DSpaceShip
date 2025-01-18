using UnityEngine;

public class InputHotkeyManager : MonoBehaviour
{
    public static InputHotkeyManager Instance { get; private set; }

    [Header(" InputHotkeyManager Elements ")]
    [SerializeField] public bool isHotkey1 = false;
    [SerializeField] public bool isHotkey2 = false;
    [SerializeField] public bool isHotkey3 = false;
    [SerializeField] public bool isHotkey4 = false;
    [SerializeField] public bool isHotkey5 = false;
    [SerializeField] public bool isHotkey6 = false;
    [SerializeField] public bool isHotkey7 = false;


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
        GetInputHotkey();
    }

    protected virtual void GetInputHotkey()
    {
        isHotkey1 = Input.GetKeyDown(KeyCode.Alpha1);
        isHotkey2 = Input.GetKeyDown(KeyCode.Alpha2);
        isHotkey3 = Input.GetKeyDown(KeyCode.Alpha3);
        isHotkey4 = Input.GetKeyDown(KeyCode.Alpha4);
        isHotkey5 = Input.GetKeyDown(KeyCode.Alpha5);
        isHotkey6 = Input.GetKeyDown(KeyCode.Alpha6);
        isHotkey7 = Input.GetKeyDown(KeyCode.Alpha7);
    }
}
