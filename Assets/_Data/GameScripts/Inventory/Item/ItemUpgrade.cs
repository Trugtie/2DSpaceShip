using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbtract
{
    [Header(" Settings ")]
    [SerializeField] protected int _maxLevel = 9;

    protected override void Start()
    {
        base.Start();

        //Test
        Invoke(nameof(TestUpgrade), 10);
    }

    //Test
    private void TestUpgrade()
    {
        UpgradeItemLevel(0);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _maxLevel = 9;
    }

    protected virtual bool UpgradeItemLevel(int itemIndex)
    {
        if (itemIndex > Inventory.Items.Count) return false;

        ItemInventory itemInventory = Inventory.Items[itemIndex];

        if (itemInventory.itemCount < 1) return false;

        List<ItemRecipe> itemRecipesNeedToUpgradePerLevel = itemInventory.ItemProfile.ItemRecipesNeedToUpgradePerLevel;

        if (!IsItemUpgradeable(itemRecipesNeedToUpgradePerLevel, itemInventory.upgradeLevel)) return false;
        if (!IsHasEnoughResourceToUpgradeItem(itemRecipesNeedToUpgradePerLevel, itemInventory.upgradeLevel)) return false;

        DeductItemToUpgrade(itemRecipesNeedToUpgradePerLevel, itemInventory.upgradeLevel);
        itemInventory.upgradeLevel++;

        return true;
    }

    protected virtual bool IsItemUpgradeable(List<ItemRecipe> itemRecipesNeedToUpgradePerLevel, int currentLevel)
    {
        if (itemRecipesNeedToUpgradePerLevel.Count < 1) return false;

        bool isItemReachedMaxLevel = currentLevel > itemRecipesNeedToUpgradePerLevel.Count;
        if (isItemReachedMaxLevel) return false;

        return true;
    }

    private bool IsHasEnoughResourceToUpgradeItem(List<ItemRecipe> itemRecipesNeedToUpgradePerLevel, int currentLevel)
    {
        ItemRecipe itemRecipeNeedToUpgradeNextLevel = itemRecipesNeedToUpgradePerLevel[currentLevel];

        foreach (ItemRecipeIngredient itemRecipeIngredient in itemRecipeNeedToUpgradeNextLevel.ItemRecipeIngredients)
        {
            if (!IsHasEnoughThisItemInInventory(itemRecipeIngredient.ItemProfileSO.ItemCode, itemRecipeIngredient.itemCount)) return false;
        }

        return true;
    }

    protected virtual bool IsHasEnoughThisItemInInventory(ItemCode itemNeedCheck, int itemNeedCount)
    {
        int totalItemRemainInInventory = GetToTalItemInInventory(itemNeedCheck);

        bool isEnoughItem = totalItemRemainInInventory >= itemNeedCount;

        if (!isEnoughItem) return false;

        return true;
    }

    protected virtual int GetToTalItemInInventory(ItemCode itemCode)
    {
        int total = 0;

        foreach (ItemInventory item in Inventory.Items)
        {
            if (item.ItemProfile.ItemCode != itemCode) continue;
            total += item.itemCount;
        }

        return total;
    }

    protected virtual void DeductItemToUpgrade(List<ItemRecipe> itemRecipesNeedToUpgradePerLevel, int currentLevel)
    {
        ItemRecipe itemRecipeNeedToUpgradeNextLevel = itemRecipesNeedToUpgradePerLevel[currentLevel];

        foreach (ItemRecipeIngredient itemRecipeIngredient in itemRecipeNeedToUpgradeNextLevel.ItemRecipeIngredients)
        {
            Inventory.DeductItem(itemRecipeIngredient.ItemProfileSO.ItemCode, itemRecipeIngredient.itemCount);
        }
    }
}
