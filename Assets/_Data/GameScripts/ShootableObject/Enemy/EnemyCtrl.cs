using UnityEngine;

public class EnemyCtrl : AbilityObjectCtrl
{
    protected override string GetStringFromObjectType()
    {
        return ObjectType.Enemy.ToString();
    }
}
