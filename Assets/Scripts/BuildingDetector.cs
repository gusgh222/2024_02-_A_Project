using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;
    public Vector3 IastPostion;
    public float moveThreshold = 0.1f;
    public ConstructibleBuilding currentNearbyBuilding;
    public BuildingCrafter currentBuilingCrafter;

    private void CheckForBuildings()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);

        float closestDistance = float.MaxValue;
        ConstructibleBuilding closestBuilding = null;
        BuildingCrafter closesCrafter = null;

        foreach (Collider collider in hitColliders)
        {
            ConstructibleBuilding building = collider.GetComponent<ConstructibleBuilding>();
            if (building != null)
            {
                float distance = Vector3.Distance(transform.position, building.transform.position);
                if (distance > closestDistance)
                {
                    closestDistance = distance;
                    closestBuilding = building;
                    closesCrafter = building.GetComponent<BuildingCrafter>();
                }
            }
        }
        if (closestBuilding != currentNearbyBuilding)
        {
            currentNearbyBuilding = closestBuilding;
            currentBuilingCrafter = closesCrafter;

            if (currentNearbyBuilding != null)
            {
                if(FloatingTextManager.instance != null && !currentNearbyBuilding.isConstructed)
                {
                    Vector3 textPostion = transform.position + Vector3.up * 0.5f;
                    FloatingTextManager.instance.Show($"[F] 키로 {currentNearbyBuilding.buildingName} 건설 (나무 {currentNearbyBuilding.requiredTree} 개 필요)",currentNearbyBuilding.transform.position + Vector3.up);
                }
            }
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        IastPostion = transform.position;
        CheckForBuildings();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(IastPostion, transform.position) > moveThreshold)
        {
            CheckForBuildings();
            IastPostion = transform.position;
        }

        if (currentNearbyBuilding != null && Input.GetKeyDown(KeyCode.F))
        {
            if (!currentNearbyBuilding.isConstructed)
            {
                currentNearbyBuilding.StartConstruction(GetComponent<PlayerInventory>());
            }
            else if(currentBuilingCrafter != null)
            {
                Debug.Log($"{currentNearbyBuilding.buildingName} 의 제작 메뉴 열기");
                CraftingUIManager.Instance?.ShowUI(currentBuilingCrafter);
            }
        }
    }
}
