using UnityEngine;

public class Pressable : BaseMonobehaviour
{
    public virtual void Pressed()
    {
        Debug.Log(transform.parent.parent.name);
    }
}
