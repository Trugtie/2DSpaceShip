using UnityEngine;

public class BaseMonobehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        LoadComponents();
    }

    protected virtual void Reset()
    {
        LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        //For override
    }
}
