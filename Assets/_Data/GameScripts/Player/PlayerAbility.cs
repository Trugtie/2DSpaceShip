using UnityEngine;

public class PlayerAbility : PlayerAbtract
{
    public virtual void Active(AbilityCode abilityCode)
    {
        Debug.Log("Active " + abilityCode.ToString());
    }
}
