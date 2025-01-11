using System;
using UnityEngine;

public enum ItemCode
{
    NoItem = 0,
    IronOre = 1,
    GoldOre = 2,
    CopperSword = 3,
}


public class ItemCodeParse
{
    public static ItemCode ParseFormString(string stringParse)
    {
        try
        {
            return (ItemCode)Enum.Parse(typeof(ItemCode), stringParse);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }
}