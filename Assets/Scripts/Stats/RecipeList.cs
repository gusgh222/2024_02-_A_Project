using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeList
{
    public static CraftingRecipe[] KitchenRecipes = new CraftingRecipe[]
    {
        new CraftingRecipe
        {
            itemName = "야채 스튜",
            resuItItem = ItemType.VeagetableStew,
            repairAmount = 1,
            hungerRestoreAmount = 40f,
            requiredItems =new ItemType[] {ItemType.Plant ,ItemType.Bush},
            requiredAmounts = new int[] {2 ,1}
        },
        new CraftingRecipe
        {
            itemName = "과일 샐러드",
            resuItItem = ItemType.FruitSalad,
            repairAmount = 1,
            hungerRestoreAmount = 60f,
            requiredItems =new ItemType[] {ItemType.Plant ,ItemType.Bush},
            requiredAmounts = new int[] {3 ,3}
        },
    };
    public static CraftingRecipe[] WorkbenchRecipes = new CraftingRecipe[]
    {
        new CraftingRecipe
        {
            itemName = "수리 키트",
            resuItItem = ItemType.RepairKit,
            resultAmount = 1,
            repairAmount = 25.0f,
            requiredItems = new ItemType[] {ItemType.Crystal},
            requiredAmounts = new int[] {3}
        },
    };
}

