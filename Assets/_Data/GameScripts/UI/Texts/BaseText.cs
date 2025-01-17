using TMPro;
using UnityEngine;

public class BaseText : BaseMonobehaviour
{
    [Header(" BaseText Elements ")]
    [SerializeField] protected TextMeshProUGUI _text;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadText();
    }

    protected virtual void LoadText()
    {
        if (_text != null) return;
        _text = GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadText", gameObject);
    }
}
