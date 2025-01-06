using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New JunkSO", menuName = "SO/NewJunkSO")]
public class JunkSO : ScriptableObject
{
    public string JunkName;
    public int JunkHP;
    public List<DropRate> _dropList;
}
