using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI CountText;
    public Button useButton;

    private ItemType itemType;
    private int itemCount;

    public void Setup (ItemType type, int Count)
    {
        itemType = type;
        itemCount = Count;

        itemNameText.text = GetItemDisplayName(type);
        CountText.text = Count.ToString();

        useButton.onClick.AddListener(UseItem);
    }

    private string GetItemDisplayName(ItemType type)
    {
        switch (type)
        {
            case ItemType.VeagetableStew: return "��ä ��Ʃ";
            case ItemType.FruitSalad: return "���� ������";
            case ItemType.RepairKit: return "���� ŰƮ";
                default: return type.ToString();
        }
    }

    private void UseItem()
    {
        PlayerInventory inventory = FindObjectOfType<PlayerInventory>();
        SurvivalStats stats = FindObjectOfType<SurvivalStats>();

        switch (itemType)
        {
            case ItemType.VeagetableStew:
                if (inventory.RemoveItem(itemType, 1))
                {
                    stats.EatFood(40f);
                    InventoryManager.Instance.RefreshInvenTory();
                }
                break;
            case ItemType.FruitSalad:
                if (inventory.RemoveItem(itemType, 1))
                {
                    stats.EatFood(50f);
                    InventoryManager.Instance.RefreshInvenTory();
                }
                break;
            case ItemType.RepairKit:
                if (inventory.RemoveItem(itemType, 1))
                {
                    stats.RepairSuit(25f);
                    InventoryManager.Instance.RefreshInvenTory();
                }
                break;
        }
    }
}
