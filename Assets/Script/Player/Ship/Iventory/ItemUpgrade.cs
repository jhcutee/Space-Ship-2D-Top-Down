using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemUpgrade : IventoryAbstact
{
    [Header("ItemUpgrade")]
    [SerializeField] protected int maxLevel = 9;
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Test), 2f);
        Invoke(nameof(Test), 4f);
        Invoke(nameof(Test), 6f);
    }
    protected virtual void Test()
    {
        UpgradeItem(0);
    }
    protected virtual bool UpgradeItem(int itemIndex)
    {
        if(itemIndex >= this.inventory.itemInventories.Count) return false;

        ItemInventory itemInventory = this.inventory.itemInventories[itemIndex];
        if(itemInventory.itemCount < 1) return false;

        List<ItemRecipe> itemRecipes = itemInventory.itemProfile.itemRecipesUpgradeLevel;
        if(!this.ItemUpgradeable(itemRecipes)) return false;
        if(!this.HaveEnoughtIngredients(itemRecipes, itemInventory.upgradeLevel)) return false;

        this.DeductIngredients(itemRecipes, itemInventory.upgradeLevel);
        itemInventory.upgradeLevel++;

        return true;
    }
    protected virtual bool ItemUpgradeable(List<ItemRecipe> itemRecipes)
    {
        if(itemRecipes.Count == 0) return false; //kiem tra xem co nang cap dc khong bang cach xem co list khong
        return true;
    }
    protected virtual bool HaveEnoughtIngredients(List<ItemRecipe> _itemRecipes, int _upgradeLevel)
    {
        ItemCode itemCode;
        int itemCount;

        if(_upgradeLevel > _itemRecipes.Count)
        {
            Debug.Log("Item Cant Upgrade Anymore!!!");
            return false;
        }
        ItemRecipe itemRecipeCurrentLevel = _itemRecipes[_upgradeLevel];
        foreach(ItemRecipeIngredients ingredient in itemRecipeCurrentLevel.ItemRecipeIngredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;
            if(!this.inventory.CheckItem(itemCode, itemCount)) return false;
        }
        return true;
    }
    protected virtual void DeductIngredients(List<ItemRecipe> _itemRecipes, int _upgradeLevel)
    {
        ItemCode itemCode;
        int itemCount;
        ItemRecipe itemRecipeCurrentLevel = _itemRecipes[_upgradeLevel];
        foreach (ItemRecipeIngredients ingredient in itemRecipeCurrentLevel.ItemRecipeIngredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            this.inventory.DeductItem(itemCode, itemCount); 
        }
    }
}
