using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int plantCount = 0;
    public int crystalCount = 0;
    public int bushCount = 0;
    public int treeCount = 0;

    public void AddItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Crystal:
                crystalCount++;
                Debug.Log($"Å©¸®½ºÅ» È¹µæ ! ÇöÀç °³¼ö : {crystalCount}");
                break;
            case ItemType.Plant:
                plantCount++;
                Debug.Log($"½Ä¹° È¹µæ ! ÇöÀç °³¼ö : {plantCount}");
                break;
            case ItemType.Bush:
                bushCount++;
                Debug.Log($"¼öÇ® È¹µæ ! ÇöÀç °³¼ö : {bushCount}");
                break;
            case ItemType.Tree:
                treeCount++;
                Debug.Log($"³ª¹« È¹µæ ! ÇöÀç °³¼ö : {treeCount}");
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
        Debug.Log("=======ÀÎ¹êÅä¸®=======");
        Debug.Log($"Å©¸®½ºÅ» : {crystalCount}°³");
        Debug.Log($"½Ä¹° : {plantCount}°³");
        Debug.Log($"¼öÇ® : {bushCount}°³");
        Debug.Log($"³ª¹« : {treeCount}°³");
        Debug.Log("=========================");
    }
}
