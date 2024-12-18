using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private SurvivalStats survivalStats;

    public int plantCount = 0;
    public int crystalCount = 0;
    public int bushCount = 0;
    public int treeCount = 0;

    public int vegetalbleStewCiunt = 0;
    public int fruitSaledCount = 0;
    public int repairKitCount = 0;

    public void Start()
    {
        survivalStats = GetComponent<SurvivalStats>();
    }

    public void UesItem(ItemType itemType)
    {
        if (GetItemCount(itemType) <= 0)
        {
            return;
        }
        switch (itemType)
        {
            case ItemType.VeagetableStew:
                RemoveItem(ItemType.VeagetableStew , 1);
                survivalStats.EatFood(RecipeList.KitchenRecipes[0].hungerRestoreAmount);
                break;
            case ItemType.FruitSalad:
                RemoveItem(ItemType.FruitSalad, 1);
                survivalStats.EatFood(RecipeList.KitchenRecipes[0].hungerRestoreAmount);
                break;
            case ItemType.RepairKit:
                RemoveItem(ItemType.RepairKit, 1);
                survivalStats.EatFood(RecipeList.KitchenRecipes[0].hungerRestoreAmount);
                break;
        }
    }

    public void AddItem(ItemType itemType, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            AddItem(itemType);
        }
    }

    public bool RemoveItem(ItemType itemType, int amount = 1)
    {
        switch (itemType)
        {
            case ItemType.Crystal:
                if (crystalCount >= amount)
                {
                    crystalCount -= amount;
                    Debug.Log($"크리스탈 {amount} 사용 ! 현재개수 : {crystalCount}");
                    return true;
                }
                break;
            case ItemType.Plant:
                if (crystalCount >= amount)
                {
                    crystalCount -= amount;
                    Debug.Log($"식물 {amount} 사용 ! 현재개수 : {crystalCount}");
                    return true;
                }
                break;
            case ItemType.Bush:
                if (crystalCount >= amount)
                {
                    crystalCount -= amount;
                    Debug.Log($"수풀 {amount} 사용 ! 현재개수 : {crystalCount}");
                    return true;
                }
                break;
            case ItemType.Tree:
                if (crystalCount >= amount)
                {
                    crystalCount -= amount;
                    Debug.Log($"나무 {amount} 사용 ! 현재개수 : {crystalCount}");
                    return true;
                }
                break;
            case ItemType.VeagetableStew:
                if (vegetalbleStewCiunt >= amount)
                {
                    vegetalbleStewCiunt -= amount;
                    Debug.Log($"야채 스트 {amount} 사용 ! 현재개수 : {vegetalbleStewCiunt}");
                    return true;
                }
                break;
            case ItemType.FruitSalad:
                if (fruitSaledCount >= amount)
                {
                    fruitSaledCount -= amount;
                    Debug.Log($"과일 샐러드 {amount} 사용 ! 현재개수 : {fruitSaledCount}");
                    return true;
                }
                break;
            case ItemType.RepairKit:
                if (repairKitCount >= amount)
                {
                    repairKitCount -= amount;
                    Debug.Log($"수리 키트 {amount} 사용 ! 현재개수 : {repairKitCount}");
                    return true;
                }
                break;
        }
        return false;
    }

    public int GetItemCount(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Crystal:
                return crystalCount;
            case ItemType.Plant:
                return crystalCount;
            case ItemType.Bush:
                return crystalCount;
            case ItemType.Tree:
                return crystalCount;

            case ItemType.VeagetableStew:
                return vegetalbleStewCiunt;
            case ItemType.FruitSalad:
                return fruitSaledCount;
            case ItemType.RepairKit:
                return repairKitCount;

            default:
                return 0;
        }
    }
    public void AddItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Crystal:
                crystalCount++;
                Debug.Log($"크리스탈 획득 ! 현재 개수 : {crystalCount}");
                break;
            case ItemType.Plant:
                plantCount++;
                Debug.Log($"식물 획득 ! 현재 개수 : {plantCount}");
                break;
            case ItemType.Bush:
                bushCount++;
                Debug.Log($"수풀 획득 ! 현재 개수 : {bushCount}");
                break;
            case ItemType.Tree:
                treeCount++;
                Debug.Log($"나무 획득 ! 현재 개수 : {treeCount}");
                break;

            case ItemType.VeagetableStew:
                treeCount++;
                Debug.Log($"야채 스튜 획득 ! 현재 개수 : {vegetalbleStewCiunt}");
                break;
            case ItemType.FruitSalad:
                treeCount++;
                Debug.Log($"과일 샐러드 획득 ! 현재 개수 : {fruitSaledCount}");
                break;
            case ItemType.RepairKit:
                treeCount++;
                Debug.Log($"수리  키트 획득 ! 현재 개수 : {repairKitCount}");
                break;

        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }
    }

    private void ShowInventory()
    {
        Debug.Log("=======인밴토리=======");
        Debug.Log($"크리스탈 : {crystalCount}개");
        Debug.Log($"식물 : {plantCount}개");
        Debug.Log($"수풀 : {bushCount}개");
        Debug.Log($"나무 : {treeCount}개");
        Debug.Log("=========================");
    }
}
