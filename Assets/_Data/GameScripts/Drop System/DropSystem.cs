using System.Collections.Generic;
using UnityEngine;

public class DropSystem : BaseMonobehaviour
{
    public static DropSystem Instance { get; private set; }

    protected override void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public virtual void Drop(List<DropRate> dropList)
    {
        Debug.Log("Drop: " + dropList[0].ItemSO.ItemName);
    }
}
