using System;
using UnityEngine;

public enum AbilityCode
{
    NoAbility = 0,
    Missle = 1,
    Laze = 2,
    Dash = 3,
}


public class AbilityCodeParse
{
    public static AbilityCode ParseFormString(string stringParse)
    {
        try
        {
            return (AbilityCode)Enum.Parse(typeof(AbilityCode), stringParse);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return AbilityCode.NoAbility;
        }
    }
}