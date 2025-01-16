using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : BaseMonobehaviour
{
    [Header(" ItemDropTest Elements ")]
    [SerializeField] protected JunkCtrl _junkCtrl;
    [Header(" Test View ")]
    [SerializeField] protected int _droppedCount;
    [SerializeField] protected List<ItemDropCountTest> _droppedItemsCount = new List<ItemDropCountTest>();

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(Dropping), 2, 1);
    }

    protected virtual void Dropping()
    {
        _droppedCount += 1;
        Vector3 dropPosition = transform.position;
        Quaternion dropRotation = transform.rotation;
        List<ItemDropRate> itemsDropped = ItemSpawner.Instance.Drop(_junkCtrl.ShootableObjectSO._dropList, dropPosition, dropRotation);

        ItemDropCountTest itemDropCountTest;
        foreach (ItemDropRate itemDropped in itemsDropped)
        {
            itemDropCountTest = _droppedItemsCount.Find((item) => item.ItemDropCountName == itemDropped.ItemProfileSO.ItemName);
            if (itemDropCountTest == null)
            {
                itemDropCountTest = new ItemDropCountTest
                {
                    ItemDropCountName = itemDropped.ItemProfileSO.ItemName,
                };

                _droppedItemsCount.Add(itemDropCountTest);
            }

            itemDropCountTest.DroppedCout += 1;
            itemDropCountTest.RateCalulated = (float)Math.Round((float)itemDropCountTest.DroppedCout / _droppedCount, 2);
        }
    }
}

[Serializable]
public class ItemDropCountTest
{
    public string ItemDropCountName;
    public int DroppedCout;
    public float RateCalulated;
}
