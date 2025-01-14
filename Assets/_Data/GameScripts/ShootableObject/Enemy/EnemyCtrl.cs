using UnityEngine;

public class EnemyCtrl : ShootableObjectCtrl
{
    protected override string GetStringFromObjectType()
    {
        return ObjectType.Enemy.ToString();
    }
}
