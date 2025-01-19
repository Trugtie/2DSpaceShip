using UnityEngine;

public class PressableAbility : Pressable
{
    [Header(" PressableAbility Elements ")]
    [SerializeField] protected AbilityCode _abilityCode;

    public override void Pressed()
    {
        PlayerCtrl.Instance.PlayerAbility.Active(_abilityCode);
    }
}
