using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ShootableObjectSO", menuName = "SO/New ShootableObjectSO")]
public class ShootableObjectSO : ScriptableObject
{
    public string ShootableObjectName = "ShootableObject Name";
    public ObjectType ObjectType = ObjectType.NoType;
    public int ShootableObjectHP = 2;
    public List<DropRate> _dropList;
}
