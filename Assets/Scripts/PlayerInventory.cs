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
                    Debug.Log($"ũ����Ż {amount} ��� ! ���簳�� : {crystalCount}");
                    return true;
                }
                break;
            case ItemType.Plant:
                if (crystalCount >= amount)
                {
                    crystalCount -= amount;
                    Debug.Log($"�Ĺ� {amount} ��� ! ���簳�� : {crystalCount}");
                    return true;
                }
                break;
            case ItemType.Bush:
                if (crystalCount >= amount)
                {
                    crystalCount -= amount;
                    Debug.Log($"��Ǯ {amount} ��� ! ���簳�� : {crystalCount}");
                    return true;
                }
                break;
            case ItemType.Tree:
                if (crystalCount >= amount)
                {
                    crystalCount -= amount;
                    Debug.Log($"���� {amount} ��� ! ���簳�� : {crystalCount}");
                    return true;
                }
                break;
            case ItemType.VeagetableStew:
                if (vegetalbleStewCiunt >= amount)
                {
                    vegetalbleStewCiunt -= amount;
                    Debug.Log($"��ä ��Ʈ {amount} ��� ! ���簳�� : {vegetalbleStewCiunt}");
                    return true;
                }
                break;
            case ItemType.FruitSalad:
                if (fruitSaledCount >= amount)
                {
                    fruitSaledCount -= amount;
                    Debug.Log($"���� ������ {amount} ��� ! ���簳�� : {fruitSaledCount}");
                    return true;
                }
                break;
            case ItemType.RepairKit:
                if (repairKitCount >= amount)
                {
                    repairKitCount -= amount;
                    Debug.Log($"���� ŰƮ {amount} ��� ! ���簳�� : {repairKitCount}");
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
                Debug.Log($"ũ����Ż ȹ�� ! ���� ���� : {crystalCount}");
                break;
            case ItemType.Plant:
                plantCount++;
                Debug.Log($"�Ĺ� ȹ�� ! ���� ���� : {plantCount}");
                break;
            case ItemType.Bush:
                bushCount++;
                Debug.Log($"��Ǯ ȹ�� ! ���� ���� : {bushCount}");
                break;
            case ItemType.Tree:
                treeCount++;
                Debug.Log($"���� ȹ�� ! ���� ���� : {treeCount}");
                break;

            case ItemType.VeagetableStew:
                treeCount++;
                Debug.Log($"��ä ��Ʃ ȹ�� ! ���� ���� : {vegetalbleStewCiunt}");
                break;
            case ItemType.FruitSalad:
                treeCount++;
                Debug.Log($"���� ������ ȹ�� ! ���� ���� : {fruitSaledCount}");
                break;
            case ItemType.RepairKit:
                treeCount++;
                Debug.Log($"����  ŰƮ ȹ�� ! ���� ���� : {repairKitCount}");
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
        Debug.Log("=======�ι��丮=======");
        Debug.Log($"ũ����Ż : {crystalCount}��");
        Debug.Log($"�Ĺ� : {plantCount}��");
        Debug.Log($"��Ǯ : {bushCount}��");
        Debug.Log($"���� : {treeCount}��");
        Debug.Log("=========================");
    }
}
